using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class actionButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public void playAgain()
    {

        SceneManager.LoadSceneAsync(1);

    }
    public void goBackToMainmenu()
    {


        SceneManager.LoadSceneAsync(0);
    }
}
