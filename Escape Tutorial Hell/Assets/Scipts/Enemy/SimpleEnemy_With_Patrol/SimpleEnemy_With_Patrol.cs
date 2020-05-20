using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy_With_Patrol : MonoBehaviour
{
    private EnemyData enemyData;

    void Start()
    {
        enemyData = new EnemyData
        {
            type = EnemyType.SimpleEnemy_With_Patrol
        };
        transform.parent.GetComponent<EnemyLoader>().AddEnemyData(enemyData);
        float[] position = new float[3];
        position[0] = transform.position.x;
        position[1] = transform.position.y;
        position[2] = transform.position.z;
        enemyData.position = position;
    }

    void Update()
    {

    }

    void OnDestroy()
    {
        transform.parent.GetComponent<EnemyLoader>().DeleteEnemyData(enemyData);
    }
}
