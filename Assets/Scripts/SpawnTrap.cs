using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrap : MonoBehaviour
{
    [Tooltip("Which trap I want to spawn, we only have 1 so far")]
    [SerializeField] GameObject prefabToSpawn;
    float groundOffset= 1.0752042f; //calculated in game.
    private float trapYvalue; //how low into the ground we want the trap.
    int totalTraps = 2;
    [Tooltip("Current number of traps")]
    [SerializeField]int currentTraps;
    [Tooltip("This is a gameObject that indicates to the player he has a trap")]
    [SerializeField] GameObject trapIndicator;
    void Start()
    {
        currentTraps = totalTraps;
    }
    
    public void gotTrap() //if we picked up a trap
    {
        currentTraps += totalTraps - currentTraps; //refresh max stacks and make sure the indicator is on.
        trapIndicator.GetComponent<MeshRenderer>().enabled = true;
    }
    private GameObject Spawn() //spawn the trap 
    {
        
        Vector3 positionOfSpawnedObject = transform.position;
        positionOfSpawnedObject.y = trapYvalue; //this will be the only value different, because we want the traps to spawn on the ground, not on the player's height.
        Quaternion rotationOfSpawnedObject = Quaternion.identity;
        GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);
        currentTraps -= 1;
        return newObject;
    }
    // Update is called once per frame
    void Update()
    {   
    

        trapYvalue = transform.position.y-groundOffset ; //correct the trap's height
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(currentTraps > 0) //only spawn if you have traps
            {
               Spawn();
               if (currentTraps == 0)
               {
                   trapIndicator.GetComponent<MeshRenderer>().enabled = false;//disable indicator
               }
            }
        }
    }
}
