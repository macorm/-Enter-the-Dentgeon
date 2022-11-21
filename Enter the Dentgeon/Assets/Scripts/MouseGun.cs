using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MouseGun : MonoBehaviour
{
    private Transform armsTrans;
    private Vector3 mousePos;
    private Rigidbody2D rb;
    private void Awake()
    {
        armsTrans = transform.Find("arms");
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 15; // select distance = 10 units from the camera
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }
    private void FixedUpdate()
    {
        /*Vector3 differance = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        differance.Normalize();
        float rotationZ = Mathf.Atan2(differance.y, differance.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);*/
       
        Vector2 armsDirection = (Vector2)mousePos - rb.position;
        
        float angle = Mathf.Atan2(armsDirection.y, armsDirection.x) * Mathf.Rad2Deg;
        armsTrans.eulerAngles = new Vector3(0, 0, angle);
        //Debug.Log(angle); 
        
    }
    /* 
     private Vector3 GetMousePosition()
     {
         Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
         vec.z = 0f;
         return vec;
     }

     private Vector3 GetMouseWorldPositionWithZ() => GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
     private Vector3 GetMouseWorldPositionWithZ(Camera worldCamera) => GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
     private Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
     {
         Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
         return worldPosition;
     }*/
}
