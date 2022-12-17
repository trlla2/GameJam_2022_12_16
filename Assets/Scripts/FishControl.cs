using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    SpriteRenderer sr;
    public List<Sprite> sprites;
    public FishManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager.actual_fishes++;

        rb = GetComponent<Rigidbody2D>();
        Vector2 scale = new Vector2(Random.Range(-1f, 1f), 1);
        scale.Normalize();
        Debug.Log(scale);
        Debug.Log(scale);

        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[Random.Range(0, sprites.Count)];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
