using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
     public int currentHealth;
    private Animator animator;
    [SerializeField] public int maxHealth;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamge(int damage)
    {
        if (damage > 0)
        {
            if (currentHealth <= maxHealth) //for testing purposes, but it doesn't affect the code.
            {
                animator.SetTrigger("damage"); // if we took damage that is greater than 0, play the hurt animation
            }
            //reduce health, and die if reached 0
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Die();

            }
        }
    }
    private void Die()
    {
        //play die animation
        animator.SetBool("dead", true);
        //disable character controller.
        controller = GetComponent<CharacterController>();
        if (controller)
        {
            controller.enabled = false;
        }
        //killChild in the enemy parent object.
        if(tag == "Enemy")
        {
            var parent = transform.parent.GetComponent<checkEnding>();
            parent.killChild();
        }
        else if (tag == "Player")
        {
            Application.Quit();
        }
    }
}
