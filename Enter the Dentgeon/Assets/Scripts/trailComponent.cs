using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailComponent : MonoBehaviour
{
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject trail;

    // Start is called before the first frame update
    void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            int random = Random.Range(0, 3);
            if (random == 0)
            {
                Instantiate(trail, transform.position, Quaternion.identity);
            }
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
