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

    /// <summary>
    /// The function that AnimationEvents call as the animation plays.
    /// AnimationEvents are used to make the sprite rendering more accurate.
    /// </summary>
    public void AnimationEventFunction(int frame)
    {
        pixelation.AnimationEventFunction(frame);
    }

    public void CallRemove()
    {
        GetComponentInChildren<MannequinPart>().RemovePixelsAndJoints();
    }
}
