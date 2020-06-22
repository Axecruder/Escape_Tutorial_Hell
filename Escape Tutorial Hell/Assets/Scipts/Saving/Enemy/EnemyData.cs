using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyData
{
    public EnemyType type;
    public float[] position;
    public int direction = 1; //1 = right; -1 = left
}
