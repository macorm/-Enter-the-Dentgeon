using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealComponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        HeartComponent.health += 0.1f;
        this.gameObject.SetActive(false);
      
    }
}
