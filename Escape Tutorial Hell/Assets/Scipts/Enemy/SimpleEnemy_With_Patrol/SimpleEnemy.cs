using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    [SerializeField] protected Transform pointA, pointB;

    private Vector2 currentTarget;

    protected override void Update()
    {
        base.Update();
        Patrol();
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
