using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    
    NavMeshAgent navMeshAgent;
    [SerializeField] GameObject player;
    [SerializeField] GameObject targets;
    private Transform[] targetList;
    HealthSystem healthSystem;
    [SerializeField] float tolarenceValue = 8f;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        targetList = targets.GetComponentsInChildren<Transform>();
    }
    Transform FindNearestTarget(Transform[] targetList)
    {
        float min_distance = float.MaxValue;
        Transform min_target = targetList[1]; //arbitrary, will likely change later.
        foreach(Transform target in targetList)
        {
            float curr_distance = Vector3.Distance(transform.position, target.transform.position);
            if (curr_distance < min_distance)
            {
                min_distance = curr_distance;
                min_target = target;
            }
        }
        return min_target;
        
    }

    // Update is called once per frame
    void Update()
    {

        //This condition will change later, and behaviour will change once
        // a danger-level system will be implemneted 
        // for example: if(levelDanger.dangerLevel == "red"){...}
        //              elseif(levelDanger.dangerlevel == "yellow){...}
        if (tolarenceValue > Vector3.Distance(player.transform.position, transform.position))
        {
            navMeshAgent.SetDestination(FindNearestTarget(targetList).position);
        }
    }
}
