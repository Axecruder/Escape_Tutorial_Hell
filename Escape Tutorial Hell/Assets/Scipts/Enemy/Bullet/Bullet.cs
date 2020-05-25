using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject collisionEffect;

    [SerializeField] private float bulletSpeed;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, bulletSpeed * Time.deltaTime,0);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable hit = collision.GetComponent<IDamageable>();
        if (collision.tag == "Player" && hit != null )
        {
            hit.Damage();
            Instantiate(collisionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
