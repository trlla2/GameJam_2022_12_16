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
    CapsuleCollider2D cc;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector2(Random.Range(-0.6f, 0.6f), 0.6f);
        speed = speed * Random.Range(0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        manager.actual_fishes++;

        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction.Normalize();
        Debug.Log(direction);
        Debug.Log(direction.magnitude);
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[Random.Range(0, sprites.Count)];

        rb.AddForce(direction * speed);
    }
}
