using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    /// Get a list of the 3 closest faces towards the camera
    /// </summary>
    public List<GridViews> GetFaceToward()
    {
        var toObserver = transform.InverseTransformPoint(Vector3.zero);

        var absolute = new Vector3(
                          Mathf.Abs(toObserver.x),
                          Mathf.Abs(toObserver.y),
                          Mathf.Abs(toObserver.z)
                       );

        List<GridViews> closestViews = new List<GridViews>();

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
                if (absolute.x >= absolute.y && absolute.x >= absolute.z)
                {
                    closestViews.Add(toObserver.x > 0 ? GridViews.Front : GridViews.Back);
                    if (absolute.y >= absolute.z)
                    {
                        closestViews.Add(toObserver.y > 0 ? GridViews.Left : GridViews.Right);
                        closestViews.Add(toObserver.z > 0 ? GridViews.Bottom : GridViews.Top);
                    }
                    else
                    {
                        closestViews.Add(toObserver.z > 0 ? GridViews.Bottom : GridViews.Top);
                        closestViews.Add(toObserver.y > 0 ? GridViews.Left : GridViews.Right);
                    }
                }
                else if (absolute.y > absolute.x && absolute.y >= absolute.z)
                {
                    closestViews.Add(toObserver.y > 0 ? GridViews.Left : GridViews.Right);
                    if (absolute.x >= absolute.z)
                    {
                        closestViews.Add(toObserver.x > 0 ? GridViews.Front : GridViews.Back);
                        closestViews.Add(toObserver.z > 0 ? GridViews.Bottom : GridViews.Top);
                    }
                    else
                    {
                        closestViews.Add(toObserver.z > 0 ? GridViews.Bottom : GridViews.Top);
                        closestViews.Add(toObserver.x > 0 ? GridViews.Front : GridViews.Back);
                    }
                }
                else
                {
                    closestViews.Add(toObserver.z > 0 ? GridViews.Bottom : GridViews.Top);
                    if (absolute.x >= absolute.y)
                    {
                        closestViews.Add(toObserver.x > 0 ? GridViews.Front : GridViews.Back);
                        closestViews.Add(toObserver.y > 0 ? GridViews.Left : GridViews.Right);
                    }
                    else
                    {
                        closestViews.Add(toObserver.y > 0 ? GridViews.Left : GridViews.Right);
                        closestViews.Add(toObserver.x > 0 ? GridViews.Front : GridViews.Back);
                    }
                }
                break;
            case BodyPart.RightArm:
            case BodyPart.RightForearm:
            case BodyPart.RightHand:
            case BodyPart.RightThumb1:
            case BodyPart.RightThumb2:
            case BodyPart.RightThumb3:
            case BodyPart.RightIndex1:
            case BodyPart.RightIndex2:
            case BodyPart.RightIndex3:
            case BodyPart.RightMiddle1:
            case BodyPart.RightMiddle2:
            case BodyPart.RightMiddle3:
            case BodyPart.RightRing1:
            case BodyPart.RightRing2:
            case BodyPart.RightRing3:
            case BodyPart.RightPinky1:
            case BodyPart.RightPinky2:
            case BodyPart.RightPinky3:
                if (absolute.x >= absolute.y && absolute.x >= absolute.z)
                {
                    closestViews.Add(toObserver.x > 0 ? GridViews.Back : GridViews.Front);
                    if (absolute.y >= absolute.z)
                    {
                        closestViews.Add(toObserver.y > 0 ? GridViews.Right : GridViews.Left);
                        closestViews.Add(toObserver.z > 0 ? GridViews.Bottom : GridViews.Top);
                    }
                    else
                    {
                        closestViews.Add(toObserver.z > 0 ? GridViews.Bottom : GridViews.Top);
                        closestViews.Add(toObserver.y > 0 ? GridViews.Right : GridViews.Left);
                    }
                }
                else if (absolute.y > absolute.x && absolute.y >= absolute.z)
                {
                    closestViews.Add(toObserver.y > 0 ? GridViews.Right : GridViews.Left);
                    if (absolute.x >= absolute.z)
                    {
                        closestViews.Add(toObserver.x > 0 ? GridViews.Back : GridViews.Front);
                        closestViews.Add(toObserver.z > 0 ? GridViews.Bottom : GridViews.Top);
                    }
                    else
                    {
                        closestViews.Add(toObserver.z > 0 ? GridViews.Bottom : GridViews.Top);
                        closestViews.Add(toObserver.x > 0 ? GridViews.Back : GridViews.Front);
                    }
                }
                else
                {
                    closestViews.Add(toObserver.z > 0 ? GridViews.Bottom : GridViews.Top);
                    if (absolute.x >= absolute.y)
                    {
                        closestViews.Add(toObserver.x > 0 ? GridViews.Back : GridViews.Front);
                        closestViews.Add(toObserver.y > 0 ? GridViews.Right : GridViews.Left);
                    }
                    else
                    {
                        closestViews.Add(toObserver.y > 0 ? GridViews.Right : GridViews.Left);
                        closestViews.Add(toObserver.x > 0 ? GridViews.Back : GridViews.Front);
                    }
                }
                break;
            case BodyPart.LeftUpLeg:
            case BodyPart.LeftLeg:
            case BodyPart.RightUpLeg:
            case BodyPart.RightLeg:
                if (absolute.x >= absolute.y && absolute.x >= absolute.z)
                {
                    closestViews.Add(toObserver.x > 0 ? GridViews.Left : GridViews.Right);
                    if (absolute.y >= absolute.z)
                    {
                        closestViews.Add(toObserver.y > 0 ? GridViews.Bottom : GridViews.Top);
                        closestViews.Add(toObserver.z > 0 ? GridViews.Front : GridViews.Back);
                    }
                    else
                    {
                        closestViews.Add(toObserver.z > 0 ? GridViews.Front : GridViews.Back);
                        closestViews.Add(toObserver.y > 0 ? GridViews.Bottom : GridViews.Top);
                    }
                }
                else if (absolute.y > absolute.x && absolute.y >= absolute.z)
                {
                    closestViews.Add(toObserver.y > 0 ? GridViews.Bottom : GridViews.Top);
                    if (absolute.x >= absolute.z)
                    {
                        closestViews.Add(toObserver.x > 0 ? GridViews.Left : GridViews.Right);
                        closestViews.Add(toObserver.z > 0 ? GridViews.Front : GridViews.Back);
                    }
                    else
                    {
                        closestViews.Add(toObserver.z > 0 ? GridViews.Front : GridViews.Back);
                        closestViews.Add(toObserver.x > 0 ? GridViews.Left : GridViews.Right);
                    }
                }
                else
                {
                    closestViews.Add(toObserver.z > 0 ? GridViews.Front : GridViews.Back);
                    if (absolute.x >= absolute.y)
                    {
                        closestViews.Add(toObserver.x > 0 ? GridViews.Left : GridViews.Right);
                        closestViews.Add(toObserver.y > 0 ? GridViews.Bottom : GridViews.Top);
                    }
                    else
                    {
                        closestViews.Add(toObserver.y > 0 ? GridViews.Bottom : GridViews.Top);
                        closestViews.Add(toObserver.x > 0 ? GridViews.Left : GridViews.Right);
                    }
                }/*
                if (absolute.x >= absolute.y)
                {
                    if (absolute.x >= absolute.z)
                    {
                        return toObserver.x > 0 ? GridViews.Left : GridViews.Right;
                    }
                    else
                    {
                        return toObserver.z > 0 ? GridViews.Front : GridViews.Back;
                    }
                }
                else if (absolute.y >= absolute.z)
                {
                    return toObserver.y > 0 ? GridViews.Bottom : GridViews.Top;
                }
                else
                {
                    return toObserver.z > 0 ? GridViews.Front : GridViews.Back;
                }*/
                break;
            case BodyPart.LeftFoot:
            case BodyPart.LeftToeBase:
            case BodyPart.RightFoot:
            case BodyPart.RightToeBase:
                if (absolute.x >= absolute.y && absolute.x >= absolute.z)
                {
                    closestViews.Add(toObserver.x > 0 ? GridViews.Left : GridViews.Right);
                    if (absolute.y >= absolute.z)
                    {
                        closestViews.Add(toObserver.y > 0 ? GridViews.Front : GridViews.Back);
                        closestViews.Add(toObserver.z > 0 ? GridViews.Top : GridViews.Bottom);
                    }
                    else
                    {
                        closestViews.Add(toObserver.z > 0 ? GridViews.Top : GridViews.Bottom);
                        closestViews.Add(toObserver.y > 0 ? GridViews.Front : GridViews.Back);
                    }
                }
                else if (absolute.y > absolute.x && absolute.y >= absolute.z)
                {
                    closestViews.Add(toObserver.y > 0 ? GridViews.Front : GridViews.Back);
                    if (absolute.x >= absolute.z)
                    {
                        closestViews.Add(toObserver.x > 0 ? GridViews.Left : GridViews.Right);
                        closestViews.Add(toObserver.z > 0 ? GridViews.Top : GridViews.Bottom);
                    }
                    else
                    {
                        closestViews.Add(toObserver.z > 0 ? GridViews.Top : GridViews.Bottom);
                        closestViews.Add(toObserver.x > 0 ? GridViews.Left : GridViews.Right);
                    }
                }
                else
                {
                    closestViews.Add(toObserver.z > 0 ? GridViews.Top : GridViews.Bottom);
                    if (absolute.x >= absolute.y)
                    {
                        closestViews.Add(toObserver.x > 0 ? GridViews.Left : GridViews.Right);
                        closestViews.Add(toObserver.y > 0 ? GridViews.Front : GridViews.Back);
                    }
                    else
                    {
                        closestViews.Add(toObserver.y > 0 ? GridViews.Front : GridViews.Back);
                        closestViews.Add(toObserver.x > 0 ? GridViews.Left : GridViews.Right);
                    }
                }
                /*if (absolute.x >= absolute.y)
                {
                    if (absolute.x >= absolute.z)
                    {
                        return toObserver.x > 0 ? GridViews.Left : GridViews.Right;
                    }
                    else
                    {
                        return toObserver.z > 0 ? GridViews.Top : GridViews.Bottom;
                    }
                }
                else if (absolute.y >= absolute.z)
                {
                    return toObserver.y > 0 ? GridViews.Front : GridViews.Back;
                }
                else
                {
                    return toObserver.z > 0 ? GridViews.Top : GridViews.Bottom;
                }*/
                break;
            default:
                if (absolute.x >= absolute.y && absolute.x >= absolute.z)
                {
                    closestViews.Add(toObserver.x > 0 ? GridViews.Right : GridViews.Left);
                    if (absolute.y >= absolute.z)
                    {
                        closestViews.Add(toObserver.y > 0 ? GridViews.Top : GridViews.Bottom);
                        closestViews.Add(toObserver.z > 0 ? GridViews.Front : GridViews.Back);
                    }
                    else
                    {
                        closestViews.Add(toObserver.z > 0 ? GridViews.Front : GridViews.Back);
                        closestViews.Add(toObserver.y > 0 ? GridViews.Top : GridViews.Bottom);
                    }
                }
                else if (absolute.y > absolute.x && absolute.y >= absolute.z)
                {
                    closestViews.Add(toObserver.y > 0 ? GridViews.Top : GridViews.Bottom);
                    if (absolute.x >= absolute.z)
                    {
                        closestViews.Add(toObserver.x > 0 ? GridViews.Right : GridViews.Left);
                        closestViews.Add(toObserver.z > 0 ? GridViews.Front : GridViews.Back);
                    }
                    else
                    {
                        closestViews.Add(toObserver.z > 0 ? GridViews.Front : GridViews.Back);
                        closestViews.Add(toObserver.x > 0 ? GridViews.Right : GridViews.Left);
                    }
                }
                else
                {
                    closestViews.Add(toObserver.z > 0 ? GridViews.Front : GridViews.Back);
                    if (absolute.x >= absolute.y)
                    {
                        closestViews.Add(toObserver.x > 0 ? GridViews.Right : GridViews.Left);
                        closestViews.Add(toObserver.y > 0 ? GridViews.Top : GridViews.Bottom);
                    }
                    else
                    {
                        closestViews.Add(toObserver.y > 0 ? GridViews.Top : GridViews.Bottom);
                        closestViews.Add(toObserver.x > 0 ? GridViews.Right : GridViews.Left);
                    }
                }
                /*if (absolute.x >= absolute.y)
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
                }*/
                break;
        }
        return closestViews;
    }
}
