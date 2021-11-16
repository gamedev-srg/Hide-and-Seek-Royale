using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    int sleepingDamage = 0;
    int damageToUse;
    [SerializeField] int damage = 1;
    [SerializeField] int sleep;
    private void OnTriggerEnter(Collider other)
    {
        var healthSystem = other.GetComponent<HealthSystem>();
        if (healthSystem)
        {
            healthSystem.takeDamge(damageToUse);
        }
    }
    private void Start()
    {
        damageToUse = sleepingDamage;
        StartCoroutine(initializeTrap(sleep));
    }

    IEnumerator initializeTrap(int sleep)
    {
        yield return new WaitForSeconds(sleep);
        damageToUse = damage; 
    }
}
