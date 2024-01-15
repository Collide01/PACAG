using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSize : MonoBehaviour
{
    public Slider cameraSlider;

    public void ChangeCameraSize()
    {
        Camera.current.orthographicSize = cameraSlider.value;
    }
}
