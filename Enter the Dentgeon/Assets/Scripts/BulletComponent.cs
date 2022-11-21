using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    public static float speed = 20f;
    public static float damage = 1;
    public Rigidbody2D rb;
    public static float scale = 1f ;
    private Transform temp;

    // Start is called before the first frame update
    void Awake()
    {
        transform.localScale *= scale;
        temp = transform;
        temp.localScale = transform.localScale * scale; 
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = temp.localScale ;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnnemieComponent ennemie = collision.GetComponent<EnnemieComponent>();
        BossHealthComponent boss = collision.GetComponent<BossHealthComponent>();

        if (boss != null)
        {
            boss.TakeDomage(damage);
        }

        if (ennemie != null)
        {
            ennemie.TakeDomage(damage);
        }
        Destroy(gameObject);
    }
}
