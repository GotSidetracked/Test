using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Z_Slider : ISlider
{
    void Start()
    {
        ISlider.StartSliderXYZ("z", GetComponent<Slider>());
        mainSlider["z"].onValueChanged.AddListener(delegate { EditGameObject(mainSlider["z"].value); });
        mainSlider["z"].enabled = false;
    }

    public void EditGameObject(float a)
    {
        if (FurnitureInfo.Selected != null)
        {
            Vector3 temp = FurnitureInfo.Selected.transform.localScale;
            temp.z = mainSlider["z"].value;
            FurnitureInfo.Selected.transform.localScale = temp;
        }
    }

    static public void ManualUpdate(GameObject newObject)
    {
        mainSlider["z"].value = FurnitureInfo.Selected.transform.localScale.z;
        mainSlider["z"].enabled = true;
    }
}
