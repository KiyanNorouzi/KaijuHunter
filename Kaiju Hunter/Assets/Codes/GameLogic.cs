using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameLogic : MonoBehaviour
{
   bool pause = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKey("p"))
        {
            pause = !pause;

            if(pause == true)
                 PauseGame ();
            else
                ResumeGame ();

        }
 
            
    }


    void PauseGame ()
    {
        Time.timeScale = 0;
    }
    void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
