using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawingManager : MonoBehaviour
{
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

    [Header("Popups and Misc.")]
    public GameObject colorPicker;
    public GameObject colorPickerBackground;
    [HideInInspector] public Color currentColor;

    [HideInInspector] public DrawModes currentMode;

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
        colorPicker.SetActive(false);
        currentColor = Color.red;
        colorPicker.GetComponent<FlexibleColorPicker>().color = currentColor;
        colorButton.GetComponent<Image>().color = currentColor;

        currentMode = DrawModes.Draw;
    }

    public void OpenColorPicker()
    {
        colorPicker.SetActive(true);
        colorPickerBackground.SetActive(true);
    }

    public void CloseColorPicker()
    {
        colorPicker.SetActive(false);
        colorPickerBackground.SetActive(false);
    }

    public void ChangeColor()
    {
        currentColor = colorPicker.GetComponent<FlexibleColorPicker>().color;
        colorButton.GetComponent<Image>().color = currentColor;
    }
}
