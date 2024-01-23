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
    public GameObject gridView;
    public GameObject colorPicker;
    public GameObject colorPickerBackground;
    [HideInInspector] public Color currentColor;

    [HideInInspector] public DrawModes currentMode;
    [HideInInspector] public GridViews currentView;

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
        currentView = GridViews.Front;
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

    public void ChangeView()
    {
        switch (gridView.GetComponent<Dropdown>().value)
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
}
