using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvementComponent : MonoBehaviour
{
    private float ValueHorizontale = 31.2f;
    private float valueVerticale = 16.8f;
    public GameObject Camera;
    public GameObject Personnage;


    void Update()
    {
        //gauche
        if (Personnage.transform.position.x - Camera.transform.position.x >= 32f /2)
        { 
            Camera.transform.position = new Vector3(Camera.transform.position.x + ValueHorizontale, Camera.transform.position.y,Camera.transform.position.z);
        }
        //droite
        if(Camera.transform.position.x - Personnage.transform.position.x >= 32f / 2)
        {
           Camera.transform.position = new Vector3(Camera.transform.position.x - ValueHorizontale, Camera.transform.position.y, Camera.transform.position.z);
        }
        //haut
        if (Personnage.transform.position.y - Camera.transform.position.y >= 18f /2)
        {
            Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y + valueVerticale, Camera.transform.position.z);
        }
        //bas
        if(Camera.transform.position.y - Personnage.transform.position.y >= 18f / 2)
        {
           Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - valueVerticale, Camera.transform.position.z);
        }
    }
}
