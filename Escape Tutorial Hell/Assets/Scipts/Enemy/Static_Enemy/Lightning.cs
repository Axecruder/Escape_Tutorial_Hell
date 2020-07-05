using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public GameObject lightning;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Strike()
    {
        StartCoroutine(LightningStruckRoutine());
    }

    public IEnumerator LightningStruckRoutine()
    {
        lightning.SetActive(true);
        yield return new WaitForSeconds(2);
        lightning.SetActive(false);
    }

 
}
