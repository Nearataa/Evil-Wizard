using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float Move;

    public float speed;
    public float jump;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    private Animator anim;

    private bool isFacingRight;

    void Start()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(Move * speed, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump * 10));
        }

        if (Move != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

            anim.SetBool("isJumping", !isGrounded());
      
        if (!isFacingRight && Move > 0)
        {
            Flip();
        }else if(isFacingRight && Move < 0)
        {
            Flip();
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
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


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        Vector3 normal = collision.GetContact(0).normal;
    //        if (normal == Vector3.up)
    //        {
    //            grounded = true;
    //        }
            
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        grounded = false;
    //    }
    //}
}
