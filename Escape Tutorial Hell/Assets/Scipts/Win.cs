using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LevelFinished();
        }
    }

    private void LevelFinished()
    {
        Debug.Log("Level passed");
    }
}
