using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerBoss : MonoBehaviour
{
    public float timeToDestroy;
    private void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
