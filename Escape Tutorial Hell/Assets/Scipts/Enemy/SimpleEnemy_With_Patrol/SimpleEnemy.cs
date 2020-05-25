using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    [SerializeField] protected Transform pointA, pointB;

    private Vector2 currentTarget;
    public float Range = 0;
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    protected override void Update()
    {
        base.Update();
        if (player != null && Range!=0 && Vector2.Distance(transform.position, player.transform.position) < Range)
        {
            if(player.transform.position.x > transform.position.x)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x,transform.position.y), speed * Time.deltaTime);
        }
        else if(transform.position.x < pointA.position.x || transform.position.x > pointB.position.x)
        {
            if (pointA.transform.position.x > transform.position.x)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(pointA.transform.position.x, transform.position.y), speed * Time.deltaTime);
        }
        else
        {
           Patrol();
        }
    }

    public virtual void Patrol()
    {
        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            sprite.flipX = true;
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            sprite.flipX = false;
        }
        transform.position = Vector2.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }

    public GameObject deadParticleSystem;
    public override void Damage()
    {
        if (deadParticleSystem != null)
        {
            Instantiate(deadParticleSystem, new Vector3(transform.position.x, transform.position.y - 0.2f , transform.position.z) , Quaternion.identity);
        }
        Destroy(transform.parent.gameObject);
    }
}
