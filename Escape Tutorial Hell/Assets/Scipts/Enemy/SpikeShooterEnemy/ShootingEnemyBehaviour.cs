﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyBehaviour : Enemy
{
    private EnemyData enemyData;

    //Audio
    private AudioSource audioSource;

    public AudioClip enemyDieClip;
    private float enemyDieVolume = 0.35f;
    protected override void Start()
    {
        base.Start();

        enemyData = new EnemyData
        {
            type = EnemyType.ShooterEnemy
        };
        float[] position = new float[3];
        position[0] = transform.position.x;
        position[1] = transform.position.y;
        position[2] = transform.position.z;
        enemyData.position = position;

        audioSource = GetComponent<AudioSource>();

        StartCoroutine(pushDataWhenLoaderExist());
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public GameObject deadParticleSystem;
    public override void Damage()
    {
        if (deadParticleSystem != null)
        {
            Instantiate(deadParticleSystem, new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z), Quaternion.identity);
        }
        sprite.enabled = false;
        audioSource.PlayOneShot(enemyDieClip, enemyDieVolume);
        Destroy(gameObject,0.2f);
    }

    void OnDestroy()
    {
        if (GetComponentInParent<EnemyLoader>() != null)
        {
            GetComponentInParent<EnemyLoader>().DeleteEnemyData(enemyData);
        }
    }

    IEnumerator pushDataWhenLoaderExist()
    {
        yield return new WaitUntil(() => GetComponentInParent<EnemyLoader>() != null);
        GetComponentInParent<EnemyLoader>().AddEnemyData(enemyData);
    }
}
