using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    private float move;
    private bool facingRight = true;
    private bool isGrounded;
    private int extraJump;
    private Animator anim;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJumpValue;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        extraJump = extraJumpValue;
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        move = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector3(speed * move, rigid.velocity.y);

        //Movement
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
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && extraJump > 0)
        {
            rigid.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.Space)) && extraJump == 0 && isGrounded)
        {

        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;

        transform.localScale = scaler;
    }
}
