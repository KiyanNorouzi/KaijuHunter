using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{

    public GameObject Boss;
    public GameObject endGameSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss != null){
            endGameSprite.SetActive(false);
        }else{
            endGameSprite.SetActive(true);
            Destroy(Boss,5f);
             SceneManager.LoadScene(0);
        }
          
   }  
        
    
}
