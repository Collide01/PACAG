using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawControls : MonoBehaviour
{
    public Camera mainCamera;
    [SerializeField] private DrawingManager drawingManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            if (Input.mouseScrollDelta.y != 0 && drawingManager.mouseInDrawField) // Sideways scroll
            {
                mainCamera.transform.Translate(new Vector3(Input.mouseScrollDelta.y, 0, 0));
            }
            if (Input.GetKeyDown(KeyCode.Z)) // Undo
            {
                Debug.Log("Undo");
            }
            if (Input.GetKeyDown(KeyCode.Y)) // Redo
            {
                Debug.Log("Redo");
            }
            if (Input.GetKeyDown(KeyCode.Equals)) // Zoom in
            {
                if (mainCamera.orthographicSize > 1)
                {
                    mainCamera.orthographicSize -= 5;
                }
            }
            if (Input.GetKeyDown(KeyCode.Minus)) // Zoom out
            {
                if (mainCamera.orthographicSize < 31)
                {
                    mainCamera.orthographicSize += 5;
                }
            }
        }
        else if (Input.mouseScrollDelta.y != 0 && drawingManager.mouseInDrawField)
        {
            mainCamera.transform.Translate(new Vector3(0, Input.mouseScrollDelta.y, 0));
        }
    }
}
