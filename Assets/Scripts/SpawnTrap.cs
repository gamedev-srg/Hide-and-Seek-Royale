using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrap : MonoBehaviour
{
    [SerializeField] GameObject prefabToSpawn;
   float groundOffset= 1.0752042f;
    private float trapYvalue;
    int totalTraps = 2;
    [SerializeField]int currentTraps;
    [SerializeField] GameObject trapIndicator;
    void Start()
    {
        currentTraps = totalTraps;
    }
    
    public void gotTrap()
    {
        currentTraps += totalTraps - currentTraps;
        trapIndicator.GetComponent<MeshRenderer>().enabled = true;
    }
    private GameObject Spawn()
    {
        Vector3 positionOfSpawnedObject = transform.position;
        positionOfSpawnedObject.y = trapYvalue;
        Quaternion rotationOfSpawnedObject = Quaternion.identity;
        GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);
        currentTraps -= 1;
        return newObject;
    }
    // Update is called once per frame
    void Update()
    {   
    

        trapYvalue = transform.position.y-groundOffset ;
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(currentTraps > 0) 
            {
               Spawn();
               if (currentTraps == 0)
               {
                   trapIndicator.GetComponent<MeshRenderer>().enabled = false;
               }
            }
        }
    }
}
