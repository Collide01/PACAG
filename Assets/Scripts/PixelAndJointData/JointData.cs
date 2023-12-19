using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class JointData : MonoBehaviour
{
    [HideInInspector] public bool jointSet;
    public BodyPart modelJoint; // Joint to replicate
    public RotationConstraint rotationConstraint;
    private ConstraintSource source;
    private MannequinPart[] jointObjects;

    private void Awake()
    {
        jointObjects = (MannequinPart[])FindObjectsOfType(typeof(MannequinPart));
    }

    // Update is called once per frame
    void Update()
    {
        if (jointSet)
        {
            // Find the same joint on the mannequin and copy its rotation
            foreach (MannequinPart jointObject in jointObjects)
            {
                if (jointObject.gameObject != gameObject && jointObject.bodyPart == modelJoint)
                {
                    source.weight = 1;
                    source.sourceTransform = jointObject.transform;
                    rotationConstraint.AddSource(source);
                    jointSet = false;
                    break;
                }
            }
        }
    }
}
