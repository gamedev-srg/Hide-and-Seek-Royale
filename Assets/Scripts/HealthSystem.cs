using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int currentHealth;
    private Animator animator;
    [Tooltip("Maximum player health points")]
    [SerializeField] public int maxHealth;
    CharacterController controller;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponentInChildren<Animator>();
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
            var mover = GetComponent<EnemyMover>();
            var agent = GetComponent<NavMeshAgent>();
            mover.enabled = false;
            agent.enabled = false;
        }
        else if (tag == "Player")
        {
            SceneManager.LoadScene("Lose");
        }
        this.enabled = false;
    }
}
