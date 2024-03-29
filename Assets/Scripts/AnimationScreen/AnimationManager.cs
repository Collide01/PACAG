using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using TMPro;

public class AnimationManager : MonoBehaviour
{
    public Animator mannequinAnimator;
    public AnimatorController animatorController;
    public GameObject animationGrid;
    private Tilemap animationTilemap;
    private Pixelation pixelation;


    [Header("Animation List")]
    public GameObject animationButton; // Selectable animation in scroll view
    public GameObject listContent;

    // Start is called before the first frame update
    void Start()
    {
        animationTilemap = animationGrid.GetComponentInChildren<Tilemap>();
        pixelation = animationGrid.GetComponent<Pixelation>();
    }

    public void Init()
    {
        int numberOfAnimations = mannequinAnimator.runtimeAnimatorController.animationClips.Length;
        
        // Fills the scroll list of all available animations
        for (int i = 0; i < numberOfAnimations; i++)
        {
            GameObject animationButtonInstance = Instantiate(animationButton, listContent.transform);
            animationButtonInstance.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 185 - (i * 30));
            animationButtonInstance.GetComponentInChildren<TMP_Text>().text = mannequinAnimator.runtimeAnimatorController.animationClips[i].name;
            animationButtonInstance.GetComponent<AnimationButton>().animator = mannequinAnimator;
            animationButtonInstance.GetComponent<AnimationButton>().animatorController = animatorController;
            animationButtonInstance.GetComponent<AnimationButton>().animationClip = mannequinAnimator.runtimeAnimatorController.animationClips[i];
            animationButtonInstance.GetComponent<AnimationButton>().pixelation = pixelation;
            animationButtonInstance.GetComponent<AnimationButton>().clipIndex = i;
            animationButtonInstance.GetComponent<Button>().onClick.AddListener(delegate { animationButtonInstance.GetComponent<AnimationButton>().SetAnimation(); });
        }
    }
}
