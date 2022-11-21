using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class BonbonVolant : MonoBehaviour
{
    private float speed = 10;
    private float retreatDistance = 4;
    private Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (GetComponent<AIDestinationSetter>().target == null)
        {
            GetComponent<AIDestinationSetter>().target = player;
        }
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
