using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fuseable : MonoBehaviour
{
    TextMeshProUGUI text = new TextMeshProUGUI();
    GameObject lastOne;

    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (FurnitureInfo.Selected == null)
        {
            text.text = "Please select or spawn an object";
        }
        else if (FurnitureInfo.Selected.GetComponent<ObjInfo>() != null)
        {
            if (FurnitureInfo.Selected.GetComponent<ObjInfo>().GetIsColliding())
            {
                text.text = "Press Q to fuse";
            }
            else
            {
                text.text = "Not coliding";
            }
        }
        else
        {
            text.text = "Not valid object";
        }
    }
}
