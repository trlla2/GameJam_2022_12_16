using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMovement : MonoBehaviour
{
    public float freq;
    public float amp;
    // Start is called before the first frame update
    void Start()
    {
    }
    public float posit_init_y;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time * freq) * amp, posit_init_y, 0);
    }
}
