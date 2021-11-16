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
        if (currentHealth < maxHealth)
        {
            animator.SetTrigger("damage");
        }
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();

        }
    }
    private void Die()
    {
        animator.SetBool("dead", true);
        controller = GetComponent<CharacterController>();
        if (controller)
        {
            controller.enabled = false;
        }
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
