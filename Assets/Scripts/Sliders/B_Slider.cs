using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B_Slider : ISlider
{
    void Start()
    {
        ISlider.StartSliderColor("b", GetComponent<Slider>());
        mainSlider["b"].onValueChanged.AddListener(delegate { EditGameObject(mainSlider["b"].value); });
        mainSlider["b"].enabled = false;
    }

    public void EditGameObject(float a)
    {
        if (FurnitureInfo.Selected != null)
        {
            Color temp = FurnitureInfo.Selected.GetComponent<Renderer>().material.color;
            temp.b = mainSlider["b"].value;
            FurnitureInfo.Selected.GetComponent<Renderer>().material.color = temp;
        }
    }

    static public void ManualUpdate(GameObject newObject)
    {
        mainSlider["b"].value = FurnitureInfo.Selected.GetComponent<Renderer>().material.color.b;
        mainSlider["b"].enabled = true;
    }
}
