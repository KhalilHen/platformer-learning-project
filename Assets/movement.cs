using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
   
    //movement code
    private float horizontal;

    private float speed = 8f;
    private float jumpingPower = 8f;
    //private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] Rigidbody2D rb;
    public double movementSpeed = 1f;

    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {




        





















        //Movement code

        horizontal = Input.GetAxisRaw("Horizontal");


        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        //Calls the jump method
       jump();

        //calls the flip method
        Flip();


    }


    public void Flip()
    {

        if (isFacingRight && horizontal < 0f && groundCheck || !isFacingRight && horizontal > 0f   )
        {

            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;


        }
    }

    private bool isGrounded()
    {

        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }

    public void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);



        }


        if (Input.GetButtonUp("jump") && rb.velocity.y > 0f)
        {


            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

        }

    }



}
