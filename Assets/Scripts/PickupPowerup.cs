using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPowerup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //if player collides with the trap, pick it up
        if (other.tag == "Player")
        {
                var spawnTrap = other.GetComponent<SpawnTrap>();
                spawnTrap.gotTrap();
                Destroy(gameObject);
        }
    }
}
