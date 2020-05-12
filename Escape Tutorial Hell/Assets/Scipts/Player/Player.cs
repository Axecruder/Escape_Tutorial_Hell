﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
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
    [SerializeField] private int health;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJumpValue;

    public int Health { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        extraJump = extraJumpValue;
        anim = GetComponent<Animator>();
        Health = health;
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
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
            Debug.Log("Player Health: " + Health);
            StartCoroutine(InvulnerableTimerRoutine());
        }

        if (Health <= 0)
        {
            StartCoroutine(DeathAnimationRoutine()); 
        }
    }

    public IEnumerator AttackCooldownRoutine()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    public IEnumerator DeathAnimationRoutine()
    {
        anim.SetBool("IsDead", true);
        yield return new WaitForSeconds(0.8f);
        gameObject.SetActive(false);
    }

    public IEnumerator InvulnerableTimerRoutine()
    {
        invulnerable = true;
        yield return new WaitForSeconds(invulnerableTimer);
        invulnerable = false;
    }
}