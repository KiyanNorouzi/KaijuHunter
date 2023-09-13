using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
//Variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;


     public Joystick joystickMovement;
     
    
    
    //Refrences
    private CharacterController controller;


    private Animator anim;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponent<Animator>();
    }
    
    

    // Update is called once per frame
    void Update()
    {
       
        Move();
    }

  //moveDirection = (forward * joystickMovement.Vertical + right * joystickMovement.Horizontal).normalized;
 
    private void Move()
    {
 
        
        
        float MoveZ = Input.GetAxis("Vertical");    

        moveDirection = new Vector3(0, 0, joystickMovement.Vertical);
        //moveDirection = new Vector3(0, 0, MoveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = walkSpeed;
                Walk();

            }else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {   
                moveSpeed = runSpeed;
                Run();
                
            }else if (moveDirection == Vector3.zero)
            { 
                Debug.Log("Idle");
                Idle();
            }
            
            moveDirection *= moveSpeed;
            
 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Jump();
            StartCoroutine(Jump());
            Debug.Log("test");
        }
     
        controller.Move(moveDirection * Time.deltaTime);
        //velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    private void Idle()
    {
        Debug.Log("Idle");
         anim.SetFloat("Speed",0.0f);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        Debug.Log("Walk");
        anim.SetFloat("Speed",0.4f,0.1f,Time.deltaTime);
       
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        Debug.Log("Run");
        anim.SetFloat("Speed",1f,0.1f,Time.deltaTime);
        
    }

    private IEnumerator Jump()
    {
        //velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        
        anim.SetLayerWeight(anim.GetLayerIndex("Jump Layer"),1);
        anim.SetTrigger("Jump");

        yield return new WaitForSeconds(1.4f);
        anim.SetLayerWeight(anim.GetLayerIndex("Jump Layer"),0);
    }
    
    
}