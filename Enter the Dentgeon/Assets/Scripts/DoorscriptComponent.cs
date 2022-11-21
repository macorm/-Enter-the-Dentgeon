using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorscriptComponent : MonoBehaviour
{
    public int ennemiesAlive;
    public GameObject Ennemies;
    public GameObject Doors;
    //public Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        Doors = this.transform.Find("Doors").gameObject;
        Debug.Log(Doors);
        GameObject Spawner = this.transform.Find("Spawners").gameObject;
        Ennemies = Spawner.transform.GetChild(0).gameObject;
        ennemiesAlive = Ennemies.transform.childCount;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        for (int i = 0; i < Ennemies.transform.childCount; i++)
        {
            if (Ennemies.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                ennemiesAlive++;
            }
        }
        if (ennemiesAlive == 0 && collision.gameObject.layer ==10  && Doors.transform.parent.Find("marker").GetComponent<SpriteRenderer>().isVisible)
        {
            //animator.SetBool("isOpen", true);
            collision.gameObject.SetActive(false);
            //Doors.SetActive(false);
            Debug.Log("doors open ABRACADABRA" +collision.gameObject.name);
        }
        ennemiesAlive = 0;
    }

     //private void OnCollisionStay2D(Collision2D collision)
     //{
     //    for (int i = 0; i < Ennemies.transform.childCount; i++)
     //    {
     //        if (Ennemies.transform.GetChild(i).gameObject.activeInHierarchy)
     //        {
     //            ennemiesAlive++;
     //        }
     //    }
     //    Debug.Log("KOKOKOKOKO" + collision.gameObject.layer);
     //    if (ennemiesAlive == 0 && collision.gameObject.layer == 10 && Doors.transform.parent.Find("marker").GetComponent<SpriteRenderer>().isVisible)
     //    {
     //        collision.gameObject.SetActive(false);
     //        Doors.SetActive(false);
     //    }
     //    ennemiesAlive = 0;
     //}

     //  for (int i = 0; i < Ennemies.transform.childCount; i++)
     //    {
     //        if (Ennemies.transform.GetChild(i).gameObject.activeInHierarchy)
     //        {
     //            ennemiesAlive++;
     //        }
     //    }
     //    Debug.Log("pogers");
     //    if (ennemiesAlive == 0 && collision.gameObject.layer == 10)
     //    {
     //        collision.gameObject.SetActive(false);
     //        Doors.SetActive(false);
     //    }
     //    ennemiesAlive = 0;
      
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("pog");
    //    if (ennemiesAlive == 0 && collision.gameObject.layer == 10)
    //    {
    //        collision.gameObject.SetActive(false);
    //        Doors.SetActive(false);
    //    }
    //    ennemiesAlive = 0;
    //}
}
