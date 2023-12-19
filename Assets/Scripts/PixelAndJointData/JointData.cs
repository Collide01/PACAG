using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointData : MonoBehaviour
{
    public BodyPart modelJoint; // Joint to replicate
    private MannequinPart[] jointObjects;

    private void Awake()
    {
        jointObjects = (MannequinPart[])FindObjectsOfType(typeof(MannequinPart));
    }

    // Update is called once per frame
    void Update()
    {
        // Find the same joint on the mannequin and copy its rotation
        foreach (MannequinPart jointObject in jointObjects)
        {
            if (jointObject.gameObject != this && jointObject.bodyPart == modelJoint)
            {
                transform.rotation = jointObject.gameObject.transform.rotation;
                break;
            }
        }
    }
}
