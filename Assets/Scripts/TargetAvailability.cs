using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAvailability : MonoBehaviour
{
    //script ensures that only a certain amount of units (enemies) can occupy a single target
    [SerializeField] public int maxUnitsAtTarget = 1;
    [SerializeField] public int currentUnitAtTarget;
    [SerializeField] GameObject enemies;
    public float timeToWait = 1.5f;
    Transform[] enemyList;

     float minDistance = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        enemyList = enemies.GetComponentsInChildren<Transform>();
        currentUnitAtTarget = 0;
        StartCoroutine(checkUnits());
    }
    public bool isAvailable(GameObject target)
    {
        if (currentUnitAtTarget >= maxUnitsAtTarget)
            return false;

        return true;
    }
    public IEnumerator checkUnits()
    {
        while (true)
        {
            int counter = 0;
            foreach(Transform enemy in enemyList)
            {
                if(Vector3.Distance(enemy.position,this.transform.position) < minDistance)
                {
                    counter++;
                }
            }
            currentUnitAtTarget = counter;
            yield return new WaitForSeconds(timeToWait);
        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}
