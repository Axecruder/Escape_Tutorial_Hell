using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    IDamageable hit;
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
        hit = collision.GetComponent<IDamageable>();
        if (hit != null)
        {
            hit.Damage();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        hit = collision.GetComponent<IDamageable>();
        if (hit != null)
        {
            hit.Damage();
        }
    }
}
