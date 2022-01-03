using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLineOfSight : MonoBehaviour
{
    float fov = 45f;
    RaycastHit rayHit;
    [SerializeField]LayerMask blockLineOfSightMask;
    private float timeToWait = 2f;
    [SerializeField] GameObject enemies;
    [SerializeField] GameObject targets;

    void setLineOfSight(GameObject target)
    {
        //if the enemy is in 90degrees of where we are facing
        DangerLevel dangerLevel = target.gameObject.GetComponent<DangerLevel>();
        if (dangerLevel)
        {
            if (Vector3.Angle(target.transform.position - transform.position, transform.forward) <= fov)
            {
                //and if there is nothing from the blockLineOfSightMask that is blocking the target
                if (!Physics.Linecast(transform.position, target.transform.position, out rayHit, blockLineOfSightMask))
                { 
                    dangerLevel.isVisible = true;
                }
                else
                {
                    dangerLevel.isVisible = false;
                }
            }
            else
            {
                dangerLevel.isVisible = false;
            }
        }
    }
    // Start is called before the first frame update
    public IEnumerator updateLineOfSight(GameObject targetList)
    {

        while (true)
        { 
            foreach (Transform item in targetList.GetComponentsInChildren<Transform>())
            {
                setLineOfSight(item.gameObject);
            }
     
        yield return new WaitForSeconds(timeToWait);
        }
    }


    private void Start()
    {
        StartCoroutine(updateLineOfSight(enemies));
        StartCoroutine(updateLineOfSight(targets));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
