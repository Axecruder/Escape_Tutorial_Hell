using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameButton : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMap()
    {
        SaveSystem.SavePlayer(player);
        SceneManager.LoadScene("LaunchScene", LoadSceneMode.Single);
    }
}
