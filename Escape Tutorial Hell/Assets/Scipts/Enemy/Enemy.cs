using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] protected int healt;
    [SerializeField] protected int damage;
    [SerializeField] protected float speed;

    [SerializeField] protected Transform pointA, pointB;
    [SerializeField] protected SpriteRenderer sprite;

    private Vector2 currentTarget;
    private Player player;

    public int Health { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Health = this.healt;
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ha nincs combat
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.GetComponent<Player>();
            player.Damage();
        }
    }

    public virtual void Damage()
    {
        
    }
}
