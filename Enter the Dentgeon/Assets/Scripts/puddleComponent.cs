using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddleComponent : MonoBehaviour
{
    private bool isPlayertouching = false;
    private float timeAlive = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayertouching)
        {
            HeartComponent.TakeDamage(); //cest un peu scuffed que ca fasse bobo a chaque frame
                                         //mais quand on aura des frames d'invulnerabilité ca sera good :)
        }
        if (timeAlive>0)
        {
            timeAlive -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayertouching = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayertouching = false;
        }
    }
}
