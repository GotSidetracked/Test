using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class X_Slider : ISlider
{
    void Start()
    {
        ISlider.StartSliderXYZ("x", GetComponent<Slider>());
        mainSlider["x"].onValueChanged.AddListener(delegate { EditGameObject(mainSlider["x"].value); });
        mainSlider["x"].enabled = false;
    }

    public void EditGameObject(float a)
    {
        if (FurnitureInfo.Selected != null)
        {
            Vector3 temp = FurnitureInfo.Selected.transform.localScale;
            temp.x = mainSlider["x"].value;
            FurnitureInfo.Selected.transform.localScale = temp;
        }
    }

    static public void ManualUpdate(GameObject newObject)
    {
        mainSlider["x"].value = FurnitureInfo.Selected.transform.localScale.x;
        mainSlider["x"].enabled = true;
    }
}
