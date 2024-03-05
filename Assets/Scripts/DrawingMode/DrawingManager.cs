using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Experimental.GraphView;

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
    public TMP_InputField leftHandX;
    public TMP_InputField leftHandY;
    public TMP_InputField leftHandZ;
    public TMP_InputField leftThumbX;
    public TMP_InputField leftThumbY;
    public TMP_InputField leftThumbZ;
    public TMP_InputField leftIndexX;
    public TMP_InputField leftIndexY;
    public TMP_InputField leftIndexZ;
    public TMP_InputField leftMiddleX;
    public TMP_InputField leftMiddleY;
    public TMP_InputField leftMiddleZ;
    public TMP_InputField leftRingX;
    public TMP_InputField leftRingY;
    public TMP_InputField leftRingZ;
    public TMP_InputField leftPinkyX;
    public TMP_InputField leftPinkyY;
    public TMP_InputField leftPinkyZ;
    public TMP_InputField rightArmX;
    public TMP_InputField rightArmY;
    public TMP_InputField rightArmZ;
    public TMP_InputField rightHandX;
    public TMP_InputField rightHandY;
    public TMP_InputField rightHandZ;
    public TMP_InputField rightThumbX;
    public TMP_InputField rightThumbY;
    public TMP_InputField rightThumbZ;
    public TMP_InputField rightIndexX;
    public TMP_InputField rightIndexY;
    public TMP_InputField rightIndexZ;
    public TMP_InputField rightMiddleX;
    public TMP_InputField rightMiddleY;
    public TMP_InputField rightMiddleZ;
    public TMP_InputField rightRingX;
    public TMP_InputField rightRingY;
    public TMP_InputField rightRingZ;
    public TMP_InputField rightPinkyX;
    public TMP_InputField rightPinkyY;
    public TMP_InputField rightPinkyZ;
    public TMP_InputField leftLegX;
    public TMP_InputField leftLegY;
    public TMP_InputField leftLegZ;
    public TMP_InputField leftFootX;
    public TMP_InputField leftFootY;
    public TMP_InputField leftFootZ;
    public TMP_InputField rightLegX;
    public TMP_InputField rightLegY;
    public TMP_InputField rightLegZ;
    public TMP_InputField rightFootX;
    public TMP_InputField rightFootY;
    public TMP_InputField rightFootZ;

    [Header("Draw Borders")]
    public GameObject drawBorders;
    public SpriteRenderer headBorder;
    public SpriteRenderer torsoBorder;
    public SpriteRenderer leftArmBorder;
    public SpriteRenderer leftHandBorder;
    public SpriteRenderer leftThumbBorder;
    public SpriteRenderer leftIndexBorder;
    public SpriteRenderer leftMiddleBorder;
    public SpriteRenderer leftRingBorder;
    public SpriteRenderer leftPinkyBorder;
    public SpriteRenderer rightArmBorder;
    public SpriteRenderer rightHandBorder;
    public SpriteRenderer rightThumbBorder;
    public SpriteRenderer rightIndexBorder;
    public SpriteRenderer rightMiddleBorder;
    public SpriteRenderer rightRingBorder;
    public SpriteRenderer rightPinkyBorder;
    public SpriteRenderer leftLegBorder;
    public SpriteRenderer leftFootBorder;
    public SpriteRenderer rightLegBorder;
    public SpriteRenderer rightFootBorder;

    [Header("Popups and Misc.")]
    public TMP_Dropdown gridView;
    public GameObject colorPicker;
    public GameObject colorPickerBackground;
    [HideInInspector] public Color currentColor;

    [HideInInspector] public DrawModes currentMode;
    [HideInInspector] public GridViews currentView;
    [HideInInspector] public bool changingColors;
    [HideInInspector] public bool mouseInDrawField;
    [HideInInspector] public bool mouseInBorder;
    [HideInInspector] public Tilemap currentTilemap;

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
        leftHandX.text = characterSettings.leftHandSize.x.ToString();
        leftHandY.text = characterSettings.leftHandSize.y.ToString();
        leftHandZ.text = characterSettings.leftHandSize.z.ToString();
        leftThumbX.text = characterSettings.leftThumbSize.x.ToString();
        leftThumbY.text = characterSettings.leftThumbSize.y.ToString();
        leftThumbZ.text = characterSettings.leftThumbSize.z.ToString();
        leftIndexX.text = characterSettings.leftIndexSize.x.ToString();
        leftIndexY.text = characterSettings.leftIndexSize.y.ToString();
        leftIndexZ.text = characterSettings.leftIndexSize.z.ToString();
        leftMiddleX.text = characterSettings.leftMiddleSize.x.ToString();
        leftMiddleY.text = characterSettings.leftMiddleSize.y.ToString();
        leftMiddleZ.text = characterSettings.leftMiddleSize.z.ToString();
        leftRingX.text = characterSettings.leftRingSize.x.ToString();
        leftRingY.text = characterSettings.leftRingSize.y.ToString();
        leftRingZ.text = characterSettings.leftRingSize.z.ToString();
        leftPinkyX.text = characterSettings.leftPinkySize.x.ToString();
        leftPinkyY.text = characterSettings.leftPinkySize.y.ToString();
        leftPinkyZ.text = characterSettings.leftPinkySize.z.ToString();
        rightArmX.text = characterSettings.rightArmSize.x.ToString();
        rightArmY.text = characterSettings.rightArmSize.y.ToString();
        rightArmZ.text = characterSettings.rightArmSize.z.ToString();
        rightHandX.text = characterSettings.rightHandSize.x.ToString();
        rightHandY.text = characterSettings.rightHandSize.y.ToString();
        rightHandZ.text = characterSettings.rightHandSize.z.ToString();
        rightThumbX.text = characterSettings.rightThumbSize.x.ToString();
        rightThumbY.text = characterSettings.rightThumbSize.y.ToString();
        rightThumbZ.text = characterSettings.rightThumbSize.z.ToString();
        rightIndexX.text = characterSettings.rightIndexSize.x.ToString();
        rightIndexY.text = characterSettings.rightIndexSize.y.ToString();
        rightIndexZ.text = characterSettings.rightIndexSize.z.ToString();
        rightMiddleX.text = characterSettings.rightMiddleSize.x.ToString();
        rightMiddleY.text = characterSettings.rightMiddleSize.y.ToString();
        rightMiddleZ.text = characterSettings.rightMiddleSize.z.ToString();
        rightRingX.text = characterSettings.rightRingSize.x.ToString();
        rightRingY.text = characterSettings.rightRingSize.y.ToString();
        rightRingZ.text = characterSettings.rightRingSize.z.ToString();
        rightPinkyX.text = characterSettings.rightPinkySize.x.ToString();
        rightPinkyY.text = characterSettings.rightPinkySize.y.ToString();
        rightPinkyZ.text = characterSettings.rightPinkySize.z.ToString();
        leftLegX.text = characterSettings.leftLegSize.x.ToString();
        leftLegY.text = characterSettings.leftLegSize.y.ToString();
        leftLegZ.text = characterSettings.leftLegSize.z.ToString();
        leftFootX.text = characterSettings.leftFootSize.x.ToString();
        leftFootY.text = characterSettings.leftFootSize.y.ToString();
        leftFootZ.text = characterSettings.leftFootSize.z.ToString();
        rightLegX.text = characterSettings.rightLegSize.x.ToString();
        rightLegY.text = characterSettings.rightLegSize.y.ToString();
        rightLegZ.text = characterSettings.rightLegSize.z.ToString();
        rightFootX.text = characterSettings.rightFootSize.x.ToString();
        rightFootY.text = characterSettings.rightFootSize.y.ToString();
        rightFootZ.text = characterSettings.rightFootSize.z.ToString();
        ChangeBorderSizes();

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
        ChangeBorderSizes();
    }

    public void MouseInDrawField(bool param)
    {
        mouseInDrawField = param;
    }

    public void UpdateCharacterSizes()
    {
        characterSettings.headSize.x = int.Parse(headX.text);
        characterSettings.headSize.y = int.Parse(headY.text);
        characterSettings.headSize.z = int.Parse(headZ.text);
        characterSettings.torsoSize.x = int.Parse(torsoX.text);
        characterSettings.torsoSize.y = int.Parse(torsoY.text);
        characterSettings.torsoSize.z = int.Parse(torsoZ.text);
        characterSettings.leftArmSize.x = int.Parse(leftArmX.text);
        characterSettings.leftArmSize.y = int.Parse(leftArmY.text);
        characterSettings.leftArmSize.z = int.Parse(leftArmZ.text);
        characterSettings.leftHandSize.x = int.Parse(leftHandX.text);
        characterSettings.leftHandSize.y = int.Parse(leftHandY.text);
        characterSettings.leftHandSize.z = int.Parse(leftHandZ.text);
        characterSettings.leftThumbSize.x = int.Parse(leftThumbX.text);
        characterSettings.leftThumbSize.y = int.Parse(leftThumbY.text);
        characterSettings.leftThumbSize.z = int.Parse(leftThumbZ.text);
        characterSettings.leftIndexSize.x = int.Parse(leftIndexX.text);
        characterSettings.leftIndexSize.y = int.Parse(leftIndexY.text);
        characterSettings.leftIndexSize.z = int.Parse(leftIndexZ.text);
        characterSettings.leftMiddleSize.x = int.Parse(leftMiddleX.text);
        characterSettings.leftMiddleSize.y = int.Parse(leftMiddleY.text);
        characterSettings.leftMiddleSize.z = int.Parse(leftMiddleZ.text);
        characterSettings.leftRingSize.x = int.Parse(leftRingX.text);
        characterSettings.leftRingSize.y = int.Parse(leftRingY.text);
        characterSettings.leftRingSize.z = int.Parse(leftRingZ.text);
        characterSettings.leftPinkySize.x = int.Parse(leftPinkyX.text);
        characterSettings.leftPinkySize.y = int.Parse(leftPinkyY.text);
        characterSettings.leftPinkySize.z = int.Parse(leftPinkyZ.text);
        characterSettings.rightArmSize.x = int.Parse(rightArmX.text);
        characterSettings.rightArmSize.y = int.Parse(rightArmY.text);
        characterSettings.rightArmSize.z = int.Parse(rightArmZ.text);
        characterSettings.rightHandSize.x = int.Parse(rightHandX.text);
        characterSettings.rightHandSize.y = int.Parse(rightHandY.text);
        characterSettings.rightHandSize.z = int.Parse(rightHandZ.text);
        characterSettings.rightThumbSize.x = int.Parse(rightThumbX.text);
        characterSettings.rightThumbSize.y = int.Parse(rightThumbY.text);
        characterSettings.rightThumbSize.z = int.Parse(rightThumbZ.text);
        characterSettings.rightIndexSize.x = int.Parse(rightIndexX.text);
        characterSettings.rightIndexSize.y = int.Parse(rightIndexY.text);
        characterSettings.rightIndexSize.z = int.Parse(rightIndexZ.text);
        characterSettings.rightMiddleSize.x = int.Parse(rightMiddleX.text);
        characterSettings.rightMiddleSize.y = int.Parse(rightMiddleY.text);
        characterSettings.rightMiddleSize.z = int.Parse(rightMiddleZ.text);
        characterSettings.rightRingSize.x = int.Parse(rightRingX.text);
        characterSettings.rightRingSize.y = int.Parse(rightRingY.text);
        characterSettings.rightRingSize.z = int.Parse(rightRingZ.text);
        characterSettings.rightPinkySize.x = int.Parse(rightPinkyX.text);
        characterSettings.rightPinkySize.y = int.Parse(rightPinkyY.text);
        characterSettings.rightPinkySize.z = int.Parse(rightPinkyZ.text);
        characterSettings.leftLegSize.x = int.Parse(leftLegX.text);
        characterSettings.leftLegSize.y = int.Parse(leftLegY.text);
        characterSettings.leftLegSize.z = int.Parse(leftLegZ.text);
        characterSettings.leftFootSize.x = int.Parse(leftFootX.text);
        characterSettings.leftFootSize.y = int.Parse(leftFootY.text);
        characterSettings.leftFootSize.z = int.Parse(leftFootZ.text);
        characterSettings.rightLegSize.x = int.Parse(rightLegX.text);
        characterSettings.rightLegSize.y = int.Parse(rightLegY.text);
        characterSettings.rightLegSize.z = int.Parse(rightLegZ.text);
        characterSettings.rightFootSize.x = int.Parse(rightFootX.text);
        characterSettings.rightFootSize.y = int.Parse(rightFootY.text);
        characterSettings.rightFootSize.z = int.Parse(rightFootZ.text);
        ChangeBorderSizes();
    }

    public void ChangeBorderSizes()
    {
        float positionX = 0;
        float positionY = 0;
        float headPositionX = 0;
        float headPositionZ = 0;
        float leftArmOffset = 0;
        float rightArmOffset = 0;
        float leftLegOffset = 0;
        float rightLegOffset = 0;
        switch (currentView)
        {
            case GridViews.Front:
                if (characterSettings.torsoSize.x % 2 == 1) // Odd
                {
                    positionX = 0.5f;
                }
                if (characterSettings.torsoSize.y % 2 == 1) // Odd
                {
                    positionY = 0.5f;
                }
                drawBorders.transform.position = new Vector3(positionX, positionY, drawBorders.transform.position.z);

                headBorder.size = new Vector2(characterSettings.headSize.x, characterSettings.headSize.y);
                torsoBorder.size = new Vector2(characterSettings.torsoSize.x, characterSettings.torsoSize.y);
                leftArmBorder.size = new Vector2(characterSettings.leftArmSize.y, characterSettings.leftArmSize.z);
                rightArmBorder.size = new Vector2(characterSettings.rightArmSize.y, characterSettings.rightArmSize.z);
                leftLegBorder.size = new Vector2(characterSettings.leftLegSize.x, characterSettings.leftLegSize.y);
                rightLegBorder.size = new Vector2(characterSettings.rightLegSize.x, characterSettings.rightLegSize.y);

                // Set the offsets of each border to line up with the rest of the body properly
                if (characterSettings.headSize.x % 2 != 0) // Odd
                {
                    headPositionX = 0.5f;
                }
                if (characterSettings.leftArmSize.z % 2 != 0) // Odd
                {
                    leftArmOffset = 0.5f;
                }
                if (characterSettings.rightArmSize.z % 2 != 0) // Odd
                {
                    rightArmOffset = 0.5f;
                }
                if (characterSettings.leftLegSize.x % 2 != 0) // Odd
                {
                    leftLegOffset = 0.5f;
                }
                if (characterSettings.rightLegSize.x % 2 != 0) // Odd
                {
                    rightLegOffset = 0.5f;
                }
                // The z-values determine which tilemap the user is editing (closer ones have a closer z-value)
                headBorder.gameObject.transform.position = new Vector3(headPositionX, Mathf.Ceil(torsoBorder.size.y / 2.0f) + headBorder.size.y / 2.0f, headBorder.gameObject.transform.position.z);
                leftArmBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x / 2.0f, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f, leftArmBorder.gameObject.transform.position.z);
                rightArmBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x / 2.0f, Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f, rightArmBorder.gameObject.transform.position.z);
                leftLegBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftLegBorder.size.x / 2.0f, -Mathf.Floor(torsoBorder.size.y / 2.0f) - leftLegBorder.size.y / 2.0f, leftLegBorder.gameObject.transform.position.z);
                rightLegBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) + rightLegBorder.size.x / 2.0f, -Mathf.Floor(torsoBorder.size.y / 2.0f) - rightLegBorder.size.y / 2.0f, rightLegBorder.gameObject.transform.position.z);

                frontGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(1, Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                frontGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.leftArmSize.z % 2 != 0) frontGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f), Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f + leftArmOffset, transform.position.z);
                else frontGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f), Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f + leftArmOffset + 1, transform.position.z);

                if (characterSettings.rightArmSize.z % 2 != 0) frontGrid.GetComponent<DrawGrid>().rightArmTilemap.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f), Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f + rightArmOffset, transform.position.z);
                else frontGrid.GetComponent<DrawGrid>().rightArmTilemap.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f), Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f + rightArmOffset + 1, transform.position.z);

                frontGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftLegBorder.size.x / 2.0f + leftLegOffset - 1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                frontGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) + rightLegBorder.size.x / 2.0f + rightLegOffset - 1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                break;
            case GridViews.Back:
                if (characterSettings.torsoSize.x % 2 == 1) // Odd
                {
                    positionX = -0.5f;
                }
                if (characterSettings.torsoSize.y % 2 == 1) // Odd
                {
                    positionY = 0.5f;
                }
                drawBorders.transform.position = new Vector3(positionX, positionY, drawBorders.transform.position.z);

                headBorder.size = new Vector2(characterSettings.headSize.x, characterSettings.headSize.y);
                torsoBorder.size = new Vector2(characterSettings.torsoSize.x, characterSettings.torsoSize.y);
                leftArmBorder.size = new Vector2(characterSettings.leftArmSize.y, characterSettings.leftArmSize.z);
                rightArmBorder.size = new Vector2(characterSettings.rightArmSize.y, characterSettings.rightArmSize.z);
                leftLegBorder.size = new Vector2(characterSettings.leftLegSize.x, characterSettings.leftLegSize.y);
                rightLegBorder.size = new Vector2(characterSettings.rightLegSize.x, characterSettings.rightLegSize.y);

                // Set the offsets of each border to line up with the rest of the body properly
                if (characterSettings.headSize.x % 2 != 0) // Odd
                {
                    headPositionX = -0.5f;
                }
                if (characterSettings.leftArmSize.z % 2 != 0) // Odd
                {
                    leftArmOffset = 0.5f;
                }
                if (characterSettings.rightArmSize.z % 2 != 0) // Odd
                {
                    rightArmOffset = 0.5f;
                }
                if (characterSettings.leftLegSize.x % 2 != 0) // Odd
                {
                    leftLegOffset = 0.5f;
                }
                if (characterSettings.rightLegSize.x % 2 != 0) // Odd
                {
                    rightLegOffset = 0.5f;
                }
                // The z-values determine which tilemap the user is editing (closer ones have a closer z-value)
                headBorder.gameObject.transform.position = new Vector3(headPositionX, Mathf.Ceil(torsoBorder.size.y / 2.0f) + headBorder.size.y / 2.0f, headBorder.gameObject.transform.position.z);
                leftArmBorder.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftArmBorder.size.x / 2.0f, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f, leftArmBorder.gameObject.transform.position.z);
                rightArmBorder.gameObject.transform.position = new Vector3(Mathf.Floor(torsoBorder.size.x / 2.0f) + rightArmBorder.size.x / 2.0f, Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f, rightArmBorder.gameObject.transform.position.z);
                leftLegBorder.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftLegBorder.size.x / 2.0f, -Mathf.Floor(torsoBorder.size.y / 2.0f) - leftLegBorder.size.y / 2.0f, leftLegBorder.gameObject.transform.position.z);
                rightLegBorder.gameObject.transform.position = new Vector3(Mathf.Floor(torsoBorder.size.x / 2.0f) - rightLegBorder.size.x / 2.0f, -Mathf.Floor(torsoBorder.size.y / 2.0f) - rightLegBorder.size.y / 2.0f, rightLegBorder.gameObject.transform.position.z);

                backGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(-1, Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                backGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(-1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                
                if (characterSettings.leftArmSize.z % 2 != 0) backGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f), Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f + leftArmOffset, transform.position.z);
                else backGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f), Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f + leftArmOffset + 1, transform.position.z);

                if (characterSettings.rightArmSize.z % 2 != 0) backGrid.GetComponent<DrawGrid>().rightArmTilemap.gameObject.transform.position = new Vector3(Mathf.Floor(torsoBorder.size.x / 2.0f), Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f + rightArmOffset, transform.position.z);
                else backGrid.GetComponent<DrawGrid>().rightArmTilemap.gameObject.transform.position = new Vector3(Mathf.Floor(torsoBorder.size.x / 2.0f), Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f + rightArmOffset + 1, transform.position.z);

                if (characterSettings.leftLegSize.x % 2 != 0) backGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftLegBorder.size.x / 2.0f + leftLegOffset, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else backGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftLegBorder.size.x / 2.0f + leftLegOffset + 1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.rightLegSize.x % 2 != 0) backGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(Mathf.Floor(torsoBorder.size.x / 2.0f) - rightLegBorder.size.x / 2.0f + rightLegOffset, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else backGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(Mathf.Floor(torsoBorder.size.x / 2.0f) - rightLegBorder.size.x / 2.0f + rightLegOffset + 1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                break;
            case GridViews.Left:
                if (characterSettings.torsoSize.z % 2 == 1) // Odd
                {
                    positionX = -0.5f;
                }
                if (characterSettings.torsoSize.y % 2 == 1) // Odd
                {
                    positionY = 0.5f;
                }
                drawBorders.transform.position = new Vector3(positionX, positionY, drawBorders.transform.position.z);

                headBorder.size = new Vector2(characterSettings.headSize.z, characterSettings.headSize.y);
                torsoBorder.size = new Vector2(characterSettings.torsoSize.z, characterSettings.torsoSize.y);
                leftArmBorder.size = new Vector2(characterSettings.leftArmSize.x, characterSettings.leftArmSize.z);
                rightArmBorder.size = new Vector2(characterSettings.rightArmSize.x, characterSettings.rightArmSize.z);
                leftLegBorder.size = new Vector2(characterSettings.leftLegSize.z, characterSettings.leftLegSize.y);
                rightLegBorder.size = new Vector2(characterSettings.rightLegSize.z, characterSettings.rightLegSize.y);

                // Set the offsets of each border to line up with the rest of the body properly
                if (characterSettings.headSize.z % 2 != 0) // Odd
                {
                    headPositionX = -0.5f;
                }
                if (characterSettings.leftArmSize.x % 2 != 0) // Odd
                {
                    leftArmOffset = -0.5f;
                }
                if (characterSettings.rightArmSize.x % 2 != 0) // Odd
                {
                    rightArmOffset = -0.5f;
                }
                if (characterSettings.leftLegSize.z % 2 != 0) // Odd
                {
                    leftLegOffset = -0.5f;
                }
                if (characterSettings.rightLegSize.z % 2 != 0) // Odd
                {
                    rightLegOffset = -0.5f;
                }
                // The z-values determine which tilemap the user is editing (closer ones have a closer z-value)
                headBorder.gameObject.transform.position = new Vector3(headPositionX, Mathf.Ceil(torsoBorder.size.y / 2.0f) + headBorder.size.y / 2.0f, 103);
                leftArmBorder.gameObject.transform.position = new Vector3(leftArmOffset, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f, 102.9f);
                rightArmBorder.gameObject.transform.position = new Vector3(rightArmOffset, Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f, 103.1f);
                leftLegBorder.gameObject.transform.position = new Vector3(leftLegOffset, -Mathf.Floor(torsoBorder.size.y / 2.0f) - leftLegBorder.size.y / 2.0f, 102.9f);
                rightLegBorder.gameObject.transform.position = new Vector3(rightLegOffset, -Mathf.Floor(torsoBorder.size.y / 2.0f) - rightLegBorder.size.y / 2.0f, 103.1f);

                if (characterSettings.headSize.z % 2 != 0) leftGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(0, Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(1, Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.torsoSize.z % 2 != 0) leftGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(0, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.leftArmSize.z % 2 != 0) leftArmOffset = -0.5f;
                else leftArmOffset = 0;
                if (characterSettings.leftArmSize.x % 2 != 0) leftGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(0, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f + 1 + leftArmOffset, transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(1, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f + 1 + leftArmOffset, transform.position.z);

                if (characterSettings.rightArmSize.z % 2 != 0) rightArmOffset = -0.5f;
                else rightArmOffset = 0;
                leftGrid.GetComponent<DrawGrid>().rightArmTilemap.gameObject.transform.position = new Vector3(-1, Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f + 1 + rightArmOffset, transform.position.z);

                if (characterSettings.leftLegSize.z % 2 != 0) leftGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(0, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.rightLegSize.z % 2 != 0) leftGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(0, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                break;
            case GridViews.Right:
                if (characterSettings.torsoSize.z % 2 == 1) // Odd
                {
                    positionX = 0.5f;
                }
                if (characterSettings.torsoSize.y % 2 == 1) // Odd
                {
                    positionY = 0.5f;
                }
                drawBorders.transform.position = new Vector3(positionX, positionY, drawBorders.transform.position.z);

                headBorder.size = new Vector2(characterSettings.headSize.z, characterSettings.headSize.y);
                torsoBorder.size = new Vector2(characterSettings.torsoSize.z, characterSettings.torsoSize.y);
                leftArmBorder.size = new Vector2(characterSettings.leftArmSize.x, characterSettings.leftArmSize.z);
                rightArmBorder.size = new Vector2(characterSettings.rightArmSize.x, characterSettings.rightArmSize.z);
                leftLegBorder.size = new Vector2(characterSettings.leftLegSize.z, characterSettings.leftLegSize.y);
                rightLegBorder.size = new Vector2(characterSettings.rightLegSize.z, characterSettings.rightLegSize.y);

                // Set the offsets of each border to line up with the rest of the body properly
                if (characterSettings.headSize.z % 2 != 0) // Odd
                {
                    headPositionX = 0.5f;
                }
                if (characterSettings.leftArmSize.x % 2 != 0) // Odd
                {
                    leftArmOffset = 0.5f;
                }
                if (characterSettings.rightArmSize.x % 2 != 0) // Odd
                {
                    rightArmOffset = 0.5f;
                }
                if (characterSettings.leftLegSize.z % 2 != 0) // Odd
                {
                    leftLegOffset = 0.5f;
                }
                if (characterSettings.rightLegSize.z % 2 != 0) // Odd
                {
                    rightLegOffset = 0.5f;
                }
                // The z-values determine which tilemap the user is editing (closer ones have a closer z-value)
                headBorder.gameObject.transform.position = new Vector3(headPositionX, Mathf.Ceil(torsoBorder.size.y / 2.0f) + headBorder.size.y / 2.0f, 103);
                leftArmBorder.gameObject.transform.position = new Vector3(leftArmOffset, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f, 103.1f);
                rightArmBorder.gameObject.transform.position = new Vector3(rightArmOffset, Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f, 102.9f);
                leftLegBorder.gameObject.transform.position = new Vector3(leftLegOffset, -Mathf.Floor(torsoBorder.size.y / 2.0f) - leftLegBorder.size.y / 2.0f, 103.1f);
                rightLegBorder.gameObject.transform.position = new Vector3(rightLegOffset, -Mathf.Floor(torsoBorder.size.y / 2.0f) - rightLegBorder.size.y / 2.0f, 102.9f);

                if (characterSettings.headSize.z % 2 != 0) rightGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(0, Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(-1, Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.torsoSize.z % 2 != 0) rightGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(0, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(-1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.leftArmSize.z % 2 != 0) leftArmOffset = -0.5f;
                else leftArmOffset = 0;
                if (characterSettings.leftArmSize.x % 2 != 0) rightGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(0, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f + 1 + leftArmOffset, transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(-1, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f + 1 + leftArmOffset, transform.position.z);

                if (characterSettings.rightArmSize.z % 2 != 0) rightArmOffset = -0.5f;
                else rightArmOffset = 0;
                rightGrid.GetComponent<DrawGrid>().rightArmTilemap.gameObject.transform.position = new Vector3(1, Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f + 1 + rightArmOffset, transform.position.z);

                if (characterSettings.leftLegSize.z % 2 != 0) rightGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(0, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(-1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.rightLegSize.z % 2 != 0) rightGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(0, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(-1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                break;
            case GridViews.Top:
                if (characterSettings.torsoSize.x % 2 == 1) // Odd
                {
                    positionX = 0.5f;
                }
                if (characterSettings.torsoSize.z % 2 == 1) // Odd
                {
                    positionY = -0.5f;
                }
                drawBorders.transform.position = new Vector3(positionX, positionY, drawBorders.transform.position.z);

                headBorder.size = new Vector2(characterSettings.headSize.x, characterSettings.headSize.z);
                torsoBorder.size = new Vector2(characterSettings.torsoSize.x, characterSettings.torsoSize.z);
                leftArmBorder.size = new Vector2(characterSettings.leftArmSize.y, characterSettings.leftArmSize.x);
                rightArmBorder.size = new Vector2(characterSettings.rightArmSize.y, characterSettings.rightArmSize.x);
                leftLegBorder.size = new Vector2(characterSettings.leftLegSize.x, characterSettings.leftLegSize.z);
                rightLegBorder.size = new Vector2(characterSettings.rightLegSize.x, characterSettings.rightLegSize.z);

                // Set the offsets of each border to line up with the rest of the body properly
                if (characterSettings.headSize.x % 2 != 0) // Odd
                {
                    headPositionX = 0.5f;
                }
                if (characterSettings.headSize.z % 2 != 0) // Odd
                {
                    headPositionZ = -0.5f;
                }
                if (characterSettings.leftArmSize.x % 2 != 0) // Odd
                {
                    leftArmOffset = -0.5f;
                }
                if (characterSettings.rightArmSize.x % 2 != 0) // Odd
                {
                    rightArmOffset = -0.5f;
                }
                if (characterSettings.leftLegSize.z % 2 != 0) // Odd
                {
                    leftLegOffset = -0.5f;
                }
                if (characterSettings.rightLegSize.z % 2 != 0) // Odd
                {
                    rightLegOffset = -0.5f;
                }
                // The z-values determine which tilemap the user is editing (closer ones have a closer z-value)
                headBorder.gameObject.transform.position = new Vector3(headPositionX, headPositionZ, 103.1f);
                leftArmBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x / 2.0f, leftArmOffset, 103f);
                rightArmBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x / 2.0f, rightArmOffset, 103f);
                leftLegBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftLegBorder.size.x / 2.0f, leftLegOffset, 102.9f);
                rightLegBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) + rightLegBorder.size.x / 2.0f, rightLegOffset, 102.9f);

                if (characterSettings.headSize.z % 2 != 0) topGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(1, 0, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(1, 1, transform.position.z);

                if (characterSettings.torsoSize.z % 2 != 0) topGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(1, 0, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(1, 1, transform.position.z);

                topGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f), 0, transform.position.z);

                if (characterSettings.rightArmSize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().rightArmTilemap.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f), -1, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().rightArmTilemap.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f), 0, transform.position.z);

                if (characterSettings.leftLegSize.z % 2 != 0) leftLegOffset = 0;
                else leftLegOffset = 1;
                if (characterSettings.leftLegSize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftLegBorder.size.x / 2.0f - 0.5f, leftLegOffset, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftLegBorder.size.x / 2.0f - 1, leftLegOffset, transform.position.z);

                if (characterSettings.rightLegSize.z % 2 != 0) rightLegOffset = 0;
                else rightLegOffset = 1;
                if (characterSettings.rightLegSize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) + rightLegBorder.size.x / 2.0f - 0.5f, rightLegOffset, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) + rightLegBorder.size.x / 2.0f - 1, rightLegOffset, transform.position.z);
                break;
            case GridViews.Bottom:
                if (characterSettings.torsoSize.x % 2 == 1) // Odd
                {
                    positionX = 0.5f;
                }
                if (characterSettings.torsoSize.z % 2 == 1) // Odd
                {
                    positionY = 0.5f;
                }
                drawBorders.transform.position = new Vector3(positionX, positionY, drawBorders.transform.position.z);

                headBorder.size = new Vector2(characterSettings.headSize.x, characterSettings.headSize.z);
                torsoBorder.size = new Vector2(characterSettings.torsoSize.x, characterSettings.torsoSize.z);
                leftArmBorder.size = new Vector2(characterSettings.leftArmSize.y, characterSettings.leftArmSize.x);
                rightArmBorder.size = new Vector2(characterSettings.rightArmSize.y, characterSettings.rightArmSize.x);
                leftLegBorder.size = new Vector2(characterSettings.leftLegSize.x, characterSettings.leftLegSize.z);
                rightLegBorder.size = new Vector2(characterSettings.rightLegSize.x, characterSettings.rightLegSize.z);

                // Set the offsets of each border to line up with the rest of the body properly
                if (characterSettings.headSize.x % 2 != 0) // Odd
                {
                    headPositionX = 0.5f;
                }
                if (characterSettings.headSize.z % 2 != 0) // Odd
                {
                    headPositionZ = 0.5f;
                }
                if (characterSettings.leftArmSize.x % 2 != 0) // Odd
                {
                    leftArmOffset = 0.5f;
                }
                if (characterSettings.rightArmSize.x % 2 != 0) // Odd
                {
                    rightArmOffset = 0.5f;
                }
                if (characterSettings.leftLegSize.z % 2 != 0) // Odd
                {
                    leftLegOffset = 0.5f;
                }
                if (characterSettings.rightLegSize.z % 2 != 0) // Odd
                {
                    rightLegOffset = 0.5f;
                }
                // The z-values determine which tilemap the user is editing (closer ones have a closer z-value)
                headBorder.gameObject.transform.position = new Vector3(headPositionX, headPositionZ, 103.1f);
                leftArmBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x / 2.0f, leftArmOffset, 103);
                rightArmBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x / 2.0f, rightArmOffset, 103);
                leftLegBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftLegBorder.size.x / 2.0f, leftLegOffset, 102.9f);
                rightLegBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) + rightLegBorder.size.x / 2.0f, rightLegOffset, 102.9f);

                if (characterSettings.headSize.z % 2 != 0) bottomGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(1, 0, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(1, -1, transform.position.z);

                if (characterSettings.torsoSize.z % 2 != 0) bottomGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(1, 0, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(1, -1, transform.position.z);

                if (characterSettings.leftArmSize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f), 0, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f), -1, transform.position.z);

                bottomGrid.GetComponent<DrawGrid>().rightArmTilemap.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f), 1, transform.position.z);

                if (characterSettings.leftLegSize.z % 2 != 0) leftLegOffset = 0;
                else leftLegOffset = -1;
                if (characterSettings.leftLegSize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftLegBorder.size.x / 2.0f - 0.5f, leftLegOffset, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftLegBorder.size.x / 2.0f - 1, leftLegOffset, transform.position.z);

                if (characterSettings.rightLegSize.z % 2 != 0) rightLegOffset = 0;
                else rightLegOffset = -1;
                if (characterSettings.rightLegSize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) + rightLegBorder.size.x / 2.0f - 0.5f, rightLegOffset, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) + rightLegBorder.size.x / 2.0f - 1, rightLegOffset, transform.position.z);
                break;
        }
        headBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        torsoBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        leftArmBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        leftHandBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        leftThumbBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        leftIndexBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        leftMiddleBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        leftRingBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        leftPinkyBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        rightArmBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        rightHandBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        rightThumbBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        rightIndexBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        rightMiddleBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        rightRingBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        rightPinkyBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        leftLegBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        leftFootBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        rightLegBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        rightFootBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
    }
}
