using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkEnding : MonoBehaviour
{   
    //script for the object that is holding all the enemies if they are all dead.
    // An enemy calls killChild when it dies
    [Tooltip("Number of enemies to kill before game over")]
    [SerializeField] int aliveNumber;
  
    void Start()
    {
        aliveNumber = transform.childCount;
    }

    public void killChild()
    {
        aliveNumber--;
        if (aliveNumber <= 0)
        {
            if(SceneManager.GetActiveScene().name == "Demo"){
                SceneManager.LoadScene("eDemo");
            }else{
                 //if all children are read game is over.
                SceneManager.LoadScene("Win");
            }
           

        }
    }
}
