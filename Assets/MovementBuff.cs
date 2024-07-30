using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(menuName = "Powerups/HeatlhBuff") ]

public class MovementBuff : PowerUpEffect
{

    public float amount;
    public override void Apply(GameObject target)
    {

        movement movementComponent = target.GetComponent<movement>();
        if (movementComponent != null)
        {
            // Update the speed
            movementComponent.speed += amount;
        }
        else
        {
            Debug.LogError("Movement component not found on target.");
        }
    }
}
