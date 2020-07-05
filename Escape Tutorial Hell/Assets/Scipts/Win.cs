using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public SceneAsset sceneAsset;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LevelFinished();
        }
    }

    private void LevelFinished()
    {
        SaveSystem.actualSceneName = sceneAsset.name;
        SceneManager.LoadScene(sceneAsset.name, LoadSceneMode.Single);
    }
}
