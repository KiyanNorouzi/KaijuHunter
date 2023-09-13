using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public float health;


    public HealthBar healthBar;

    private Animator anim;
    public GameObject wasted;

    public PlayerMovement player;
    public Camera mainCamera;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        healthBar.SetMaxHealth(100);
      
    }
 

    public void TakeDamage(float _damage){    
        health -= _damage;
		healthBar.SetHealth(health);

        if (health <= 0f)
        {  
            Invoke(nameof(Death),0f);
            player.gameObject.GetComponent<PlayerMovement>().enabled = false;
            player.gameObject.GetComponent<Weapon>().enabled = false;
            mainCamera.gameObject.GetComponent<ThirdPersonCam>().enabled = false;
            wasted.SetActive(true);
           
        }
    }

    private void Death(){   
        
        anim.SetFloat("Death",1f,0.1f,Time.deltaTime);
        Destroy(gameObject,5f);
        SceneManager.LoadScene(0);
    }
}
