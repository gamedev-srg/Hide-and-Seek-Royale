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
    bool flagEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        dangerLevel = "green";
    }

    public string getDangerLevel()
    {
      
        return dangerLevel; 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            flagEnter = true;
            StartCoroutine(updateDangerLevel(other));
            Debug.Log("entered danger zone");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            flagEnter = false;
            dangerLevel = "green";
            Debug.Log("exited danger zone");
        }
    }
    private IEnumerator updateDangerLevel(Collider other)
    {
        while (flagEnter)
        { 
            float distance = Vector3.Distance(this.transform.position, other.transform.position);
            //Debug.Log(distance);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
