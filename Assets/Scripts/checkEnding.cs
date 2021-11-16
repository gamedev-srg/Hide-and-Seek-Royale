using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkEnding : MonoBehaviour
{   //script for the object that is holding all the enemies if they are all dead.
    // An enemy calls killChild when it dies
    [SerializeField] int aliveNumber;
  
    // Start is called before the first frame update
    void Start()
    {
        aliveNumber = transform.childCount;
    }

    // Update is called once per frame
    public void killChild()
    {
        aliveNumber -= 1;
        if (aliveNumber <= 0)
        {
            //if all children are read game is over.
            SceneManager.LoadScene("HunterWin");
        }
    }
}
