using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorComponent : MonoBehaviour
{
    public GameObject[] Doors;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            foreach(GameObject doors in  Doors)
            {
                doors.SetActive(false);
            }
    }
}
