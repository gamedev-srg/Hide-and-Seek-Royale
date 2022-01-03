using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class counter : MonoBehaviour
{
    [SerializeField] Text text;
    private List<Transform> enemies;
    private int numofE = 0;
    // Start is called before the first frame update
    void Start()
    {
        numofE = this.transform.childCount;
        enemies = new List<Transform>();
        foreach(Transform child in transform)
        {
           enemies.Add(child);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform child in enemies)
        {
            HealthSystem temp = child.GetComponent<HealthSystem>();
            if( ! temp.enabled){
                numofE--;
                enemies.Remove(child);
            }
        }
       text.text ="Enemies left: " + numofE.ToString();
    }
}
