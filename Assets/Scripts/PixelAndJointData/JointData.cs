using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Animations;

public class JointData : MonoBehaviour
{
    public BodyPart modelJoint; // Joint to replicate
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
