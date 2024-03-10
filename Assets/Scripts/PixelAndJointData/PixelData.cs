using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelData : MonoBehaviour
{
    public Color pixelColorFront;
    public Color pixelColorBack;
    public Color pixelColorLeft;
    public Color pixelColorRight;
    public Color pixelColorTop;
    public Color pixelColorBottom;
    private Color currentColor;
    public Vector3 pixelPosition;

    public Color GetColor()
    {
        JointData parentJoint = transform.parent.GetComponent<JointData>();
        GridViews currentDirection = parentJoint.GetFaceToward();
        switch (currentDirection)
        {
            case GridViews.Front:
                currentColor = pixelColorFront;
                break;
            case GridViews.Back:
                currentColor = pixelColorBack;
                break;
            case GridViews.Left:
                currentColor = pixelColorLeft;
                break;
            case GridViews.Right:
                currentColor = pixelColorRight;
                break;
            case GridViews.Top:
                currentColor = pixelColorTop;
                break;
            case GridViews.Bottom:
                currentColor = pixelColorBottom;
                break;
        }
        return currentColor;
    }
}
