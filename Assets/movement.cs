using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class movement : MonoBehaviour
{




    // Start is called before the first frame update
   
    //movement code
    private float horizontal;

    public float speed = 8f;
    public float jumpingPower = 8f;
    //private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] Rigidbody2D rb;
    public double movementSpeed = 1f;
    private GameObject platform; // Added to store the platform GameObject



    void Start()
    {





        //Code for finding the platform object
        Transform objectsParent = GameObject.Find("objects").transform;

        if (objectsParent != null)
        {
            // Find the 'platform' GameObject within 'objects'
            Transform platformTransform = objectsParent.Find("platform");

            if (platformTransform != null)
            {
                GameObject platform = platformTransform.gameObject;
                // Now 'platform' is the reference to the 'platform' GameObject
                Debug.Log("Found platform: " + platform.name);
            }
            else
            {
                Debug.LogError("Could not find 'platform' GameObject inside 'objects'.");
            }
        }
        else
        {
            Debug.LogError("Could not find 'objects' GameObject.");
        }
    }

        // Update is called once per frame
        void Update()
    {



 



















        //Movement code

        horizontal = Input.GetAxisRaw("Horizontal");


        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

       if(Mathf.Abs(horizontal) > 0 && isGrounded() && platform == true)
        {


            Flip();
        }
        //Calls the jump method
       jump();

  


    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    public void Flip()
    {

        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() )
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);



        }


        if (Input.GetButtonUp("jump") && rb.velocity.y > 0f)
        {


            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

        }

    }



}
