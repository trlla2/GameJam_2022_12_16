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
        float val = Random.Range(-1, 1);
        float valf = Random.Range(0.1f, 1f);
        if (val < 0) { transform.localScale = new Vector2(-valf, valf); }
        else { transform.localScale = new Vector2(valf, valf); }
        speed = speed * Random.Range(0.1f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        manager.actual_fishes++;
        transform.eulerAngles = new Vector3(0, 0, 0);
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction.Normalize();
        Debug.Log(direction);
        Debug.Log(direction.magnitude);
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[Random.Range(0, sprites.Count)];

        rb.AddForce(direction * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cielo")
        {
            rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, 0);
        }
    }

}
