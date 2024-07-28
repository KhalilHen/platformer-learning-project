using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBox : MonoBehaviour
{

    public PowerupEffect powerupEffect;
    private void OnTriggerEnter2D(Collider2D collison)


    {
        Destroy(gameObject);
        powerupEffect.apply(collison.gameObject);
    }
}