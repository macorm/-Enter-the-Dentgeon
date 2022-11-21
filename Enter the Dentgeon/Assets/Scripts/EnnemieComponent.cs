using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieComponent : MonoBehaviour
{
    public float health = 10;
    public GameObject healthDrop;
    public GameObject[] ItemDrops;
    private GameObject player;
    private PlayerComponent compteur;

    public void TakeDomage(float damage)
    {
        health -= damage;
        FindObjectOfType<audioManager>().Play("EnemyIsHit");
        if(health <=0)
        {
            Die();
        }
    }
    void Die()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        compteur = player.GetComponent<PlayerComponent>();
        int random = Random.Range(0, 10);
        if (random == 0)
        {
            Instantiate(healthDrop, transform.position, Quaternion.identity);
        }
        else if (random == 9 && compteur.inventaire.Count <= 3)
        {
            Instantiate(ItemDrops[Random.Range(0,4)], transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
