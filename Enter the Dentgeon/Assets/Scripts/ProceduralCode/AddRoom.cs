using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplate temp;
    private void Start()
    {
        temp = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        temp.rooms.Add(this.gameObject);
    }
}
