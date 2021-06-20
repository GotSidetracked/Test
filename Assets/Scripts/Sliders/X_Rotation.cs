using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class X_Rotation : ISlider
{
    void Start()
    {
        ISlider.StartSliderRotation("x_r", GetComponent<Slider>());
        mainSlider["x_r"].onValueChanged.AddListener(delegate { EditGameObject(mainSlider["x_r"].value); });
        mainSlider["x_r"].enabled = false;
    }

    public void EditGameObject(float a)
    {
        if (FurnitureInfo.Selected != null)
        {
            Quaternion temp = FurnitureInfo.Selected.transform.rotation;
            temp.x = mainSlider["x_r"].value;
            FurnitureInfo.Selected.transform.rotation = temp;
        }
    }

    static public void ManualUpdate(GameObject newObject)
    {
        mainSlider["x_r"].value = FurnitureInfo.Selected.transform.localScale.x;
        mainSlider["x_r"].enabled = true;
    }

}
