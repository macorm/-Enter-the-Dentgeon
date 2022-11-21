using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class CandyCorn : MonoBehaviour
{
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (GetComponent<AIDestinationSetter>().target == null)
        {
            GetComponent<AIDestinationSetter>().target = player;
        }
    }
}
