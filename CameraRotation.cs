using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Camera mCam;
    private float screenLength, mousePosition;
    public float camSpeed, deadZone, clampL, clampR;
    
    void Update()
    {
        transform.localEulerAngles = CalculateNextRot();
    }
    private float CalculateDistance()
    {
        screenLength = Screen.width;
        mousePosition = (screenLength / 2 - Input.mousePosition.x) * -1;
        float finMouse = (mousePosition / (screenLength / 2)) * camSpeed;
        if (finMouse < deadZone && finMouse > -deadZone)
            finMouse = 0;
        return finMouse;
    }
    private Vector3 CalculateNextRot()
    {
        float currentRot = transform.localRotation.eulerAngles.y; //x i z s¹ poziome, a y jest pionowe. 
        float finishRot = currentRot + CalculateDistance() * Time.deltaTime;

        if (finishRot < 0)
        {
            finishRot += 360;
        }
        if (finishRot > clampR && finishRot < 180)
        {
            finishRot = clampR;
        }
        else if (finishRot < 360 + clampL && finishRot > 180)
        {
            finishRot = 360 + clampL;
        }
        return new Vector3(0, finishRot, 0);

    }
}
