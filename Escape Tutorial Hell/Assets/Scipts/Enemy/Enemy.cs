using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int healt;
    [SerializeField] protected int damage;
    [SerializeField] protected float speed;

    [SerializeField] protected Transform pointA, pointB;

    private Vector2 currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    public virtual void Patrol()
    {
        if (transform.localPosition == pointA.localPosition)
        {
           currentTarget = pointB.position;
        }
        else if (transform.localPosition == pointB.localPosition)
        {
            currentTarget = pointA.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
}
