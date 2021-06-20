using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            if (FurnitureInfo.Selected != null)
            {
                FurnitureInfo.Obj.Remove(FurnitureInfo.Selected);
                Destroy(FurnitureInfo.Selected);
            }
        }
    }
}
