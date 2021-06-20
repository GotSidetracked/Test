using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Y_Slider : ISlider
{
    void Start()
    {
        ISlider.StartSliderXYZ("y",GetComponent<Slider>());
        mainSlider["y"].onValueChanged.AddListener(delegate { EditGameObject(mainSlider["y"].value); });
        mainSlider["y"].enabled = false;
    }

    public void EditGameObject(float a)
    {
        if (FurnitureInfo.Selected != null)
        {
            Vector3 temp = FurnitureInfo.Selected.transform.localScale;
            temp.y = mainSlider["y"].value;
            FurnitureInfo.Selected.transform.localScale = temp;
        }
    }

    static public void ManualUpdate(GameObject newObject)
    {
        mainSlider["y"].value = FurnitureInfo.Selected.transform.localScale.y;
        mainSlider["y"].enabled = true;
    }
}
