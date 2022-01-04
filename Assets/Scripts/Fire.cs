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
    [Tooltip("Amount of ammunition in magazine")]
    [SerializeField] private const int magazineSize = 10;
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
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);
        RaycastHit hitInfo;
        //if ray hit something with a heatlh System, damage it.
        if(Physics.Raycast(ray, out hitInfo, maxRayDistance))
        {
            //check if we hit something that isn't an enemy hit wont register
            string firstHitName = "";
            if (firstHitName == "")
            {
                firstHitName = hitInfo.collider.gameObject.name;
                Debug.Log(firstHitName);
            }
            //unless we hit an invisble object for game logic and So you can shoot through tress 
            if (firstHitName.Contains("Enemy") || firstHitName.Contains("Sphere") || firstHitName.Contains("Terrain"))
            {
                Debug.Log("reached enemy");
                var healthSystem = hitInfo.collider.GetComponent<HealthSystem>();
                if (healthSystem)
                {
                    healthSystem.takeDamge(damage);
                }
            }
                
            
        }
    }

    public void addAmmo()
    {
        ammunition += magazineSize;
        ammoText.text = "Ammo: " + ammunition.ToString();
    }
}
