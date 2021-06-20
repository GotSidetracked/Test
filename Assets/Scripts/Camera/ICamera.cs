using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICamera : MonoBehaviour
{
    static public Camera cam;
    static public float lastPressTime;

    public float switchDelay = 0.5f;

    private Vector3 offsetValue;
    private Vector3 positionOfScreen;
    private Vector3 lastMouse = new Vector3(255, 255, 255); 
   
    private bool isMouseDragging;
    private float camSens = 0.25f;

    //For spawning
    public string spawnOption = "Single";
    private RaycastHit hit;
    private int layerMask = 1 << 8;

    public void changeSpawnOption()
    {
        if (spawnOption == "Single")
        {
            spawnOption = "Mult";
        }
        else
            spawnOption = "Single";
    }

    public void SpawnObj()
    {
        layerMask = ~layerMask;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask) && FurnitureInfo.SpawnItem != null)
        {
            GameObject temp = Instantiate(FurnitureInfo.SpawnItem);
            temp.tag = "Furniture";
            temp.name = FurnitureInfo.SpawnItem.name;
            temp.transform.position = hit.point;
            FurnitureInfo.Selected = temp;
            FurnitureInfo.addObject();

        }
    }

    public void rotationalMovement()
    {
        if (Input.GetMouseButton(1))
        {
            lastMouse = Input.mousePosition - lastMouse;
            lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
            lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
            transform.eulerAngles = lastMouse;
            lastMouse = Input.mousePosition;
        }
    }

    public void SpawnObject()
    {
        if (spawnOption == "Single")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SpawnObj();
            }
        }
        else if (Input.GetKey(KeyCode.E))
        {
            SpawnObj();
        }
    }
}