using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    //Script to control the gunshots
    //used for correction of rays from camera to world
    private float cameraOffset = 0.5f;
    int maxRayDistance = 100;
    [Tooltip("Weapon's fire rate in float value")]
    [SerializeField] private float fireRate = 5;
    [Tooltip("Weapon damage, each point is equal to a player health point")]
    [SerializeField] private int damage = 1;
    private float nextFireTime;
    [Tooltip("Muzzle flash display object")]
    [SerializeField] ParticleSystem muzzleFlash;
    Animator animator;
    [Tooltip("Weapon's ammunition")]
    [SerializeField] private int ammunition = 30;
    [Tooltip("Text Object to change ammunition")]
    [SerializeField] Text ammoText;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        ammoText.text = "Ammo: " + ammunition.ToString();
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {   
            if (Input.GetButton("Fire1") && ammunition > 0)
            { 
                //mouse left and ctrl to  shoot
                Shoot();
                nextFireTime = Time.time + fireRate;
                ammunition--;
                ammoText.text = "Ammo: " + ammunition.ToString();
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
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);
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
