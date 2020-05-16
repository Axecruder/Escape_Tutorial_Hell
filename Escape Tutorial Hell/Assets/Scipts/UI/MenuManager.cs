using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public SceneAsset scene;

    public void NewGame()
    {
        SaveSystem.IsNeedToLoad(false);
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
    }
    public void ResumeGame()
    {
        SaveSystem.IsNeedToLoad(true);
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
    }

    public void PauseGame()
    {
        SaveSystem.SavePlayer();
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
    }
}
