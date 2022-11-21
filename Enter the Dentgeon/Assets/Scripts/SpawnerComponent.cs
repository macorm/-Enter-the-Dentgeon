using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    public Transform[] spawnZones;

    [SerializeField]
    public GameObject[] ObjectToSpawn;

    [SerializeField]
    private List<GameObject> enemyList = new List<GameObject>();

    private int spawnNum; // This chooses a random number to pick from the spawn zones
    private int enemyNum; // This chooses a random number to pick from the enemies array
    private int listStartCount;
    private int maxListCount;
    private int randomEnemmy;

    private GameObject CurrentEnnemy;
    private Transform enemySpawn; // This stores the transform of the chosen spawn zone


    private void Start()
    {
        for (int i = 0; i < spawnZones.Length; i++)
        {
            randomEnemmy = Random.Range(0, ObjectToSpawn.Length); // grab random ennemy
            enemyList.Add(spawnEnemies(ObjectToSpawn[randomEnemmy], spawnZones[i].transform));
            //enemyList.Add(Instantiate(enemies[randomEnemmy], spawnZones[i].transform.position, Quaternion.identity));
        }
        
    }

    GameObject spawnEnemies(GameObject obj, Transform trans)
    {

        obj = Instantiate(obj, trans.position, Quaternion.identity);
        obj.transform.parent = this.transform.GetChild(0);
        return obj;
    }

    
}