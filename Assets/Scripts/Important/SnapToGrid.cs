using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && FurnitureInfo.Selected != null)
        {
            var currentPos = FurnitureInfo.Selected.transform.position;
            FurnitureInfo.Selected.transform.position = new Vector3(Mathf.Round(currentPos.x),
                                         Mathf.Round(currentPos.y),
                                         Mathf.Round(currentPos.z));
        }
    }
}
