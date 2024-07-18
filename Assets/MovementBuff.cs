using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Powerups/MovementBuff")]

public class MovementBuff : PowerupEffect


{

    public float amount;
    // Start is called before the first frame update
    public override void apply(GameObject target)
    {
        target.GetComponent<movement>().movementSpeed  += amount;    




    }
}
