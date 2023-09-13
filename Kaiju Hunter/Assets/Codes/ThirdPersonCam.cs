using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
  [Header("Refrences")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    //public Rigidbody rb;
    
    public float rotationSpeed;

    public Transform combatLookAt;

    public GameObject thirdPersonCam;


    public CameraStyle currentStyle;
    
    
    public enum CameraStyle
    {
        Basic,
        Combat,
        Topdown
    }

     

        
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SwitchCameraStyle(CameraStyle.Basic);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) SwitchCameraStyle(CameraStyle.Basic);
        
        //Rotate Orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;


        if (currentStyle == CameraStyle.Basic || currentStyle == CameraStyle.Topdown)
        {
            //rotate player object
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
            {
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            }
        }

        else if (currentStyle == CameraStyle.Combat)
        {

            Vector3 dirToCombatLookAt = combatLookAt.position -
                                        new Vector3(transform.position.x, combatLookAt.position.y,
                                            transform.position.x);

            orientation.forward = dirToCombatLookAt.normalized;
            playerObj.forward =  dirToCombatLookAt.normalized;
          
        }
        

    }

    private void SwitchCameraStyle(CameraStyle _newStyle)
    {

        thirdPersonCam.SetActive(false);

        if(_newStyle == CameraStyle.Basic) thirdPersonCam.SetActive(true);

        currentStyle = _newStyle;
    }
}