using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float limit_x;
    void Update()
    {
        if (transform.position.x > limit_x)
        {
            transform.position = new Vector3(-limit_x, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -limit_x)
        {
            transform.position = new Vector3(limit_x, transform.position.y, transform.position.z);
        }
    }
}
