using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    private float damage = .5f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("PewPewGuys"))
        {
            if (collision.CompareTag("Player"))
            {
                HeartComponent.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        FindObjectOfType<audioManager>().Play("EnemyIsHit");
    }
}
