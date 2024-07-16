using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBox : MonoBehaviour
{

    public enum PowerUp
    {

        Speed 

    }
    public PowerUp powerups;

    public float AmountToGive = 5;

    private movement player;

    private void Awake()
    {
        player = FindObjectOfType<movement>();

    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {

            switch (powerups)
            {
                case PowerUp.Speed:
                    player.movementSpeed += AmountToGive;

                    break;


                default:
                    break;
            }
      
            }
        Destroy(gameObject);
    }


    // Start is called before the first frame update

    [SerializeField] Rigidbody2D rigidbody2D;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
