using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Y_Rotation : ISlider
{
    void Start()
    {
        ISlider.StartSliderRotation("y_r", GetComponent<Slider>());
        mainSlider["y_r"].onValueChanged.AddListener(delegate { EditGameObject(mainSlider["y_r"].value); });
        mainSlider["y_r"].enabled = false;
    }

    public void EditGameObject(float a)
    {
        if (FurnitureInfo.Selected != null)
        {
            Quaternion temp = FurnitureInfo.Selected.transform.rotation;
            temp.y = mainSlider["y_r"].value;
            FurnitureInfo.Selected.transform.rotation = temp;
        }
    }

    static public void ManualUpdate(GameObject newObject)
    {
        mainSlider["y_r"].value = FurnitureInfo.Selected.transform.localScale.x;
        mainSlider["y_r"].enabled = true;
    }
}
