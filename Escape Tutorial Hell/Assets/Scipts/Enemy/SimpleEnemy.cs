using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    public override void Damage()
    {
        Destroy(gameObject);
    }
}
