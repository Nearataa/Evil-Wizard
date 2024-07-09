using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 7.5f;

    [Header("Jump")]
    [SerializeField] private float JumpForce = 5f;
    [SerializeField] private float JumpTime = 0.35f;



    private Rigidbody2D rb;
    private float moveInput;
    private Animator anim;

    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    private bool isFacingRight;

    private bool Jumping;
    private bool isFalling;
    private float jumpTimeCounter;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isFacingRight = true;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Jump();
        
    }
    #region Movement
    private void Move()
    {
        moveInput = UserInput.instance.moveInput.x;

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        if (moveInput != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if (!isFacingRight && moveInput > 0)
        {
            Flip();
        }
        else if (isFacingRight && moveInput < 0)
        {
            Flip();
        }
       
    }


    public void Jump()
    {
        if (UserInput.instance.controls.Jumping.Jump.WasPressedThisFrame() && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            jumpTimeCounter = JumpTime;
            Jumping = true;
        }
        anim.SetBool("isJumping", !isGrounded());
        if (UserInput.instance.controls.Jumping.Jump.IsPressed())
        {
            if (jumpTimeCounter > 0 && Jumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                Jumping = false;
            }
        }
        if (UserInput.instance.controls.Jumping.Jump.WasReleasedThisFrame())
        {
            Jumping = false;
        }
    }
    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
  
    #endregion






}
