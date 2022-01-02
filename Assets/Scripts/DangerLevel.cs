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
    [SerializeField] bool isVisible = false;
    bool flagEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        dangerLevel = "green";
    }

    //LOS = Line Of Sight
    //checks if the target is in LineOfSight of the enemy
    bool isInLos()
    {
        isVisible = GetComponentInChildren<Renderer>().isVisible;
        return isVisible;
      
    }

    public string getDangerLevel()
    {
      
        return dangerLevel; 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log(Vector3.Distance(other.transform.position,transform.position));
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
