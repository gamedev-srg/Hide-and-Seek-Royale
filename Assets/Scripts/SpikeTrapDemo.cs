using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapDemo : MonoBehaviour {

    //This script goes on the SpikeTrap prefab;
    [SerializeField] float TimeToActivate;
    public Animator spikeTrapAnim; //Animator for the SpikeTrap;

    // Use this for initialization


    private void OnTriggerEnter(Collider other)
    {
        //if a player trips the trap activate it
        if (other.tag == "Player")
        {
            StartCoroutine(OpenCloseTrap());
        }
    }
    void Awake()
    {
        //get the Animator component from the trap;
        spikeTrapAnim = GetComponent<Animator>();
        //start as closed
        spikeTrapAnim.SetTrigger("close");

    }


    IEnumerator OpenCloseTrap()
    {
        //play open animation after time
        yield return new WaitForSeconds(TimeToActivate);
        spikeTrapAnim.SetTrigger("open");
        //wait to close
        yield return new WaitForSeconds(TimeToActivate);
        //play close animation;
        spikeTrapAnim.SetTrigger("close");
 
    }
}