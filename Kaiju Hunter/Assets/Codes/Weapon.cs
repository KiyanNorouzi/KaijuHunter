using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line to import the UnityEngine.UI namespace


public class Weapon : MonoBehaviour
{

    public AudioSource audioSource;
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;
    
    [SerializeField] private Transform bulletPoint;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;


    public int maxAmmo = 30;
    public int MaxMissile = 20;

    public int currentAmmo;
    public int currentMissile;

    public TrailRenderer TR;
    public Transform gunBarrel;

 
    public float mouseSensitivity = 2.0f; 
    public float minYRotation = -60.0f; 
    public float maxYRotation = 60.0f; 
    private float rotationY = 0.0f; 
    private float cameraRotationX = 0.0f; 
    private Transform cameraTransform; 
    private bool isAiming = false;
    public Joystick joystick;
    public Text uiText;
    public Text MissileText;

    void Start()
    {
       currentAmmo = maxAmmo;
       currentMissile = MaxMissile;

       Cursor.lockState = CursorLockMode.Locked; 
       Cursor.visible = false; 
       cameraTransform = Camera.main.transform;

        uiText.text = currentAmmo.ToString();
        MissileText.text = currentMissile.ToString();
    }


    void Update()
    {
    
        Vector2 mouseInput = new Vector2(joystick.Horizontal,joystick.Vertical) * mouseSensitivity;
        //Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSensitivity;
        
        rotationY += mouseInput.x;
        transform.localRotation = Quaternion.Euler(0, rotationY, 0);

        cameraRotationX -= mouseInput.y;
        cameraRotationX = Mathf.Clamp(cameraRotationX, minYRotation, maxYRotation);

        cameraTransform.localEulerAngles = new Vector3(cameraRotationX, 0, 0);


        // Aiming
        if (Input.GetMouseButtonDown(1)) // Right mouse button to aim
        {
            isAiming = true;
            Cursor.lockState = CursorLockMode.None; 
            Cursor.visible = false; 
        }
        else if (Input.GetMouseButtonUp(1)) // Release right mouse button to stop aiming
        {
            isAiming = false;
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false; 
        }

        /*
        // Shooting with mouse
        if (Input.GetMouseButtonDown(0)&& Time.time >= nextTimeToFire) // Left mouse button to shoot
        {
           nextTimeToFire = Time.time + 1f / fireRate;

            if (currentAmmo > 0)
            {
                currentAmmo--;
                Shoot();
                Debug.Log(currentAmmo);
                
            }
        }
        */
    }


    public void Shoot()
    {
        
        uiText.text = currentAmmo.ToString();

        if ( Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;

            if (currentAmmo > 0){
                currentAmmo--;

                muzzleFlash.Play();
                audioSource.Play();
                Debug.Log("SHOOT");

                RaycastHit hit;
                if (Physics.Raycast(bulletPoint.transform.position, bulletPoint.transform.forward, out hit, range))
                {
        
                    Debug.Log(hit.transform.name);

                    EnemyAI target = hit.transform.GetComponent<EnemyAI>();
                    if (target != null)
                    {
                        Debug.Log("Death");
                        target.TakeDamage(damage);
                    }

                    if (hit.rigidbody != null)
                    {
                        hit.rigidbody.AddForce(-hit.normal * impactForce);
                    }

                    GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impactGO,2f);

        
                }

                    var bullet = Instantiate(TR, gunBarrel.position, Quaternion.identity);
                    bullet.AddPosition(gunBarrel.position);
                    {
                        bullet.transform.position = transform.position + (bulletPoint.transform.forward * 200);
                    }
                    Destroy(bullet,0.5f);
                      
            }
        }


    }


    public void LunchMissile()
    {
        
        MissileText.text = currentMissile.ToString();

        if ( Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;

            if (currentMissile > 0){
                currentMissile--;

                muzzleFlash.Play();
                audioSource.Play();
                Debug.Log("SHOOT");

                RaycastHit hit;
                if (Physics.Raycast(bulletPoint.transform.position, bulletPoint.transform.forward, out hit, range))
                {
        
                    Debug.Log(hit.transform.name);

                    EnemyAI target = hit.transform.GetComponent<EnemyAI>();
                    if (target != null)
                    {
                        Debug.Log("Death");
                        target.TakeDamage(damage);
                    }

                    if (hit.rigidbody != null)
                    {
                        hit.rigidbody.AddForce(-hit.normal * impactForce);
                    }

                    GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impactGO,2f);

        
                }

                    var bullet = Instantiate(TR, gunBarrel.position, Quaternion.identity);
                    bullet.AddPosition(gunBarrel.position);
                    {
                        bullet.transform.position = transform.position + (bulletPoint.transform.forward * 200);
                    }
                    Destroy(bullet,0.5f);
                      
            }
        }


    }

    
    
}
