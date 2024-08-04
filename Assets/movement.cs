using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 8f;
    private bool isFacingRight = true;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] Rigidbody2D rb;
    private GameObject platform;

    void Start()
    {
        Transform objectsParent = GameObject.Find("objects").transform;
        if (objectsParent != null)
        {
            Transform platformTransform = objectsParent.Find("platform");
            if (platformTransform != null)
            {
                platform = platformTransform.gameObject; // Assign the platform reference
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

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (Mathf.Abs(horizontal) > 0 && isGrounded() && platform != null)
        {
            Flip();
        }

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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Handle character death
            Die();
        }
    }

    private void Die()
    {
        // Handle death logic here
        Debug.Log("Character has died!");
        // Optionally, you can reload the scene or disable the character
        // UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        // Or
        // gameObject.SetActive(false);
    }
}
