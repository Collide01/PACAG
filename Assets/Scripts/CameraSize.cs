using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSize : MonoBehaviour
{
    public Camera mainCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            mainCamera.orthographicSize -= Input.mouseScrollDelta.y;
            if (mainCamera.orthographicSize > 30)
            {
                mainCamera.orthographicSize = 30;
            }
            else if (mainCamera.orthographicSize < 1)
            {
                mainCamera.orthographicSize = 1;
            }
        }
    }
}
