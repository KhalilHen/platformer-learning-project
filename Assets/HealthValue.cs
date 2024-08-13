using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class HealthValue : MonoBehaviour
{
    //test
    public static int health = 3;

    public Text healthText;
    public int maxHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (healthText == null)
        {
            Debug.LogError("Health Text UI is not assigned.");
        }
        else
        {

            healthText.text = "Health: " + health;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }



    }
}
