using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagement : MonoBehaviour
{
    public int width, height;
    public GameObject sallePrefab;
    public GameObject tlieSize;
    public int minXValue = 0, maxXValue;    
    public int minYValue = 0, maxYValue;

    private float cellWidth;
    private float cellHeight;
    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

                var spawnedTile = Instantiate(sallePrefab, new Vector3(x * cellWidth, y * cellHeight), Quaternion.identity);
                spawnedTile.name = "Tile (" + x + "," + y + ")";
                Possibility poss = spawnedTile.GetComponentInChildren<Possibility>();
                GenerateRoom(poss,x,y);
            }
        }
    }
    void GenerateRoom(Possibility poss, int x, int y)
    {
        if(x < minXValue && y < minYValue)
        {
            Debug.Log("df");
            var temp = poss.tilePossibillity.Find((f) => f.name == "EmptyRoom");
            temp.SetActive(true);
        }
        else if(x == minXValue && y == minYValue)
        {
            var temp = poss.tilePossibillity.Find((f) => f.name == "CornerDL");
            temp.SetActive(true);
        }
        else
        {
            Debug.Log(poss.tilePossibillity.Count);
           int rand = Random.Range(0, poss.tilePossibillity.Count);
           poss.tilePossibillity[rand].SetActive(true); 
        }
        
    }
    void Start()
    {
        

        cellWidth = tlieSize.transform.localScale.x;
        cellHeight = tlieSize.transform.localScale.y;
        GenerateGrid();
    }
}
