using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DrawingManager : MonoBehaviour
{
    [Header("Managers and Settings")]
    private CharacterSettings characterSettings;

    [Header("Grids")]
    public GameObject frontGrid;
    public GameObject backGrid;
    public GameObject leftGrid;
    public GameObject rightGrid;
    public GameObject topGrid;
    public GameObject bottomGrid;

    [Header("Buttons")]
    public Button drawButton;
    public Button eraseButton;
    public Button colorButton;

    [Header("Dimension Inputs")]
    public TMP_InputField headX;
    public TMP_InputField headY;
    public TMP_InputField headZ;
    public TMP_InputField torsoX;
    public TMP_InputField torsoY;
    public TMP_InputField torsoZ;
    public TMP_InputField leftArmX;
    public TMP_InputField leftArmY;
    public TMP_InputField leftArmZ;
    public TMP_InputField rightArmX;
    public TMP_InputField rightArmY;
    public TMP_InputField rightArmZ;
    public TMP_InputField leftLegX;
    public TMP_InputField leftLegY;
    public TMP_InputField leftLegZ;
    public TMP_InputField rightLegX;
    public TMP_InputField rightLegY;
    public TMP_InputField rightLegZ;

    [Header("Popups and Misc.")]
    public TMP_Dropdown gridView;
    public GameObject colorPicker;
    public GameObject colorPickerBackground;
    [HideInInspector] public Color currentColor;

    [HideInInspector] public DrawModes currentMode;
    [HideInInspector] public GridViews currentView;
    [HideInInspector] public bool changingColors;
    [HideInInspector] public bool mouseInDrawField;

    // Start is called before the first frame update
    void Start()
    {
        characterSettings = GameObject.FindGameObjectWithTag("CharacterSettings").GetComponent<CharacterSettings>();
    }

    // This sets the settings to their default state
    public void Init()
    {
        frontGrid.SetActive(true);
        backGrid.SetActive(false);
        leftGrid.SetActive(false);
        rightGrid.SetActive(false);
        topGrid.SetActive(false);
        bottomGrid.SetActive(false);

        drawButton.interactable = false;
        eraseButton.interactable = true;
        colorButton.interactable = true;

        headX.text = characterSettings.headSize.x.ToString();
        headY.text = characterSettings.headSize.y.ToString();
        headZ.text = characterSettings.headSize.z.ToString();
        torsoX.text = characterSettings.torsoSize.x.ToString();
        torsoY.text = characterSettings.torsoSize.y.ToString();
        torsoZ.text = characterSettings.torsoSize.z.ToString();
        leftArmX.text = characterSettings.leftArmSize.x.ToString();
        leftArmY.text = characterSettings.leftArmSize.y.ToString();
        leftArmZ.text = characterSettings.leftArmSize.z.ToString();
        rightArmX.text = characterSettings.rightArmSize.x.ToString();
        rightArmY.text = characterSettings.rightArmSize.y.ToString();
        rightArmZ.text = characterSettings.rightArmSize.z.ToString();
        leftLegX.text = characterSettings.leftLegSize.x.ToString();
        leftLegY.text = characterSettings.leftLegSize.y.ToString();
        leftLegZ.text = characterSettings.leftLegSize.z.ToString();
        rightLegX.text = characterSettings.rightLegSize.x.ToString();
        rightLegY.text = characterSettings.rightLegSize.y.ToString();
        rightLegZ.text = characterSettings.rightLegSize.z.ToString();

        colorPicker.SetActive(false);
        colorPickerBackground.SetActive(false);
        currentColor = Color.red;
        colorPicker.GetComponent<FlexibleColorPicker>().color = currentColor;
        colorButton.GetComponent<Image>().color = currentColor;
        mouseInDrawField = true;

        currentMode = DrawModes.Draw;
        currentView = GridViews.Front;
    }

    public void ChangeDrawMode(int modeID)
    {
        switch (modeID)
        {
            case 0:
                drawButton.interactable = false;
                eraseButton.interactable = true;
                currentMode = DrawModes.Draw;
                break;
            case 1:
                drawButton.interactable = true;
                eraseButton.interactable = false;
                currentMode = DrawModes.Erase;
                break;
        }
    }

    public void OpenColorPicker()
    {
        colorPicker.SetActive(true);
        colorPickerBackground.SetActive(true);
        changingColors = true;
    }

    public void CloseColorPicker()
    {
        colorPicker.SetActive(false);
        colorPickerBackground.SetActive(false);
        changingColors = false;
        ChangeColor();
    }

    public void ChangeColor()
    {
        currentColor = colorPicker.GetComponent<FlexibleColorPicker>().color;
        colorButton.GetComponent<Image>().color = currentColor;
    }

    public void ChangeView()
    {
        switch (gridView.value)
        {
            case 0: // Front
                frontGrid.SetActive(true);
                backGrid.SetActive(false);
                leftGrid.SetActive(false);
                rightGrid.SetActive(false);
                topGrid.SetActive(false);
                bottomGrid.SetActive(false);

                currentView = GridViews.Front;
                break;
            case 1: // Back
                frontGrid.SetActive(false);
                backGrid.SetActive(true);
                leftGrid.SetActive(false);
                rightGrid.SetActive(false);
                topGrid.SetActive(false);
                bottomGrid.SetActive(false);

                currentView = GridViews.Back;
                break;
            case 2: // Left
                frontGrid.SetActive(false);
                backGrid.SetActive(false);
                leftGrid.SetActive(true);
                rightGrid.SetActive(false);
                topGrid.SetActive(false);
                bottomGrid.SetActive(false);

                currentView = GridViews.Left;
                break;
            case 3: // Right
                frontGrid.SetActive(false);
                backGrid.SetActive(false);
                leftGrid.SetActive(false);
                rightGrid.SetActive(true);
                topGrid.SetActive(false);
                bottomGrid.SetActive(false);

                currentView = GridViews.Right;
                break;
            case 4: // Top
                frontGrid.SetActive(false);
                backGrid.SetActive(false);
                leftGrid.SetActive(false);
                rightGrid.SetActive(false);
                topGrid.SetActive(true);
                bottomGrid.SetActive(false);

                currentView = GridViews.Top;
                break;
            case 5: // Bottom
                frontGrid.SetActive(false);
                backGrid.SetActive(false);
                leftGrid.SetActive(false);
                rightGrid.SetActive(false);
                topGrid.SetActive(false);
                bottomGrid.SetActive(true);

                currentView = GridViews.Bottom;
                break;
        }
    }

    public void MouseInDrawField(bool param)
    {
        mouseInDrawField = param;
    }
}
