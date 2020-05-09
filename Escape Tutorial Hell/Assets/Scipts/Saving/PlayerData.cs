using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To be able to save into file
[System.Serializable]
public class PlayerData
{
    //Data to save
    public int health;
    public float[] position;

    //Get actual data
    public PlayerData(Player player)
    {
        health = player.Health;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }


}
