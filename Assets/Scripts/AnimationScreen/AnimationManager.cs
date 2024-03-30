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

    // Animation control values; holds previous values so Update can only be clicked if a value changed
    private float prevRotationX;
    private float prevRotationY;
    private float prevRotationZ;
    private int prevFrameRate;

    [Header("UI Elements")]
    public Slider rotationX;
    public Slider rotationY;
    public Slider rotationZ;
    public GameObject rotationModel;
    public GameObject mannequinContainer; // Rotates along with the rotation model
    public TMP_InputField frameRateInput;
    public Button resetToDefaultButton;
    public Button updateButton;

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
        frameRateInput.text = "60";

        prevRotationX = rotationX.value;
        prevRotationY = rotationY.value;
        prevRotationZ = rotationZ.value;
        prevFrameRate = int.Parse(frameRateInput.text);

        rotationModel.transform.rotation = Quaternion.Euler(rotationX.value, rotationY.value, rotationZ.value);
        mannequinContainer.transform.rotation = Quaternion.Euler(rotationX.value, rotationY.value, rotationZ.value);
        characterSettings.frameRate = int.Parse(frameRateInput.text);

        updateButton.interactable = false;
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

    /// <summary>
    /// Checks to see if any of the animation control values changed since the last update. 
    /// If they did, the Update button is enabled.
    /// </summary>
    public void OnValueChanged()
    {
        if (rotationX.value != prevRotationX || rotationX.value != prevRotationY || rotationY.value != prevRotationZ || characterSettings.frameRate != prevFrameRate)
        {
            updateButton.interactable = true;
        }
        else
        {
            updateButton.interactable = false;
        }
    }

    public void ResetToDefault()
    {
        rotationX.value = 0;
        rotationY.value = 0;
        rotationZ.value = 0;
        frameRateInput.text = "60";

        rotationModel.transform.rotation = Quaternion.Euler(rotationX.value, rotationY.value, rotationZ.value);
        characterSettings.frameRate = int.Parse(frameRateInput.text);
    }

    /// <summary>
    /// Updates the animation when the Update button is clicked
    /// </summary>
    public void OnUpdate()
    {
        mannequinContainer.transform.rotation = Quaternion.Euler(rotationX.value, rotationY.value, rotationZ.value);

        prevRotationX = rotationX.value;
        prevRotationY = rotationY.value;
        prevRotationZ = rotationZ.value;
        prevFrameRate = int.Parse(frameRateInput.text);

        updateButton.interactable = false;

        pixelation.StartAnimationProcess();
    }
}
