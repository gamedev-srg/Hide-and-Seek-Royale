using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagRotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0f, 1f, 0f));
    }
}
