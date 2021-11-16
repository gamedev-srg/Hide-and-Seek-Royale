using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private float cameraOffset = 0.5f;
    [SerializeField] private float fireRate = 5;
    [SerializeField] private int damage = 1;
    private float nextFireTime;

    [SerializeField] ParticleSystem muzzleFlash;
     Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Time.time >= nextFireTime)
        {
            if (Input.GetButton("Fire1"))
            { 
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
   }
    private void Shoot() {
       

        muzzleFlash.Play();
        animator.SetTrigger("attack");
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * cameraOffset);
       // Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, 100))
        {
            var healthSystem = hitInfo.collider.GetComponent<HealthSystem>();
            if (healthSystem)
            {
                healthSystem.takeDamge(damage);
               
            }
        }
    }
}
