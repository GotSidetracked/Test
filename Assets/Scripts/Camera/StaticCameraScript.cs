using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCameraScript : ICamera 
{
    /// <summary>
    /// 
    /// </summary>

    static private bool isSelected;
    static public Camera StaticCamera;

    void Start()
    {
        isSelected = true;
        cam = GetComponent<Camera>();
        StaticCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (isSelected == true)
        {
            SpawnObject();
            rotationalMovement();
            switchCameras();
        }
    }

    private void switchCameras()
    {
        if (Input.GetKeyUp(KeyCode.Z) && (lastPressTime + switchDelay) < Time.unscaledTime)
        {
            cam = null;
            MobileCameraScript.lastPressTime = Time.unscaledTime;
            StaticCamera.enabled = false;
            MobileCameraScript.MobileCamera.enabled = true;
            isSelected = false;
            switchToMobile();
        }
    }

    private void switchToMobile()
    {
        cam = null;
        isSelected = false;
        MobileCameraScript.switchToMobile();
    }

    static public void switchToStatic()
    {
        cam = StaticCamera;
        isSelected = true;
    }

}
