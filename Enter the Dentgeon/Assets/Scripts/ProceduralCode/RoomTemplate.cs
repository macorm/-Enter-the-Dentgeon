using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;
public class RoomTemplate : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closerRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject bossRoom;
    public static GameObject bar;
    private GameObject victory;
    private Slider slide;
    //public GameObject bossCleaner;
    //public GameObject boss;
    private void Start()
    {
        bar = GameObject.FindGameObjectWithTag("BossBar");
        slide = bar.GetComponent<Slider>();
        victory = GameObject.FindGameObjectWithTag("Victory");
        bar.SetActive(false);
        victory.SetActive(false);
    }
    private void Update()
    {
        if (slide.value <= 0)
        {
            victory.SetActive(true);
            Time.timeScale = 0;
        }

        if(waitTime <= 0 && !spawnedBoss) 
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    
                    //Instantiate(bossCleaner, rooms[rooms.Count-1].transform.position, Quaternion.identity);
                    Invoke("SummonBoss", 1f);
                    spawnedBoss = true;
                }
            }
        }
        else if(waitTime>0)
        {
            waitTime -= Time.deltaTime;
        }
    }
    private void SummonBoss() 
    {
        int lastRoomIndex = rooms.Count - 1;
        Vector3 lastRoomPosition = rooms[lastRoomIndex].transform.position;
        Destroy(rooms[lastRoomIndex]);
        Instantiate(bossRoom, lastRoomPosition, Quaternion.identity);
        AstarPath.active.Scan();
    }
}
