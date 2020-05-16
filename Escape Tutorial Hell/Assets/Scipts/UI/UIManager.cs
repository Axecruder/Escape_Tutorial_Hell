using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("UIManager is null");
            }
            return instance;
        }
    }

    public Image[] healthArray;
    public static int initHealth;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateLives(int livesRemaining)
    {
        for (int i = 0; i < initHealth; i++)
        {
            if (i < livesRemaining)
            {
                healthArray[i].enabled = true;
            }
            else
            {
                healthArray[i].enabled = false;
            }
        }
    }
}
