using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationButton : MonoBehaviour
{
    public Animator animator;
    public Pixelation pixelation;
    public int clipIndex;
    public string clipName;

    public void SetAnimation()
    {
        animator.SetInteger("animation", clipIndex);

        pixelation.clipName = clipName;
        pixelation.StartAnimationProcess();
    }
}
