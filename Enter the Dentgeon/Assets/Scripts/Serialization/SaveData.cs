using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public static SaveData current = new SaveData();
    

    public List<ObjectData> Gameobjectslist = new List<ObjectData>();


}
