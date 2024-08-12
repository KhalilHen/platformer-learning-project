using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{



    

//    private Vector3 offset = new Vector3(0f, 0f, -10f);
  //  private float smoothTime = 0.25f;
    //private Vector3 velocity = Vector3.zero;
   // [SerializeField] private Transform target;
    // Start is called before the first frame update




    //Unity docs code

    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        //unity docs code

        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position

       // transform.position.x = Player.transform.position.x;
       // transform.position.y = Player.transform.position.y;
        //transform.position.z = offset.z;



        //video tutoril code


        // Vector3 targetPosition = target.position = offset;
        //   transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity,  smoothTime);






































    }
}
