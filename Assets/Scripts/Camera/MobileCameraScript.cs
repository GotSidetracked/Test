using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCameraScript : ICamera
{

    /// <summary>
    /// Class made for the movement and rotation of the player currentCamera
    /// </summary>
    
    static public Camera MobileCamera;

    static private bool isSelected;

    private Rigidbody body;
    private float speed;
    private float vertical;

    void Start()
    {
        MobileCamera = GetComponent<Camera>();
        MobileCamera.enabled = false;
        body = GetComponent<Rigidbody>();
        speed = 1000;
        isSelected = false;
    }

    void Update()
    {
        if (isSelected == true)
        {
            KeyBoardMovement();
            switchCameras();
            rotationalMovement();
            //MoveUsingMouse();
            SpawnObject();
        }
    }

    private void switchCameras()
    {
        if (Input.GetKeyUp(KeyCode.Z) && (lastPressTime + switchDelay) < Time.unscaledTime)
        {
            cam = null;
            StaticCameraScript.lastPressTime = Time.unscaledTime;
            isSelected = false;
            MobileCamera.enabled = false;
            StaticCameraScript.StaticCamera.enabled = true;
            StaticCameraScript.switchToStatic();
        }
    }

    static public void switchToMobile()
    {
        cam = MobileCamera;
        isSelected = true;
    }

    private void KeyBoardMovement()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            vertical = Input.GetAxis("Vertical");
            Vector3 Veloc = transform.forward * vertical;
            body.velocity = Veloc * speed * Time.fixedDeltaTime;
        }
    }
}
