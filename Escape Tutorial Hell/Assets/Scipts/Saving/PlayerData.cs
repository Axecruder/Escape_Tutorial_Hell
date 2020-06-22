using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//To be able to save into file
[System.Serializable]
public class PlayerData
{
    public string actualSceneName;
    //Data to save
    public int health;
    public float[] position;
    public bool facingRight;

    //Get actual data
    public PlayerData(Player player)
    {
        health = player.Health;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        facingRight = player.facingRight;

        actualSceneName = SaveSystem.actualSceneName;
    }

    public void LoadDataToPlayer(Player player)
    {
        player.Health = health;
        player.transform.position = new Vector3(position[0], position[1], position[2]);
        player.facingRight = facingRight;

        SaveSystem.actualSceneName = actualSceneName;
    }
}
