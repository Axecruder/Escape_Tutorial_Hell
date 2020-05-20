using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 45f));
        Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, -45f));
        Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0f));
    }
}
