using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Tilemaps;

public class JointData : MonoBehaviour
{
    public BodyPart modelJoint; // Joint to replicate
    public Tilemap associatedTilemapFront;
    public Tilemap associatedTilemapBack;
    public Tilemap associatedTilemapLeft;
    public Tilemap associatedTilemapRight;
    public Tilemap associatedTilemapTop;
    public Tilemap associatedTilemapBottom;
    private MannequinPart[] jointObjects;
    private MannequinPart sourceObject;
    private bool jointSet;

    private void Awake()
    {
        jointObjects = (MannequinPart[])FindObjectsOfType(typeof(MannequinPart));
    }

    private void Update()
    {
        if (jointSet)
        {
            transform.rotation = sourceObject.transform.rotation;
        }
    }

    public void SetRotationSource()
    {
        // Find the same joint on the mannequin and copy its rotation
        foreach (MannequinPart jointObject in jointObjects)
        {
            if (jointObject.gameObject != gameObject && jointObject.bodyPart == modelJoint)
            {
                /*source.weight = 1;
                source.sourceTransform = jointObject.transform;
                rotationConstraint.AddSource(source);*/

                sourceObject = jointObject;
                transform.rotation = sourceObject.transform.rotation;
                jointSet = true;
                break;
            }
        }
    }

    /// <summary>
    /// Get the face of the pixel cube that's facing towards the camera
    /// </summary>
    public GridViews GetFaceToward()
    {
        var toObserver = transform.InverseTransformPoint(Vector3.zero);

        var absolute = new Vector3(
                          Mathf.Abs(toObserver.x),
                          Mathf.Abs(toObserver.y),
                          Mathf.Abs(toObserver.z)
                       );

        switch (modelJoint)
        {
            case BodyPart.LeftArm:
            case BodyPart.LeftForearm:
            case BodyPart.LeftHand:
            case BodyPart.LeftThumb1:
            case BodyPart.LeftThumb2:
            case BodyPart.LeftThumb3:
            case BodyPart.LeftIndex1:
            case BodyPart.LeftIndex2:
            case BodyPart.LeftIndex3:
            case BodyPart.LeftMiddle1:
            case BodyPart.LeftMiddle2:
            case BodyPart.LeftMiddle3:
            case BodyPart.LeftRing1:
            case BodyPart.LeftRing2:
            case BodyPart.LeftRing3:
            case BodyPart.LeftPinky1:
            case BodyPart.LeftPinky2:
            case BodyPart.LeftPinky3:
                if (absolute.x >= absolute.y)
                {
                    if (absolute.x >= absolute.z)
                    {
                        return toObserver.x > 0 ? GridViews.Front : GridViews.Back;
                    }
                    else
                    {
                        return toObserver.z > 0 ? GridViews.Bottom : GridViews.Top;
                    }
                }
                else if (absolute.y >= absolute.z)
                {
                    return toObserver.y > 0 ? GridViews.Left: GridViews.Right;
                }
                else
                {
                    return toObserver.z > 0 ? GridViews.Bottom : GridViews.Top;
                }
            default:
                if (absolute.x >= absolute.y)
                {
                    if (absolute.x >= absolute.z)
                    {
                        return toObserver.x > 0 ? GridViews.Right : GridViews.Left;
                    }
                    else
                    {
                        return toObserver.z > 0 ? GridViews.Front : GridViews.Back;
                    }
                }
                else if (absolute.y >= absolute.z)
                {
                    return toObserver.y > 0 ? GridViews.Top : GridViews.Bottom;
                }
                else
                {
                    return toObserver.z > 0 ? GridViews.Front : GridViews.Back;
                }
        }
    }
}
