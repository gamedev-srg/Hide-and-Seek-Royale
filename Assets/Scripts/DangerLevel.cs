using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerLevel : MonoBehaviour
{
    public float yellowThreshHold = 20f;
    public float redThreshHold = 10f;
    public string dangerLevel;
    private float timeBetweenChecks = 1f;
    [SerializeField] GameObject DangerCause;
    [SerializeField]public bool isVisible = false;
    bool flagEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        dangerLevel = "green";
        StartCoroutine(updateDangerLevel(DangerCause));
    }

    //LOS = Line Of Sight
    //checks if the target is in LineOfSight of the enemy

    public string getDangerLevel()
    {
      
        return dangerLevel; 
    }

           
          
        
    
   
    private IEnumerator updateDangerLevel(GameObject other)
    {
        while (true)
        {
            float distance = Vector3.Distance(this.transform.position, other.transform.position);
            Debug.Log(distance);
            if (distance < redThreshHold)
            {
                dangerLevel = "red";

            }
            else if (distance < yellowThreshHold)
            {
                dangerLevel = "yellow";

            }
            else
            {
                dangerLevel = "green";
                flagEnter = false;
            }
            yield return new WaitForSeconds(timeBetweenChecks);
        }
        
    }
}
