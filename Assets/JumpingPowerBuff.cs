using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Powerups/jumpingpower")]

public class JumpingPowerBuff : PowerUpEffect
{
    // Start is called before the first frame update
    public float amount;
    public override void Apply(GameObject target)
    {

        movement movementComponent = target.GetComponent<movement>();
        if (movementComponent != null)
        {
            movementComponent.jumpingPower += amount;
        }
        else
        {
            Debug.LogError("Movement component not found on target.");
        }
    }
    }
