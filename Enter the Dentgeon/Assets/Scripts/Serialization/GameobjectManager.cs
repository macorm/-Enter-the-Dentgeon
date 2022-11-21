using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectManager : MonoBehaviour
{
    public GameObject[] Objects;
    public void onSave()
    {
        SaveManager.Save("gameSave", SaveData.current);
    }
    public void onLoad()
    {
        SaveData.current = (SaveData)SaveManager.Load(Application.persistentDataPath + "/save/gameSave.save");

        for(int i=0; i<SaveData.current.Gameobjectslist.Count;i++)
        {
            ObjectData currentobject = SaveData.current.Gameobjectslist[i];
            GameObject obj = Instantiate(Objects[(int)currentobject.GameobjectType]);
            gameobjectHandler objectHandler = obj.GetComponent<gameobjectHandler>();
            objectHandler.gameObjectData = currentobject;
            objectHandler.transform.position = currentobject.position;
            objectHandler.transform.rotation = currentobject.rotation;
        }
    }
}
