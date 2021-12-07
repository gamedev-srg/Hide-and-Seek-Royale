using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demostart : MonoBehaviour
{
    public BoxCollider box;
    [SerializeField] GameObject enemie;
    [SerializeField] GameObject panel;

      private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" ) {
            panel.SetActive(false);
        }
        if(gameObject.tag == "end"){
            if (other.tag == "Player" ) {
                panel.SetActive(true);
            }
        }
    }
}
