using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkEnding : MonoBehaviour
{
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
            SceneManager.LoadScene("HunterWin");
        }
    }
}
