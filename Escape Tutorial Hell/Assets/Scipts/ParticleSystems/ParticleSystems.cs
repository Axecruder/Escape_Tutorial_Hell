﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystems : MonoBehaviour
{
    public float timeToAutoDestroy;
    // Start is called before the first frame update
    void Start()
    {
        if (timeToAutoDestroy != 0)
        {
            Destroy(gameObject, timeToAutoDestroy);
        }
    }
}
