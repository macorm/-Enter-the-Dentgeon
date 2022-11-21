using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lolipopHead : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2;
    Rigidbody2D rb;
    private Transform player;
    bool parentDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (!(player.position.x > transform.position.x))
            transform.Rotate(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
            rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HeartComponent.TakeDamage();
            Destroy(gameObject);
            FindObjectOfType<audioManager>().Play("PlayerIsHit");
        }
        else if (collision.CompareTag("Wall") || collision.CompareTag("Vide"))
        {
            Destroy(gameObject);
            FindObjectOfType<audioManager>().Play("EnemyIsHit");
        }

    }
}
