using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed = 2f;
    public float jumpForce = 5f;  // Adjust the jump force as needed
    public float jumpInterval = 5f; // Time in seconds between jumps

    private Rigidbody2D rb;
    private Animator animator;
    private Transform currentPoint;
    private float nextJumpTime; // Time when the next jump should occur

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPoint = pointB.transform;
        animator.SetBool("isRunning", true);

        // Initialize next jump time
        nextJumpTime = Time.time + jumpInterval;
    }

    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        // Check if the enemy needs to change direction
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
        {
            if (currentPoint == pointB.transform)
            {
                currentPoint = pointA.transform;
            }
            else
            {
                currentPoint = pointB.transform;
            }
        }

        // Handle jumping
        if (Time.time >= nextJumpTime && IsGrounded())
        {
            Jump();
            nextJumpTime = Time.time + jumpInterval; // Set the next jump time
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private bool IsGrounded()
    {
        // Check if the enemy is grounded by overlapping a small circle
        return Physics2D.OverlapCircle(transform.position - new Vector3(0, 0.5f, 0), 0.2f, LayerMask.GetMask("Ground"));
    }
}
