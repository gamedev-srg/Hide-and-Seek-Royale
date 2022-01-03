using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyCounter : MonoBehaviour
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

    void Update()
    {
        Transform tchild = null;
        foreach (Transform child in enemies)
        {
            HealthSystem temp = child.GetComponent<HealthSystem>();
            if (!temp.enabled)
            {
                numofE--;
                tchild = child;
            }
        }
        if (tchild != null && enemies.Contains(tchild))
        {
            enemies.Remove(tchild);
        }
        text.text = "Enemies: " + numofE.ToString();
    }
}
