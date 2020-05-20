using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] protected int healt;
    [SerializeField] protected int damage;
    [SerializeField] protected float speed;

    [SerializeField] protected SpriteRenderer sprite;

    
    private Player player;

    public int Health { get; set; }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Health = this.healt;
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
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
