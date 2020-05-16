using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonManager : MonoBehaviour
{
    public Button button;
    void Start()
    {
        if (button.name.Equals("ResumeButton"))
        {
            if (SaveSystem.IsSaveExist())
            {
                button.gameObject.SetActive(true);
            }
            else
            {
                button.gameObject.SetActive(false);
            }
        }
    }
}
