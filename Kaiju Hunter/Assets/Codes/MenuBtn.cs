using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtn : MonoBehaviour
{
 
    public GameObject menu;

 
    void Start()
    {
        menu.SetActive(false);
    }  



    public void ExitGame()
    {
        Application.Quit(); 
    }


    public void StopGame()
    {
        Time.timeScale=0;
        menu.SetActive(true);
    }

    public void resumeGame()
    {
        Time.timeScale=1;
        menu.SetActive(false);
    }

    public void restartGame(){
      Time.timeScale=1;
      SceneManager.LoadScene(0);
    }

}
