using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaceMovement : MonoBehaviour
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





    public GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPoint = pointB.transform;
        animator.SetBool("isRunning", true);
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

  
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //layer.transform.position = respawnPoint.position;

            SceneManager.LoadSceneAsync(2);

        }
    }
}



