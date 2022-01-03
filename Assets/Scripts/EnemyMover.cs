using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    //lock the script from constantly changing currentUnitAtTarget.
    public bool locked = false;
    [Tooltip("Player Object for the enemy mover")]
    [SerializeField] GameObject player;
    [Tooltip("Target Objects for the enemy mover")]
    [SerializeField] GameObject targets;
    private Transform[] targetList;
    HealthSystem healthSystem;
    [Tooltip("Danger level for the enemy mover")]
    [SerializeField] DangerLevel dangerLevel;
    DangerLevel targetLevel;
    GameObject lastTarget;
    Vector3 startingPos;
    Animator animator;
    [SerializeField] float startingSpeed;
    bool redTargetLock = false;
    float speedToUse;
    float redSpeedIncrease = 1.2f;
    [SerializeField] public float maxDistance = 45f; 
    // Start is called before the first frame update
    void Start()
    {

        startingPos = transform.position;
        animator = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        dangerLevel = GetComponent<DangerLevel>();
        targetList = targets.GetComponentsInChildren<Transform>();
        navMeshAgent.speed = speedToUse;
        speedToUse = startingSpeed;
    }

    public bool inRadius(Transform target)
    {
        if (Vector3.Distance(target.position, startingPos) < maxDistance)
            return false;
        return true;
    }

    
    Transform FindNearestSafeTarget(Transform[] targetList)
    {
        string currentLevel = "";
        float min_distance = float.MaxValue;
        Transform min_target = targetList[1]; //arbitrary, will likely change later.
        foreach(Transform target in targetList)
        {
            float curr_distance = Vector3.Distance(transform.position, target.transform.position);
            var targetDanger = target.GetComponent<DangerLevel>();
            if (targetDanger)
            {
                currentLevel = target.GetComponent<DangerLevel>().dangerLevel;
                TargetAvailability availability = target.gameObject.GetComponent<TargetAvailability>();
                bool isAvailable = availability.isAvailable(target.gameObject);
                
                //if target is the closest (disregrard LOS), and is safe in terms of color, and it is free of other players and it's in the radius
                if ((curr_distance < min_distance) && currentLevel.Equals("green") && isAvailable && inRadius(target) && !targetDanger.isVisible)
                {
                    
                    min_distance = curr_distance;
                    min_target = target;
                }
            }
        }
        Debug.Log(this.name + " is at danger level " + dangerLevel.dangerLevel + " current target is " + min_target);
        return min_target;
    }
    Transform FindNearestTargetNotInSight(Transform[] targetList)
    {
        string currentLevel = "";
        float min_distance = float.MaxValue;
        Transform min_target = targetList[1]; //arbitrary, will likely change later.
        foreach (Transform target in targetList)
        {
            float curr_distance = Vector3.Distance(transform.position, target.transform.position);
            var targetDanger = target.GetComponent<DangerLevel>();
            if (targetDanger)
            {
                currentLevel = target.GetComponent<DangerLevel>().dangerLevel;
                TargetAvailability availability = target.gameObject.GetComponent<TargetAvailability>();
                bool isAvailable = availability.isAvailable(target.gameObject);

        
                if ((curr_distance < min_distance) && isAvailable && !targetDanger.isVisible && inRadius(target))
                {

                    min_distance = curr_distance;
                    min_target = target;
                }
            }
        }
        Debug.Log(this.name + " is at danger level " + dangerLevel + " current target is " + min_target);
        return min_target;
    }

    Transform FindSafeTargetNotRed(Transform[] targetList)
    {
        string currentLevel = "";
        Transform min_target = targetList[1]; //arbitrary, will likely change later.
        List<Transform> okTargets = new List<Transform>();
        foreach (Transform target in targetList)
        {
            var targetDanger = target.GetComponent<DangerLevel>();
            if (targetDanger)
            { 
                currentLevel = target.GetComponent<DangerLevel>().dangerLevel;
                TargetAvailability availability = target.gameObject.GetComponent<TargetAvailability>();
                bool isAvailable = availability.isAvailable(target.gameObject);
                bool inradius = inRadius(target);
                bool notRed = !currentLevel.Equals("red");
                if (isAvailable && inradius && notRed)
                {
                    okTargets.Add(target);
                }
            }
        }
        int ok_len = okTargets.Count;
        int randomOkIndex = UnityEngine.Random.Range(0, okTargets.Count);
        min_target = targetList[randomOkIndex];
        Debug.Log(this.name + " is at danger level " + dangerLevel + " current target is " + min_target);
        return min_target;
    }


    // Update is called once per frame
    void Update()
    {
    
        //if seeker is very close I want to run to a far away target that is either yellow or green, I don't care which
        if (dangerLevel.getDangerLevel() == "red")
        {
            speedToUse = startingSpeed * redSpeedIncrease;
            navMeshAgent.speed = speedToUse;
            if (!redTargetLock)
            {
                navMeshAgent.SetDestination(FindSafeTargetNotRed(targetList).position);
            }
            redTargetLock = true;
        }
        //if seeker is close and he can see me, I want to get out of his sight
        if (dangerLevel.getDangerLevel() == "yellow" && this.dangerLevel.isVisible)
        {
            speedToUse = startingSpeed;
            navMeshAgent.speed = speedToUse;
            navMeshAgent.SetDestination(FindNearestTargetNotInSight(targetList).position);
        }
        //if he close and he can see me, I just want to get farther away
        if (dangerLevel.getDangerLevel() == "yellow")
        {
            speedToUse = startingSpeed;
            navMeshAgent.speed = speedToUse;
            navMeshAgent.SetDestination(FindNearestSafeTarget(targetList).position);
        }
        if(navMeshAgent.hasPath){

            animator.SetFloat("speed", navMeshAgent.speed);
        }else{
           animator.SetFloat("speed", 0);
            redTargetLock = false;
        }
    }
}
