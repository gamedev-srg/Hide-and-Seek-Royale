using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulser : MonoBehaviour
{

    [SerializeField] float scaleRate = 0.01f; //The speed in which we increase our scale
    [SerializeField] float maxScaleX = 2.0f; //scale upperbounds (Refers to x attribute only)
    [SerializeField] float minScaleX = 0.2f;
    Vector3 startPos;
    Vector3 startingScale;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; //object's starting positon, to easly refence it.
        startingScale = this.transform.localScale; //object's starting scale, to easly refence it.
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if we reached reached lowerbounds, and need to swap resize direction to growing
        if (transform.localScale.x < minScaleX)
        {
            scaleRate = Mathf.Abs(scaleRate);
        }
        //Checks if we reached reached upperbounds, and need to swap resize direction to shrinking
        else if (transform.localScale.x > maxScaleX)
        {
            scaleRate = -Mathf.Abs(scaleRate);
        }
        //apply change.
        transform.localScale += Vector3.one * scaleRate;
    }
}
