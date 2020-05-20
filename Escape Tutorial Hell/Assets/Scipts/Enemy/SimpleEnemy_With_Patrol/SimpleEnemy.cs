using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    public GameObject deadParticleSystem;
    public override void Damage()
    {
        Instantiate(deadParticleSystem, new Vector3(transform.position.x, transform.position.y - 0.2f , transform.position.z) , Quaternion.identity);
        Destroy(transform.parent.gameObject);
    }
}
