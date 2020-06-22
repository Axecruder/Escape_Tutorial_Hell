using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    private GameObject playerTarget;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float fallSpeed = 2.0f;
    public int diretion; //1 = right; -1 = left
    private EnemyData enemyData;

    private bool isGrounded = false;

    override protected void Start()
    {
        base.Start();
        enemyData = new EnemyData
        {
            type = EnemyType.SimpleEnemy_With_Patrol
        };
        float[] position = new float[3];
        position[0] = transform.position.x;
        position[1] = transform.position.y;
        position[2] = transform.position.z;
        enemyData.position = position;

        StartCoroutine(pushDataWhenLoaderExist());
    }

    void Awake()
    {
        playerTarget = GameObject.FindWithTag("Player");
        diretion = 1;
    }

    protected override void Update()
    {
        base.Update();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        
        //UP - DOWN movement
        if (isGrounded)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y + 0.5f), Time.deltaTime * fallSpeed);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x,transform.position.y - 0.5f),Time.deltaTime * fallSpeed);
        }

        // LEFT - RIGHT movement
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + diretion, transform.position.y), Time.deltaTime * speed);
        if (diretion==1)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        refreshEnemyData();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if(collision.transform.tag.Equals("pointLeft"))
        {
            diretion = 1;
        }else if(collision.transform.tag.Equals("pointRight"))
        {
            diretion = -1;
        }
    }
    public GameObject deadParticleSystem;
    public override void Damage()
    {
        if (deadParticleSystem != null)
        {
            Instantiate(deadParticleSystem, new Vector3(transform.position.x, transform.position.y - 0.2f , transform.position.z) , Quaternion.identity);
        }
        Destroy(gameObject);
    }

    private void refreshEnemyData()
    {
        float[] position = new float[3];
        position[0] = transform.position.x;
        position[1] = transform.position.y;
        position[2] = transform.position.z;
        enemyData.position = position;
        enemyData.direction = diretion;
    }

    void OnDestroy()
    {
        if (GetComponentInParent<EnemyLoader>()!=null)
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
