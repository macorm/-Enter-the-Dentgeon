using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public enum ObjectType
{
    mur,
    vide,
    personnage,
    bonbon,
    bonbonvolant
}

[System.Serializable]
public class ObjectData
{
    public string id;
    public ObjectType GameobjectType;
    public Vector3 position;
    public Quaternion rotation;

}