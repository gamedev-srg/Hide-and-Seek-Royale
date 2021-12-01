using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    //This scirpt is attached to the spikes BENEATH the trap
    int sleepingDamage = 0; //as to not take damage when spawning traps
    int damageToUse;
    [Tooltip("Damage per spike")]
    [SerializeField] int damage = 1;
    [Tooltip("Sleep spwan time between traps")]
    [SerializeField] int sleep;

    private void OnTriggerEnter(Collider other)
    {
        var healthSystem = other.GetComponent<HealthSystem>(); //if spikes hit something get its health system and damage it.
        if (healthSystem)
        {
            healthSystem.takeDamge(damageToUse);
        }
    }

    private void Start()
    {
        damageToUse = sleepingDamage;
        StartCoroutine(initializeTrap(sleep)); // used to give player time to spawn trap without taking damage.
    }

    IEnumerator initializeTrap(int sleep)
    {
        yield return new WaitForSeconds(sleep);
        damageToUse = damage; 
    }
}
