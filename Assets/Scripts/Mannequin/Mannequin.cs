using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mannequin : MonoBehaviour
{
    public Pixelation pixelation;
    public MannequinPart basePart;

    public void Init()
    {
        basePart.Init();
    }

    public void CallRemove()
    {
        GetComponentInChildren<MannequinPart>().RemovePixelsAndJoints();
    }
}
