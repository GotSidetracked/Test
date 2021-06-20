using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ISlider : MonoBehaviour
{
    static public Dictionary<string, Slider> mainSlider = new Dictionary<string, Slider>();
    static private GameObject lastObj = null;

    static public void StartSliderColor(string which, Slider slider)
    {
        mainSlider.Add(which,slider);
        mainSlider[which].minValue = 0;
        mainSlider[which].maxValue = 1;
    }

    static public void StartSliderXYZ(string which, Slider slider)
    {
        mainSlider.Add(which, slider);
        mainSlider[which].minValue = 0;
        mainSlider[which].maxValue = 10;
    }

    static public void StartSliderRotation(string which, Slider slider)
    {
        mainSlider.Add(which, slider);
        mainSlider[which].minValue = -1;
        mainSlider[which].maxValue = 1;
    }

    static public void UpdateInfo()
    {
        if(FurnitureInfo.Selected != null && FurnitureInfo.Selected != lastObj)
        {
            lastObj = FurnitureInfo.Selected;
            X_Slider.ManualUpdate(FurnitureInfo.Selected);
            Y_Slider.ManualUpdate(FurnitureInfo.Selected);
            Z_Slider.ManualUpdate(FurnitureInfo.Selected);
            R_Script.ManualUpdate(FurnitureInfo.Selected);
            G_Slider.ManualUpdate(FurnitureInfo.Selected);
            B_Slider.ManualUpdate(FurnitureInfo.Selected);
            X_Rotation.ManualUpdate(FurnitureInfo.Selected);
            Y_Rotation.ManualUpdate(FurnitureInfo.Selected);
            Z_Rotation.ManualUpdate(FurnitureInfo.Selected);
        }
    }
}
