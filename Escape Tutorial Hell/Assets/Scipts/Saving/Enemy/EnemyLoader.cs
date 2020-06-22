using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class EnemyLoader : MonoBehaviour
{
    private static List<EnemyData> enemyDataList;
    public GameObject enemiesParent;

    //Enemies prehabs
    public GameObject Prefab_SimpleEnemy_With_Patrol;
    public GameObject Prefab_SpikeShooterEnemy;

    // Start is called before the first frame update
    void Start()
    {
        if (SaveSystem.IsNeedToLoad())
        {
            LoadEnemiesData();
            DestroyAllEnemies();
            InitializeEnemies();
            enemyDataList = new List<EnemyData>();
        }
    }

    public void AddEnemyData(EnemyData enemyData)
    {
        if (enemyDataList == null) {
            enemyDataList = new List<EnemyData>();
        }
        enemyDataList.Add(enemyData);
    }

    public void DeleteEnemyData(EnemyData enemyData)
    {
        enemyDataList.Remove(enemyData);
    }

    public void SaveEnemies()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //Path where save file is created
        string path = Application.persistentDataPath + "/enemies.fun";
        //Creating save file
        FileStream stream = new FileStream(path, FileMode.Create);

        //Encrypts data in binary
        formatter.Serialize(stream, enemyDataList);
        stream.Close();
    }

    private void LoadEnemiesData()
    {
            //Must be the same as in save file. 
            string path = Application.persistentDataPath + "/enemies.fun";

            //Check if path is exists
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                //Dissolv encrypt
                enemyDataList = formatter.Deserialize(stream) as List<EnemyData>;
                stream.Close();
            }
            else
            {
                Debug.Log("Save file not found in " + path);
            }
    }
    private void DestroyAllEnemies()
    {
        foreach (Transform child in enemiesParent.transform)
        {
            Destroy(child.gameObject);
        }
    }
    private void InitializeEnemies()
    {
        for (int i = 0; i < enemyDataList.Count; i++)
        {
            EnemyData data = enemyDataList[i];
            GameObject enemy;
            switch (data.type)
            {
                case EnemyType.SimpleEnemy_With_Patrol:
                    enemy = Instantiate(Prefab_SimpleEnemy_With_Patrol,
                        new Vector3(data.position[0], data.position[1], data.position[2]),
                        Quaternion.identity);
                    enemy.GetComponent<SimpleEnemy>().diretion = data.direction;
                    break;
                case EnemyType.ShooterEnemy:
                    enemy = Instantiate(Prefab_SpikeShooterEnemy,
                        new Vector3(data.position[0], data.position[1], data.position[2]),
                        Quaternion.identity);
                    break;
                default:
                    continue;
            }
            enemy.transform.SetParent(enemiesParent.transform);
        }
    }
}
