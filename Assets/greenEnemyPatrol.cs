using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class greenEnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed = 2f;
    public float jumpForce = 5f;
    public float jumpInterval = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private Transform currentPoint;
    private float nextJumpTime;

    // Code for kill character
    public GameObject player;
    public Transform respawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPoint = pointB.transform;
        animator.SetBool("isRunning", true);

        // Initialize next jump time
        nextJumpTime = Time.time + jumpInterval;
    }
    // Update is called once per frame
    void Update()
    {

        Vector2 direction = (currentPoint.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

        // Check if the enemy needs to change direction
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
        {
            currentPoint = (currentPoint == pointB.transform) ? pointA.transform : pointB.transform;
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
    return Physics2D.OverlapCircle(transform.position - new Vector3(0, 0.5f, 0), 0.2f, LayerMask.GetMask("Ground"));
}

private void OnCollisionEnter2D(Collision2D other)
{
    if (other.gameObject.CompareTag("Player"))
    {
       player.transform.position = respawnPoint.position;


    }
}
}
