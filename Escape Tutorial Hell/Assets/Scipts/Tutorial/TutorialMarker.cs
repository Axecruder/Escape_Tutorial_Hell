using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMarker : MonoBehaviour
{
    public string message;
    public GameObject Tutorialbox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Tutorialbox.SetActive(true);
            Text messagebox = GameObject.Find("TutorialText").GetComponent<Text>();
            messagebox.text = message;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Tutorialbox.SetActive(false);
        }
    }
}
