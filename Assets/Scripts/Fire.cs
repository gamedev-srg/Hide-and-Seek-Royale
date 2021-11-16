using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    //Script to control the gunshots
    //used for correction of rays from camera to world
    private float cameraOffset = 0.5f;
    int maxRayDistance = 100;
    //fire rate
    [SerializeField] private float fireRate = 5;
    //gunshot damage
    [SerializeField] private int damage = 1;
    private float nextFireTime;

    //used to display muzzleflash
    [SerializeField] ParticleSystem muzzleFlash;
     Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //player rig animation
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Time.time >= nextFireTime)
        {   
            if (Input.GetButton("Fire1"))
            { //mouse left and ctrl to  shoot
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
   }
    private void Shoot() {
       
        //play particle effect
        muzzleFlash.Play();
        //play attack animation
        animator.SetTrigger("attack");
        //ry from main camera to where i'm looking in my reticle, this will be the path of the bullet
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * cameraOffset);
       // Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);
        RaycastHit hitInfo;
        //if ray hit something with a heatlh System, damage it.
        if(Physics.Raycast(ray, out hitInfo, maxRayDistance))
        {
            var healthSystem = hitInfo.collider.GetComponent<HealthSystem>();
            if (healthSystem)
            {
                healthSystem.takeDamge(damage);
               
            }
        }
    }
}
