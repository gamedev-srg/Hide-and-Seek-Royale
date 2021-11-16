using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPowerup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
                var spawnTrap = other.GetComponent<SpawnTrap>();
                spawnTrap.gotTrap();
                Destroy(gameObject);
            
        }
    }
            // Update is called once per frame
            void Update()
    {
        
    }
}
