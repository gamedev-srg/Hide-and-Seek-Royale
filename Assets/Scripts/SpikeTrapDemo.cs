using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapDemo : MonoBehaviour {
    [Tooltip("Time to activate spawn traps")]
    [SerializeField] float TimeToActivate;
    public Animator spikeTrapAnim; //Animator for the SpikeTrap;

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        //if a player or enemy trips the trap activate it
        if (other.tag == "Player" || other.tag == "Enemy")
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