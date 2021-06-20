using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DragAndDrop : MonoBehaviour
{
    
    //Initialize Variables
    GameObject getTarget;
    bool isMouseDragging;
    Vector3 offsetValue;
    Vector3 positionOfScreen;
    static ScrollRect scrollRect;

    void Update()
    {
        //Debug.Log(Input.mouseScrollDelta);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            GameObject temp = ReturnClickedObject(out hitInfo);
            if (temp != null && temp.tag == "Furniture")
            {
                FurnitureInfo.Selected.GetComponent<ObjInfo>().UnSelect();
                FurnitureInfo.Selected = temp;
                isMouseDragging = true;
                ISlider.UpdateInfo();
                freezeGameObject();
                FurnitureInfo.Selected.GetComponent<ObjInfo>().SetSelect();
                positionOfScreen = Camera.main.WorldToScreenPoint(FurnitureInfo.Selected.transform.position);
                offsetValue = FurnitureInfo.Selected.transform.position - ICamera.cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
            }
        }

        if (FurnitureInfo.Selected != null)
        {
            if (Input.GetKey(KeyCode.R))
            {
                unfreezeGameObject();
            }

            if (Input.GetMouseButtonUp(0))
            {
                isMouseDragging = false;
                FurnitureInfo.Selected.GetComponent<Collider>().isTrigger = false;
            }

            if (isMouseDragging)
            {
                Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);
                Vector3 currentPosition = ICamera.cam.ScreenToWorldPoint(currentScreenSpace) + offsetValue;
                FurnitureInfo.Selected.transform.position = currentPosition;
            }

            if (Input.mouseScrollDelta[1] < 0)
            {
               // Debug.Log("terer");
               // Debug.Log(ICamera.cam.transform.forward + " " + Time.deltaTime);
                Vector3 distance = (ICamera.cam.transform.position - FurnitureInfo.Selected.transform.position);
                FurnitureInfo.Selected.transform.position += distance * Time.deltaTime;
            }

            if (Input.mouseScrollDelta[1] > 0)
            {
                //Debug.Log("terer");
                //Debug.Log(ICamera.cam.transform.forward + " " + Time.deltaTime);
                Vector3 distance = (ICamera.cam.transform.position - FurnitureInfo.Selected.transform.position);
                FurnitureInfo.Selected.transform.position -= distance * Time.deltaTime;
            }
        }
    }

    public void freezeGameObject()
    {
        FurnitureInfo.Selected.GetComponent<Collider>().isTrigger = true;
        FurnitureInfo.Selected.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
        FurnitureInfo.Selected.GetComponent<Rigidbody>().useGravity = false;
    }

    public void unfreezeGameObject()
    {
        FurnitureInfo.Selected.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        FurnitureInfo.Selected.GetComponent<Rigidbody>().useGravity = true;
    }

    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }
}