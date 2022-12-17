using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Vector3[] Positions;

    private int mCurrentIndex = 0;

    public float speed = 2.0f;

    // Update is called once per frame
    void Update()
    {

        Vector3 currentPos = Positions[mCurrentIndex];

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (mCurrentIndex < Positions.Length - 1)
                mCurrentIndex++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (mCurrentIndex > 0)
                mCurrentIndex--;
        }
        transform.position = Vector3.Lerp(transform.position, currentPos, speed * Time.deltaTime);
    }
}
