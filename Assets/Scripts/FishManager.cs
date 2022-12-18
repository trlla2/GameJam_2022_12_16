using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    public GameObject fish;
    public float limitx = 9.5f;
    public float limity = -1f;
    public float limit_y = -4.85f;
    public int max = 4;
    public int actual_fishes = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < max; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-limitx, limitx), Random.Range(limit_y, limity));
            while (Vector3.Distance(pos, Vector3.zero) < 4f)
            {
                pos = new Vector3(Random.Range(-limitx, limitx), Random.Range(limit_y, limity));
            }
            GameObject temp = Instantiate(fish, pos, Quaternion.identity);
            temp.GetComponent<FishControl>().manager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (actual_fishes <= 0)
        {
            for (int i = 0; i < max; i++)
            {
                Vector3 pos = new Vector3(Random.Range(-limitx, limitx), Random.Range(limit_y, limity));
                GameObject temp = Instantiate(fish, pos, Quaternion.identity);
                temp.GetComponent<FishControl>().manager = this;
            }
            max++;
        }
    }
}