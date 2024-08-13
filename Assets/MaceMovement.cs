using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaceMovement : MonoBehaviour
{


    public GameObject pointA;
    public GameObject pointB;
    private float speed = 20;
   

    private Rigidbody2D rb;
    private Transform currentPoint;





    public GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {




        Vector2 direction =(currentPoint.position - transform.position).normalized;
        rb.velocity  = new Vector2(rb.velocity.x, direction.y * speed );

        

        if (Mathf.Abs(transform.position.y - currentPoint.position.y) < 0.5f)
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



