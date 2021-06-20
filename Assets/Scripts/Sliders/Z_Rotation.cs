using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Z_Rotation : ISlider
{
    void Start()
    {
        ISlider.StartSliderRotation("z_r", GetComponent<Slider>());
        mainSlider["z_r"].onValueChanged.AddListener(delegate { EditGameObject(mainSlider["z_r"].value); });
        mainSlider["z_r"].enabled = false;
    }

    public void EditGameObject(float a)
    {
        if (FurnitureInfo.Selected != null)
        {
            Quaternion temp = FurnitureInfo.Selected.transform.rotation;
            temp.z = mainSlider["z_r"].value;
            FurnitureInfo.Selected.transform.rotation = temp;
        }
    }

    static public void ManualUpdate(GameObject newObject)
    {
        mainSlider["z_r"].value = FurnitureInfo.Selected.transform.localScale.x;
        mainSlider["z_r"].enabled = true;
    }
}
