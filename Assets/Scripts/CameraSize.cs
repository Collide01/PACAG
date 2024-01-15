using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSize : MonoBehaviour
{
    public Slider cameraSlider;
    public Camera mainCamera;

    public void ChangeCameraSize()
    {
        mainCamera.orthographicSize = cameraSlider.value;
    }
}
