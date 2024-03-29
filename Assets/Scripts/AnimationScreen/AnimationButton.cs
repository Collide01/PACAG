using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class AnimationButton : MonoBehaviour
{
    public Animator animator;
    public AnimatorController animatorController;
    public AnimationClip animationClip;
    public Pixelation pixelation;
    public int clipIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetAnimation()
    {
        AnimatorStateMachine asm = animatorController.layers[0].stateMachine;
        AnimatorState state = asm.states[clipIndex].state;
        asm.defaultState = state;

        pixelation.StartAnimationProcess();
    }
}
