using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{



    






    

    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        

        Vector3 newPosition = player.position + offset;
        transform.position = newPosition;



      




































    }
}
