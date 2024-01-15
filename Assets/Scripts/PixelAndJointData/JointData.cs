using System.Collections;
using System.Collections.Generic;
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
}
