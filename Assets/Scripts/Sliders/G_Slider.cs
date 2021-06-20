using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G_Slider : ISlider
{
    void Start()
    {
        ISlider.StartSliderColor("g", GetComponent<Slider>());
        mainSlider["g"].onValueChanged.AddListener(delegate { EditGameObject(mainSlider["g"].value); });
        mainSlider["g"].enabled = false;
    }

    public void EditGameObject(float a)
    {
        if (FurnitureInfo.Selected != null)
        {
            Color temp = FurnitureInfo.Selected.GetComponent<Renderer>().material.color;
            temp.g = mainSlider["g"].value;
            FurnitureInfo.Selected.GetComponent<Renderer>().material.color = temp;
        }
    }

    static public void ManualUpdate(GameObject newObject)
    {
        mainSlider["g"].value = FurnitureInfo.Selected.GetComponent<Renderer>().material.color.g;
        mainSlider["g"].enabled = true;
    }
}
