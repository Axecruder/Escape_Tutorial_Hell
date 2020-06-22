using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public SceneAsset scene;
    public EnemyLoader enemyLoader;

    public void NewGame()
    {
        SaveSystem.SetNeedToLoad(false);
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
    }
    public void ResumeGame()
    {
        SaveSystem.SetNeedToLoad(true);
        if(SaveSystem.actualSceneName != null)
        {
            SceneManager.LoadScene(SaveSystem.actualSceneName, LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
        }
    }

    public void PauseGame()
    {
        SaveSystem.actualSceneName = SceneManager.GetActiveScene().name;
        SaveSystem.SavePlayer();
        enemyLoader.SaveEnemies();
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
    }
}
