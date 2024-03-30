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
    private CharacterSettings characterSettings;

    [Header("UI Elements")]
    public Slider rotationX;
    public Slider rotationY;
    public Slider rotationZ;
    public GameObject rotationModel;
    public GameObject mannequinContainer; // Rotates along with the rotation model
    public TMP_InputField frameRateInput;

    [Header("Animation List")]
    public GameObject animationButton; // Selectable animation in scroll view
    public GameObject listContent;

    // Start is called before the first frame update
    void Start()
    {
        animationTilemap = animationGrid.GetComponentInChildren<Tilemap>();
        pixelation = animationGrid.GetComponent<Pixelation>();
        characterSettings = GameObject.FindGameObjectWithTag("CharacterSettings").GetComponent<CharacterSettings>();
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

        // Resets all values to their defaults
        rotationX.value = 0;
        rotationY.value = 0;
        rotationZ.value = 0;
        frameRateInput.text = characterSettings.frameRate.ToString();
    }

    public void OnRotationChanged()
    {
        rotationModel.transform.rotation = Quaternion.Euler(rotationX.value, rotationY.value, rotationZ.value);
        mannequinContainer.transform.rotation = Quaternion.Euler(rotationX.value, rotationY.value, rotationZ.value);
    }

    public void OnFrameRateChanged()
    {
        characterSettings.frameRate = int.Parse(frameRateInput.text);
    }
}
