using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameobjectHandler : MonoBehaviour
{
    public ObjectType gameObjectType;

    public ObjectData gameObjectData;

    public void Start()
    {
        if(string.IsNullOrEmpty(gameObjectData.id))
        {
            gameObjectData.id = System.DateTime.Now.ToLongDateString() + Random.Range(0, int.MaxValue).ToString();
            gameObjectData.GameobjectType = gameObjectType;
            SaveData.current.Gameobjectslist.Add(gameObjectData);
        }
    }
    public void Update()
    {
        gameObjectData.position = transform.position;
        gameObjectData.rotation = transform.rotation;
    }
    void DestroyMe()
    {
    }
}
