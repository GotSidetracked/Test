using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R_Script : ISlider
{
    void Start()
    {
        ISlider.StartSliderColor("r", GetComponent<Slider>());
        mainSlider["r"].onValueChanged.AddListener(delegate { EditGameObject(mainSlider["r"].value); });
        mainSlider["r"].enabled = false;
    }

    public void EditGameObject(float a)
    {
        if (FurnitureInfo.Selected != null)
        {
            Color temp = FurnitureInfo.Selected.GetComponent<Renderer>().material.color;
            temp.r = mainSlider["r"].value;
            FurnitureInfo.Selected.GetComponent<Renderer>().material.color = temp;
        }
    }
    
    static public void ManualUpdate(GameObject newObject)
    {
        mainSlider["r"].value = FurnitureInfo.Selected.GetComponent<Renderer>().material.color.r;
        mainSlider["r"].enabled = true;
    }

}
