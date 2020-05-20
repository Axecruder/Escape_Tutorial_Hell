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
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
    }

    public void PauseGame()
    {
        SaveSystem.SavePlayer();
        enemyLoader.SaveEnemies();
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
    }
}
