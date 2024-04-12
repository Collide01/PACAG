using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using TMPro;
using JetBrains.Annotations;

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

    // These are used to find the max size of the sprite and the coordinates of the pixels on the tilemap
    private int maxSpriteSizeX;
    private int maxSpriteSizeY;

    [Header("UI Elements")]
    public Slider rotationX;
    public Slider rotationY;
    public Slider rotationZ;
    public GameObject rotationModel;
    public GameObject mannequinContainer; // Rotates along with the rotation model
    public GameObject loadingSymbol;
    public TMP_InputField frameRateInput;
    public Button resetToDefaultButton;
    public Button updateButton;
    public Button editButton;
    public Button exportButton;
    public TMP_Text infoText;

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
        loadingSymbol.SetActive(false);

        int numberOfAnimations = mannequinAnimator.runtimeAnimatorController.animationClips.Length;
        
        // Fills the scroll list of all available animations
        for (int i = 0; i < numberOfAnimations; i++)
        {
            GameObject animationButtonInstance = Instantiate(animationButton, listContent.transform);
            animationButtonInstance.GetComponent<RectTransform>().anchoredPosition = new Vector2(-135, -10 - (i * 20));
            animationButtonInstance.GetComponentInChildren<TMP_Text>().text = mannequinAnimator.runtimeAnimatorController.animationClips[i].name;
            animationButtonInstance.GetComponent<AnimationButton>().animator = mannequinAnimator;
            animationButtonInstance.GetComponent<AnimationButton>().animatorController = animatorController;
            animationButtonInstance.GetComponent<AnimationButton>().animationClip = mannequinAnimator.runtimeAnimatorController.animationClips[i];
            animationButtonInstance.GetComponent<AnimationButton>().pixelation = pixelation;
            animationButtonInstance.GetComponent<AnimationButton>().clipIndex = i;
            animationButtonInstance.GetComponent<Button>().onClick.AddListener(delegate { animationButtonInstance.GetComponent<AnimationButton>().SetAnimation(); });
        }

        infoText.text = "Select an animation.";

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
        editButton.interactable = false;
        exportButton.interactable = false;

        StartCoroutine(CheckForAnimation());
    }

    public IEnumerator CheckForAnimation()
    {
        while(true)
        {
            if (pixelation.animationFrames.Count > 0 && pixelation.animationSet)
            {
                loadingSymbol.SetActive(false);
                editButton.interactable = true;
                exportButton.interactable = true;

                if (maxSpriteSizeX == 0 && maxSpriteSizeY == 0)
                {
                    int minX = 0, minY = 0, maxX = 0, maxY = 0;
                    // Loops through all of the tile positions for every sprite to find the maximum possible size for each sprite.
                    for (int i = 0; i < pixelation.cellPositions.Count; i++) // pixelation.cellPositions.Count represents the number of frames
                    {
                        // Loop through each cell to determine the max and min of the width and height of sprite
                        for (int j = 0; j < pixelation.cellPositions[i].Count; j++)
                        {
                            if (pixelation.cellPositions[i][j].x < minX)
                            {
                                minX = pixelation.cellPositions[i][j].x;
                            }
                            if (pixelation.cellPositions[i][j].x > maxX)
                            {
                                maxX = pixelation.cellPositions[i][j].x;
                            }
                            if (pixelation.cellPositions[i][j].y < minY)
                            {
                                minY = pixelation.cellPositions[i][j].y;
                            }
                            if (pixelation.cellPositions[i][j].y > maxY)
                            {
                                maxY = pixelation.cellPositions[i][j].y;
                            }
                        }

                        // Checks to see if this is the biggest sprite so far
                        if (maxX - minX > maxSpriteSizeX)
                        {
                            maxSpriteSizeX = maxX - minX;
                        }
                        if (maxY - minY > maxSpriteSizeY)
                        {
                            maxSpriteSizeY = maxY - minY;
                        }
                    }

                    infoText.text = "Sprite Sheet Cell Size: " + maxSpriteSizeX + " x " + maxSpriteSizeY;
                }
            }
            else
            {
                if (pixelation.animationFrames.Count > 0) loadingSymbol.SetActive(true);
                editButton.interactable = false;
                exportButton.interactable = false;

                maxSpriteSizeX = 0;
                maxSpriteSizeY = 0;
            }

            yield return null;
        }
    }

    public void OnRotationChanged()
    {
        rotationModel.transform.rotation = Quaternion.Euler(rotationX.value, rotationY.value, rotationZ.value);
    }

    public void OnFrameRateChanged()
    {
        if (int.Parse(frameRateInput.text) < 1)
        {
            frameRateInput.text = "1";
        }
        if (int.Parse(frameRateInput.text) > 60)
        {
            frameRateInput.text = "60";
        }
    }

    /// <summary>
    /// Checks to see if any of the animation control values changed since the last update. 
    /// If they did, the Update button is enabled.
    /// </summary>
    public void OnValueChanged()
    {
        if (rotationX.value != prevRotationX || rotationX.value != prevRotationY || rotationY.value != prevRotationZ || int.Parse(frameRateInput.text) != prevFrameRate)
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
    }

    /// <summary>
    /// Updates the animation when the Update button is clicked
    /// </summary>
    public void OnUpdate()
    {
        mannequinContainer.transform.rotation = Quaternion.Euler(rotationX.value, rotationY.value, rotationZ.value);
        characterSettings.frameRate = int.Parse(frameRateInput.text);

        prevRotationX = rotationX.value;
        prevRotationY = rotationY.value;
        prevRotationZ = rotationZ.value;
        prevFrameRate = int.Parse(frameRateInput.text);

        updateButton.interactable = false;

        pixelation.StartAnimationProcess();
    }
}
