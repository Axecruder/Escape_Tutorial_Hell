using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamageable
{
    private static int CONSTANT_INIT_HEALTH = 5; 
    private Rigidbody2D rigid;
    private float move;
    private bool facingRight = true;
    private bool isGrounded;
    private int extraJump;
    private Animator anim;
    private bool canAttack = true;
    private bool invulnerable = false;

    [SerializeField] private float invulnerableTimer = 1f;
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] public int Health { get; set; }

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJumpValue;

    public GameObject moveParticleSystem;


    // Start is called before the first frame update
    void Start()
    {
        //init with constants
        Health = CONSTANT_INIT_HEALTH;
        UIManager.initHealth = CONSTANT_INIT_HEALTH;
        //Enable saving function and loadData if enables
        SaveSystem.player = this;
        SaveSystem.LoadPlayer();

        rigid = GetComponent<Rigidbody2D>();
        extraJump = extraJumpValue;
        anim = GetComponent<Animator>();

        //update UI
        UIManager.Instance.UpdateLives(Health);
    }

    void FixedUpdate()
    {
        if (moveParticleSystem != null && (isGrounded && move != 0))
        {
            Instantiate(moveParticleSystem, new Vector3(transform.position.x, transform.position.y - 0.55f , transform.position.z), Quaternion.identity);
        }
    }

    private void Update()
    {
        Movement();
        if (Input.GetMouseButtonDown(0) && isGrounded && canAttack)
        {
            anim.SetTrigger("Attack");
            canAttack = false;
            StartCoroutine(AttackCooldownRoutine());
        }
    }

    void Movement()
    {
        //Movement
        move = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector3(speed * move, rigid.velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
        // Run animation
        if (move == 0)
        {
            anim.SetBool("IsRunning", false);
        }
        else
        {
            anim.SetBool("IsRunning", true);
        }

        // JUMP
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isGrounded)
        {
            extraJump = extraJumpValue;
            anim.SetBool("IsJumping", false);
        }
        else
        {
            anim.SetBool("IsJumping", true);
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && extraJump > 0)
        {
            rigid.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && extraJump == 0 && isGrounded)
        {
            rigid.velocity = Vector2.up * jumpForce;
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;

        transform.localScale = scaler;
    }

    public void Damage()
    {
        if (!invulnerable)
        {
            Health--;
            anim.SetTrigger("Hit");
            UIManager.Instance.UpdateLives(Health);
            StartCoroutine(InvulnerableTimerRoutine());
        }

        if (Health == 0)
        {
            StartCoroutine(DeathRoutine());
        }
    }

    public IEnumerator AttackCooldownRoutine()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    public IEnumerator DeathRoutine()
    {
        anim.SetBool("IsDead", true);
        yield return new WaitForSeconds(0.8f);
        gameObject.SetActive(false);
        SaveSystem.DeleteSave();
        SceneManager.LoadScene("LaunchScene");
    }

    public IEnumerator InvulnerableTimerRoutine()
    {
        invulnerable = true;
        yield return new WaitForSeconds(invulnerableTimer);
        invulnerable = false;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if ((whatIsGround.value & 1 << c.gameObject.layer) == 1 << c.gameObject.layer)
        {
            for(int i =0; i < 3; i++)
            {
                Instantiate(moveParticleSystem, new Vector3(transform.position.x, transform.position.y - 0.55f, transform.position.z), Quaternion.identity);
            }
        }
    }
}