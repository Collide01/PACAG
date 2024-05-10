using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;
using System.Linq;

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
    public Button fillButton;
    public Button pickerButton;
    public Button selectButton;

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

    [Header("Joint Inputs")]
    public TMP_InputField spine1;
    public TMP_InputField spine2;
    public TMP_InputField spine3;
    public TMP_InputField leftElbow;
    public TMP_InputField rightElbow;
    public TMP_InputField leftKnee;
    public TMP_InputField rightKnee;
    public TMP_InputField leftToe;
    public TMP_InputField rightToe;

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
    public Camera mainCamera;
    public TMP_Dropdown gridView;
    public GameObject colorPicker;
    public Scrollbar partScrollbar;
    public Scrollbar jointScrollbar;
    public GameObject warningSign;
    public GameObject warningText;
    [HideInInspector] public Color currentColor;

    [HideInInspector] public DrawModes currentMode;
    [HideInInspector] public GridViews currentView;
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
        gridView.value = 0;
        ChangeView();

        drawButton.interactable = false;
        eraseButton.interactable = true;
        fillButton.interactable = true;

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

        spine1.text = characterSettings.torsoJoint1.ToString();
        spine2.text = characterSettings.torsoJoint2.ToString();
        spine3.text = characterSettings.torsoJoint3.ToString();
        leftElbow.text = characterSettings.leftElbow.ToString();
        rightElbow.text = characterSettings.rightElbow.ToString();
        leftKnee.text = characterSettings.leftKnee.ToString();
        rightKnee.text = characterSettings.rightKnee.ToString();
        leftToe.text = characterSettings.leftToe.ToString();
        rightToe.text = characterSettings.rightToe.ToString();
        ChangeBorderSizes();

        mainCamera.orthographicSize = 16;
        mainCamera.transform.position = Vector3.zero;
        currentColor = Color.red;
        colorPicker.GetComponent<FlexibleColorPicker>().color = currentColor;
        mouseInDrawField = true;
        warningText.SetActive(false);

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
                fillButton.interactable = true;
                pickerButton.interactable = true;
                selectButton.interactable = true;
                currentMode = DrawModes.Draw;
                break;
            case 1:
                drawButton.interactable = true;
                eraseButton.interactable = false;
                fillButton.interactable = true;
                pickerButton.interactable = true;
                selectButton.interactable = true;
                currentMode = DrawModes.Erase;
                break;
            case 2:
                drawButton.interactable = true;
                eraseButton.interactable = true;
                fillButton.interactable = false;
                pickerButton.interactable = true;
                selectButton.interactable = true;
                currentMode = DrawModes.Fill;
                break;
            case 3:
                drawButton.interactable = true;
                eraseButton.interactable = true;
                fillButton.interactable = true;
                pickerButton.interactable = false;
                selectButton.interactable = true;
                currentMode = DrawModes.Picker;
                break;
            case 4:
                drawButton.interactable = true;
                eraseButton.interactable = true;
                fillButton.interactable = true;
                pickerButton.interactable = true;
                selectButton.interactable = false;
                currentMode = DrawModes.Select;
                break;
        }
    }

    public void ChangeColor()
    {
        currentColor = colorPicker.GetComponent<FlexibleColorPicker>().color;
    }

    public void ChangeView()
    {
        mainCamera.orthographicSize = 16;
        mainCamera.transform.position = Vector3.zero;

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

        characterSettings.torsoJoint1 = int.Parse(spine1.text);
        characterSettings.torsoJoint2 = int.Parse(spine2.text);
        characterSettings.torsoJoint3 = int.Parse(spine3.text);
        characterSettings.leftElbow = int.Parse(leftElbow.text);
        characterSettings.rightElbow = int.Parse(rightElbow.text);
        characterSettings.leftKnee = int.Parse(leftKnee.text);
        characterSettings.rightKnee = int.Parse(rightKnee.text);
        characterSettings.leftToe = int.Parse(leftToe.text);
        characterSettings.rightToe = int.Parse(rightToe.text);
        ChangeBorderSizes();
    }

    public void ChangeBorderSizes()
    {
        float positionX = 0;
        float positionY = 0;
        float headPositionX = 0;
        float headPositionZ = 0;
        float leftArmOffset = 0;
        float leftHandOffset = 0;
        float leftHandOffsetY = 0;
        float leftThumbOffset = 0;
        float leftThumbOffsetY = 0;
        float leftIndexOffset = 0;
        float leftIndexOffsetY = 0;
        float leftMiddleOffset = 0;
        float leftMiddleOffsetY = 0;
        float leftRingOffset = 0;
        float leftRingOffsetY = 0;
        float leftPinkyOffset = 0;
        float leftPinkyOffsetY = 0;
        float rightArmOffset = 0;
        float rightHandOffset = 0;
        float rightHandOffsetY = 0;
        float rightThumbOffset = 0;
        float rightThumbOffsetY = 0;
        float rightIndexOffset = 0;
        float rightIndexOffsetY = 0;
        float rightMiddleOffset = 0;
        float rightMiddleOffsetY = 0;
        float rightRingOffset = 0;
        float rightRingOffsetY = 0;
        float rightPinkyOffset = 0;
        float rightPinkyOffsetY = 0;
        float leftLegOffset = 0;
        float leftFootOffset = 0;
        float leftFootOffsetY = 0;
        float rightLegOffset = 0;
        float rightFootOffset = 0;
        float rightFootOffsetY = 0;
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
                leftHandBorder.size = new Vector2(characterSettings.leftHandSize.y, characterSettings.leftHandSize.z);
                leftThumbBorder.size = new Vector2(characterSettings.leftThumbSize.y, characterSettings.leftThumbSize.z);
                leftIndexBorder.size = new Vector2(characterSettings.leftIndexSize.y, characterSettings.leftIndexSize.z);
                leftMiddleBorder.size = new Vector2(characterSettings.leftMiddleSize.y, characterSettings.leftMiddleSize.z);
                leftRingBorder.size = new Vector2(characterSettings.leftRingSize.y, characterSettings.leftRingSize.z);
                leftPinkyBorder.size = new Vector2(characterSettings.leftPinkySize.y, characterSettings.leftPinkySize.z);
                rightArmBorder.size = new Vector2(characterSettings.rightArmSize.y, characterSettings.rightArmSize.z);
                rightHandBorder.size = new Vector2(characterSettings.rightHandSize.y, characterSettings.rightHandSize.z);
                rightThumbBorder.size = new Vector2(characterSettings.rightThumbSize.y, characterSettings.rightThumbSize.z);
                rightIndexBorder.size = new Vector2(characterSettings.rightIndexSize.y, characterSettings.rightIndexSize.z);
                rightMiddleBorder.size = new Vector2(characterSettings.rightMiddleSize.y, characterSettings.rightMiddleSize.z);
                rightRingBorder.size = new Vector2(characterSettings.rightRingSize.y, characterSettings.rightRingSize.z);
                rightPinkyBorder.size = new Vector2(characterSettings.rightPinkySize.y, characterSettings.rightPinkySize.z);
                leftLegBorder.size = new Vector2(characterSettings.leftLegSize.x, characterSettings.leftLegSize.y);
                leftFootBorder.size = new Vector2(characterSettings.leftFootSize.x, characterSettings.leftFootSize.z);
                rightLegBorder.size = new Vector2(characterSettings.rightLegSize.x, characterSettings.rightLegSize.y);
                rightFootBorder.size = new Vector2(characterSettings.rightFootSize.x, characterSettings.rightFootSize.z);

                // Set the offsets of each border to line up with the rest of the body properly
                if (characterSettings.headSize.x % 2 != 0) // Odd
                {
                    headPositionX = 0.5f;
                }
                if (characterSettings.leftArmSize.z % 2 != 0) // Odd
                {
                    leftArmOffset = 0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftArmSize.z % 2)
                {
                    leftHandOffset = 0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftThumbSize.z % 2)
                {
                    leftThumbOffset = 0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftIndexSize.z % 2)
                {
                    leftIndexOffset = 0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftMiddleSize.z % 2)
                {
                    leftMiddleOffset = 0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftRingSize.z % 2)
                {
                    leftRingOffset = 0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftPinkySize.z % 2)
                {
                    leftPinkyOffset = 0.5f;
                }
                if (characterSettings.rightArmSize.z % 2 != 0) // Odd
                {
                    rightArmOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightArmSize.z % 2)
                {
                    rightHandOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightThumbSize.z % 2)
                {
                    rightThumbOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightIndexSize.z % 2)
                {
                    rightIndexOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightMiddleSize.z % 2)
                {
                    rightMiddleOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightRingSize.z % 2)
                {
                    rightRingOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightPinkySize.z % 2)
                {
                    rightPinkyOffset = 0.5f;
                }
                if (characterSettings.leftLegSize.x % 2 != 0) // Odd
                {
                    leftLegOffset = 0.5f;
                }
                if (characterSettings.leftLegSize.x % 2 != characterSettings.leftFootSize.x % 2)
                {
                    leftFootOffset = 0.5f;
                }
                if (characterSettings.rightLegSize.x % 2 != 0) // Odd
                {
                    rightLegOffset = 0.5f;
                }
                if (characterSettings.rightLegSize.x % 2 != characterSettings.rightFootSize.x % 2)
                {
                    rightFootOffset = 0.5f;
                }
                // The z-values determine which tilemap the user is editing (closer ones have a closer z-value)
                headBorder.gameObject.transform.position = new Vector3(headPositionX, Mathf.Ceil(torsoBorder.size.y / 2.0f) + headBorder.size.y / 2.0f, 103);
                leftArmBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x / 2.0f, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f, 103);
                leftHandBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x + leftHandBorder.size.x / 2.0f, leftArmBorder.transform.position.y + leftHandOffset, 103);
                leftThumbBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x + Mathf.Floor(leftHandBorder.size.x / 2.0f) + leftThumbBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftThumbOffset, 102.8f);
                leftIndexBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x + leftHandBorder.size.x + leftIndexBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftIndexOffset, 102.9f);
                leftMiddleBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x + leftHandBorder.size.x + leftMiddleBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftMiddleOffset, 103);
                leftRingBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x + leftHandBorder.size.x + leftRingBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftRingOffset, 103.1f);
                leftPinkyBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x + leftHandBorder.size.x + leftPinkyBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftPinkyOffset, 103.2f);
                rightArmBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x / 2.0f, Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f, 103);
                rightHandBorder.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x - rightHandBorder.size.x / 2.0f, rightArmBorder.transform.position.y + rightHandOffset, 103);
                rightThumbBorder.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x - Mathf.Ceil(rightHandBorder.size.x / 2.0f) - rightThumbBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightThumbOffset, 102.8f);
                rightIndexBorder.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x - rightHandBorder.size.x - rightIndexBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightIndexOffset, 102.9f);
                rightMiddleBorder.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x - rightHandBorder.size.x - rightMiddleBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightMiddleOffset, 103);
                rightRingBorder.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x - rightHandBorder.size.x - rightRingBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightRingOffset, 103.1f);
                rightPinkyBorder.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x - rightHandBorder.size.x - rightPinkyBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightPinkyOffset, 103.2f);
                leftLegBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftLegBorder.size.x / 2.0f, -Mathf.Floor(torsoBorder.size.y / 2.0f) - leftLegBorder.size.y / 2.0f, 103);
                leftFootBorder.gameObject.transform.position = new Vector3(leftLegBorder.transform.position.x + leftFootOffset, -Mathf.Floor(torsoBorder.size.y / 2.0f) - leftLegBorder.size.y - leftFootBorder.size.y / 2.0f, 103);
                rightLegBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) + rightLegBorder.size.x / 2.0f, -Mathf.Floor(torsoBorder.size.y / 2.0f) - rightLegBorder.size.y / 2.0f, 103);
                rightFootBorder.gameObject.transform.position = new Vector3(rightLegBorder.transform.position.x - rightFootOffset, -Mathf.Floor(torsoBorder.size.y / 2.0f) - rightLegBorder.size.y - rightFootBorder.size.y / 2.0f, 103);

                frontGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(1, Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                frontGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.leftArmSize.z % 2 != 0) frontGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f), Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f + leftArmOffset, transform.position.z);
                else frontGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f), Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f + leftArmOffset + 1, transform.position.z);

                if (characterSettings.leftHandSize.z % 2 != 0) frontGrid.GetComponent<DrawGrid>().leftHandTilemap.gameObject.transform.position = new Vector3(leftHandBorder.transform.position.x - leftHandBorder.size.x / 2.0f, leftHandBorder.transform.position.y + 0.5f, transform.position.z);
                else frontGrid.GetComponent<DrawGrid>().leftHandTilemap.gameObject.transform.position = new Vector3(leftHandBorder.transform.position.x - leftHandBorder.size.x / 2.0f, leftHandBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.leftThumbSize.z % 2 != 0) frontGrid.GetComponent<DrawGrid>().leftThumbTilemap.gameObject.transform.position = new Vector3(leftThumbBorder.transform.position.x - leftThumbBorder.size.x / 2.0f, leftThumbBorder.transform.position.y + 0.5f, transform.position.z);
                else frontGrid.GetComponent<DrawGrid>().leftThumbTilemap.gameObject.transform.position = new Vector3(leftThumbBorder.transform.position.x - leftThumbBorder.size.x / 2.0f, leftThumbBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.leftIndexSize.z % 2 != 0) frontGrid.GetComponent<DrawGrid>().leftIndexTilemap.gameObject.transform.position = new Vector3(leftIndexBorder.transform.position.x - leftIndexBorder.size.x / 2.0f, leftIndexBorder.transform.position.y + 0.5f, transform.position.z);
                else frontGrid.GetComponent<DrawGrid>().leftIndexTilemap.gameObject.transform.position = new Vector3(leftIndexBorder.transform.position.x - leftIndexBorder.size.x / 2.0f, leftIndexBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.leftMiddleSize.z % 2 != 0) frontGrid.GetComponent<DrawGrid>().leftMiddleTilemap.gameObject.transform.position = new Vector3(leftMiddleBorder.transform.position.x - leftMiddleBorder.size.x / 2.0f, leftMiddleBorder.transform.position.y + 0.5f, transform.position.z);
                else frontGrid.GetComponent<DrawGrid>().leftMiddleTilemap.gameObject.transform.position = new Vector3(leftMiddleBorder.transform.position.x - leftMiddleBorder.size.x / 2.0f, leftMiddleBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.leftRingSize.z % 2 != 0) frontGrid.GetComponent<DrawGrid>().leftRingTilemap.gameObject.transform.position = new Vector3(leftRingBorder.transform.position.x - leftRingBorder.size.x / 2.0f, leftRingBorder.transform.position.y + 0.5f, transform.position.z);
                else frontGrid.GetComponent<DrawGrid>().leftRingTilemap.gameObject.transform.position = new Vector3(leftRingBorder.transform.position.x - leftRingBorder.size.x / 2.0f, leftRingBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.leftPinkySize.z % 2 != 0) frontGrid.GetComponent<DrawGrid>().leftPinkyTilemap.gameObject.transform.position = new Vector3(leftPinkyBorder.transform.position.x - leftPinkyBorder.size.x / 2.0f, leftPinkyBorder.transform.position.y + 0.5f, transform.position.z);
                else frontGrid.GetComponent<DrawGrid>().leftPinkyTilemap.gameObject.transform.position = new Vector3(leftPinkyBorder.transform.position.x - leftPinkyBorder.size.x / 2.0f, leftPinkyBorder.transform.position.y + 1, transform.position.z);

                if (characterSettings.rightArmSize.z % 2 != 0) frontGrid.GetComponent<DrawGrid>().rightArmTilemap.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f), Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f + rightArmOffset, transform.position.z);
                else frontGrid.GetComponent<DrawGrid>().rightArmTilemap.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f), Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f + rightArmOffset + 1, transform.position.z);
                
                if (characterSettings.rightHandSize.z % 2 != 0) frontGrid.GetComponent<DrawGrid>().rightHandTilemap.gameObject.transform.position = new Vector3(rightHandBorder.transform.position.x + rightHandBorder.size.x / 2.0f, rightHandBorder.transform.position.y + 0.5f, transform.position.z);
                else frontGrid.GetComponent<DrawGrid>().rightHandTilemap.gameObject.transform.position = new Vector3(rightHandBorder.transform.position.x + rightHandBorder.size.x / 2.0f, rightHandBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.rightThumbSize.z % 2 != 0) frontGrid.GetComponent<DrawGrid>().rightThumbTilemap.gameObject.transform.position = new Vector3(rightThumbBorder.transform.position.x + rightThumbBorder.size.x / 2.0f, rightThumbBorder.transform.position.y + 0.5f, transform.position.z);
                else frontGrid.GetComponent<DrawGrid>().rightThumbTilemap.gameObject.transform.position = new Vector3(rightThumbBorder.transform.position.x + rightThumbBorder.size.x / 2.0f, rightThumbBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.rightIndexSize.z % 2 != 0) frontGrid.GetComponent<DrawGrid>().rightIndexTilemap.gameObject.transform.position = new Vector3(rightIndexBorder.transform.position.x + rightIndexBorder.size.x / 2.0f, rightIndexBorder.transform.position.y + 0.5f, transform.position.z);
                else frontGrid.GetComponent<DrawGrid>().rightIndexTilemap.gameObject.transform.position = new Vector3(rightIndexBorder.transform.position.x + rightIndexBorder.size.x / 2.0f, rightIndexBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.rightMiddleSize.z % 2 != 0) frontGrid.GetComponent<DrawGrid>().rightMiddleTilemap.gameObject.transform.position = new Vector3(rightMiddleBorder.transform.position.x + rightMiddleBorder.size.x / 2.0f, rightMiddleBorder.transform.position.y + 0.5f, transform.position.z);
                else frontGrid.GetComponent<DrawGrid>().rightMiddleTilemap.gameObject.transform.position = new Vector3(rightMiddleBorder.transform.position.x + rightMiddleBorder.size.x / 2.0f, rightMiddleBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.rightRingSize.z % 2 != 0) frontGrid.GetComponent<DrawGrid>().rightRingTilemap.gameObject.transform.position = new Vector3(rightRingBorder.transform.position.x + rightRingBorder.size.x / 2.0f, rightRingBorder.transform.position.y + 0.5f, transform.position.z);
                else frontGrid.GetComponent<DrawGrid>().rightRingTilemap.gameObject.transform.position = new Vector3(rightRingBorder.transform.position.x + rightRingBorder.size.x / 2.0f, rightRingBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.rightPinkySize.z % 2 != 0) frontGrid.GetComponent<DrawGrid>().rightPinkyTilemap.gameObject.transform.position = new Vector3(rightPinkyBorder.transform.position.x + rightPinkyBorder.size.x / 2.0f, rightPinkyBorder.transform.position.y + 0.5f, transform.position.z);
                else frontGrid.GetComponent<DrawGrid>().rightPinkyTilemap.gameObject.transform.position = new Vector3(rightPinkyBorder.transform.position.x + rightPinkyBorder.size.x / 2.0f, rightPinkyBorder.transform.position.y + 1, transform.position.z);

                frontGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftLegBorder.size.x / 2.0f + leftLegOffset - 1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                
                if (characterSettings.leftFootSize.z % 2 != 0) frontGrid.GetComponent<DrawGrid>().leftFootTilemap.gameObject.transform.position = new Vector3(leftFootBorder.transform.position.x + leftFootOffset - 1, leftFootBorder.transform.position.y - 0.5f, transform.position.z);
                else frontGrid.GetComponent<DrawGrid>().leftFootTilemap.gameObject.transform.position = new Vector3(leftFootBorder.transform.position.x + leftFootOffset - 1, leftFootBorder.transform.position.y - 1, transform.position.z);

                frontGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) + rightLegBorder.size.x / 2.0f + rightLegOffset - 1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.rightFootSize.z % 2 != 0) frontGrid.GetComponent<DrawGrid>().rightFootTilemap.gameObject.transform.position = new Vector3(rightFootBorder.transform.position.x + rightFootOffset - 1, rightFootBorder.transform.position.y - 0.5f, transform.position.z);
                else frontGrid.GetComponent<DrawGrid>().rightFootTilemap.gameObject.transform.position = new Vector3(rightFootBorder.transform.position.x + rightFootOffset - 1, rightFootBorder.transform.position.y - 1, transform.position.z);

                //frontGrid.GetComponent<DrawGrid>().CleanAllTilemaps();
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
                leftHandBorder.size = new Vector2(characterSettings.leftHandSize.y, characterSettings.leftHandSize.z);
                leftThumbBorder.size = new Vector2(characterSettings.leftThumbSize.y, characterSettings.leftThumbSize.z);
                leftIndexBorder.size = new Vector2(characterSettings.leftIndexSize.y, characterSettings.leftIndexSize.z);
                leftMiddleBorder.size = new Vector2(characterSettings.leftMiddleSize.y, characterSettings.leftMiddleSize.z);
                leftRingBorder.size = new Vector2(characterSettings.leftRingSize.y, characterSettings.leftRingSize.z);
                leftPinkyBorder.size = new Vector2(characterSettings.leftPinkySize.y, characterSettings.leftPinkySize.z);
                rightArmBorder.size = new Vector2(characterSettings.rightArmSize.y, characterSettings.rightArmSize.z);
                rightHandBorder.size = new Vector2(characterSettings.rightHandSize.y, characterSettings.rightHandSize.z);
                rightThumbBorder.size = new Vector2(characterSettings.rightThumbSize.y, characterSettings.rightThumbSize.z);
                rightIndexBorder.size = new Vector2(characterSettings.rightIndexSize.y, characterSettings.rightIndexSize.z);
                rightMiddleBorder.size = new Vector2(characterSettings.rightMiddleSize.y, characterSettings.rightMiddleSize.z);
                rightRingBorder.size = new Vector2(characterSettings.rightRingSize.y, characterSettings.rightRingSize.z);
                rightPinkyBorder.size = new Vector2(characterSettings.rightPinkySize.y, characterSettings.rightPinkySize.z);
                leftLegBorder.size = new Vector2(characterSettings.leftLegSize.x, characterSettings.leftLegSize.y);
                leftFootBorder.size = new Vector2(characterSettings.leftFootSize.x, characterSettings.leftFootSize.z);
                rightLegBorder.size = new Vector2(characterSettings.rightLegSize.x, characterSettings.rightLegSize.y);
                rightFootBorder.size = new Vector2(characterSettings.rightFootSize.x, characterSettings.rightFootSize.z);

                // Set the offsets of each border to line up with the rest of the body properly
                if (characterSettings.headSize.x % 2 != 0) // Odd
                {
                    headPositionX = -0.5f;
                }
                if (characterSettings.leftArmSize.z % 2 != 0) // Odd
                {
                    leftArmOffset = 0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftArmSize.z % 2)
                {
                    leftHandOffset = 0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftThumbSize.z % 2)
                {
                    leftThumbOffset = 0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftIndexSize.z % 2)
                {
                    leftIndexOffset = 0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftMiddleSize.z % 2)
                {
                    leftMiddleOffset = 0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftRingSize.z % 2)
                {
                    leftRingOffset = 0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftPinkySize.z % 2)
                {
                    leftPinkyOffset = 0.5f;
                }
                if (characterSettings.rightArmSize.z % 2 != 0) // Odd
                {
                    rightArmOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightArmSize.z % 2)
                {
                    rightHandOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightThumbSize.z % 2)
                {
                    rightThumbOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightIndexSize.z % 2)
                {
                    rightIndexOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightMiddleSize.z % 2)
                {
                    rightMiddleOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightRingSize.z % 2)
                {
                    rightRingOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightPinkySize.z % 2)
                {
                    rightPinkyOffset = 0.5f;
                }
                if (characterSettings.leftLegSize.x % 2 != 0) // Odd
                {
                    leftLegOffset = 0.5f;
                }
                if (characterSettings.leftLegSize.x % 2 != characterSettings.leftFootSize.x % 2)
                {
                    leftFootOffset = 0.5f;
                }
                if (characterSettings.rightLegSize.x % 2 != 0) // Odd
                {
                    rightLegOffset = 0.5f;
                }
                if ((characterSettings.rightLegSize.x % 2 != 0 && characterSettings.rightFootSize.x % 2 == 0) || (characterSettings.rightLegSize.x % 2 == 0 && characterSettings.rightFootSize.x % 2 != 0))
                {
                    rightFootOffset = 0.5f;
                }
                // The z-values determine which tilemap the user is editing (closer ones have a closer z-value)
                headBorder.gameObject.transform.position = new Vector3(headPositionX, Mathf.Ceil(torsoBorder.size.y / 2.0f) + headBorder.size.y / 2.0f, 103);
                leftArmBorder.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftArmBorder.size.x / 2.0f, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f, 103);
                leftHandBorder.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftArmBorder.size.x - leftHandBorder.size.x / 2.0f, leftArmBorder.transform.position.y + leftHandOffset, 103);
                leftThumbBorder.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftArmBorder.size.x - Mathf.Ceil(leftHandBorder.size.x / 2.0f) - leftThumbBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftThumbOffset, 103.2f);
                leftIndexBorder.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftArmBorder.size.x - leftHandBorder.size.x - leftIndexBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftIndexOffset, 103.1f);
                leftMiddleBorder.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftArmBorder.size.x - leftHandBorder.size.x - leftMiddleBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftMiddleOffset, 103);
                leftRingBorder.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftArmBorder.size.x - leftHandBorder.size.x - leftRingBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftRingOffset, 102.9f);
                leftPinkyBorder.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftArmBorder.size.x - leftHandBorder.size.x - leftPinkyBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftPinkyOffset, 102.8f);
                rightArmBorder.gameObject.transform.position = new Vector3(Mathf.Floor(torsoBorder.size.x / 2.0f) + rightArmBorder.size.x / 2.0f, Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f, 103);
                rightHandBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + rightArmBorder.size.x + rightHandBorder.size.x / 2.0f, rightArmBorder.transform.position.y + rightHandOffset, 103);
                rightThumbBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + rightArmBorder.size.x + Mathf.Floor(rightHandBorder.size.x / 2.0f) + rightThumbBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightThumbOffset, 103.2f);
                rightIndexBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + rightArmBorder.size.x + rightHandBorder.size.x + rightIndexBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightIndexOffset, 103.1f);
                rightMiddleBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + rightArmBorder.size.x + rightHandBorder.size.x + rightMiddleBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightMiddleOffset, 103);
                rightRingBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + rightArmBorder.size.x + rightHandBorder.size.x + rightRingBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightRingOffset, 102.9f);
                rightPinkyBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + rightArmBorder.size.x + rightHandBorder.size.x + rightPinkyBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightPinkyOffset, 102.8f);
                leftLegBorder.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftLegBorder.size.x / 2.0f, -Mathf.Floor(torsoBorder.size.y / 2.0f) - leftLegBorder.size.y / 2.0f, 103);
                leftFootBorder.gameObject.transform.position = new Vector3(leftLegBorder.transform.position.x - leftFootOffset, -Mathf.Floor(torsoBorder.size.y / 2.0f) - leftLegBorder.size.y - leftFootBorder.size.y / 2.0f, 103);
                rightLegBorder.gameObject.transform.position = new Vector3(Mathf.Floor(torsoBorder.size.x / 2.0f) - rightLegBorder.size.x / 2.0f, -Mathf.Floor(torsoBorder.size.y / 2.0f) - rightLegBorder.size.y / 2.0f, 103);
                rightFootBorder.gameObject.transform.position = new Vector3(rightLegBorder.transform.position.x + rightFootOffset, -Mathf.Floor(torsoBorder.size.y / 2.0f) - rightLegBorder.size.y - rightFootBorder.size.y / 2.0f, 103);

                backGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(-1, Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                backGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(-1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                
                if (characterSettings.leftArmSize.z % 2 != 0) backGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f), Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f + leftArmOffset, transform.position.z);
                else backGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f), Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f + leftArmOffset + 1, transform.position.z);

                if (characterSettings.leftHandSize.z % 2 != 0) backGrid.GetComponent<DrawGrid>().leftHandTilemap.gameObject.transform.position = new Vector3(leftHandBorder.transform.position.x + leftHandBorder.size.x / 2.0f, leftHandBorder.transform.position.y + 0.5f, transform.position.z);
                else backGrid.GetComponent<DrawGrid>().leftHandTilemap.gameObject.transform.position = new Vector3(leftHandBorder.transform.position.x + leftHandBorder.size.x / 2.0f, leftHandBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.leftThumbSize.z % 2 != 0) backGrid.GetComponent<DrawGrid>().leftThumbTilemap.gameObject.transform.position = new Vector3(leftThumbBorder.transform.position.x + leftThumbBorder.size.x / 2.0f, leftThumbBorder.transform.position.y + 0.5f, transform.position.z);
                else backGrid.GetComponent<DrawGrid>().leftThumbTilemap.gameObject.transform.position = new Vector3(leftThumbBorder.transform.position.x + leftThumbBorder.size.x / 2.0f, leftThumbBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.leftIndexSize.z % 2 != 0) backGrid.GetComponent<DrawGrid>().leftIndexTilemap.gameObject.transform.position = new Vector3(leftIndexBorder.transform.position.x + leftIndexBorder.size.x / 2.0f, leftIndexBorder.transform.position.y + 0.5f, transform.position.z);
                else backGrid.GetComponent<DrawGrid>().leftIndexTilemap.gameObject.transform.position = new Vector3(leftIndexBorder.transform.position.x + leftIndexBorder.size.x / 2.0f, leftIndexBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.leftMiddleSize.z % 2 != 0) backGrid.GetComponent<DrawGrid>().leftMiddleTilemap.gameObject.transform.position = new Vector3(leftMiddleBorder.transform.position.x + leftMiddleBorder.size.x / 2.0f, leftMiddleBorder.transform.position.y + 0.5f, transform.position.z);
                else backGrid.GetComponent<DrawGrid>().leftMiddleTilemap.gameObject.transform.position = new Vector3(leftMiddleBorder.transform.position.x + leftMiddleBorder.size.x / 2.0f, leftMiddleBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.leftRingSize.z % 2 != 0) backGrid.GetComponent<DrawGrid>().leftRingTilemap.gameObject.transform.position = new Vector3(leftRingBorder.transform.position.x + leftRingBorder.size.x / 2.0f, leftRingBorder.transform.position.y + 0.5f, transform.position.z);
                else backGrid.GetComponent<DrawGrid>().leftRingTilemap.gameObject.transform.position = new Vector3(leftRingBorder.transform.position.x + leftRingBorder.size.x / 2.0f, leftRingBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.leftPinkySize.z % 2 != 0) backGrid.GetComponent<DrawGrid>().leftPinkyTilemap.gameObject.transform.position = new Vector3(leftPinkyBorder.transform.position.x + leftPinkyBorder.size.x / 2.0f, leftPinkyBorder.transform.position.y + 0.5f, transform.position.z);
                else backGrid.GetComponent<DrawGrid>().leftPinkyTilemap.gameObject.transform.position = new Vector3(leftPinkyBorder.transform.position.x + leftPinkyBorder.size.x / 2.0f, leftPinkyBorder.transform.position.y + 1, transform.position.z);

                if (characterSettings.rightArmSize.z % 2 != 0) backGrid.GetComponent<DrawGrid>().rightArmTilemap.gameObject.transform.position = new Vector3(Mathf.Floor(torsoBorder.size.x / 2.0f), Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f + rightArmOffset, transform.position.z);
                else backGrid.GetComponent<DrawGrid>().rightArmTilemap.gameObject.transform.position = new Vector3(Mathf.Floor(torsoBorder.size.x / 2.0f), Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f + rightArmOffset + 1, transform.position.z);

                if (characterSettings.rightHandSize.z % 2 != 0) backGrid.GetComponent<DrawGrid>().rightHandTilemap.gameObject.transform.position = new Vector3(rightHandBorder.transform.position.x - rightHandBorder.size.x / 2.0f, rightHandBorder.transform.position.y + 0.5f, transform.position.z);
                else backGrid.GetComponent<DrawGrid>().rightHandTilemap.gameObject.transform.position = new Vector3(rightHandBorder.transform.position.x - rightHandBorder.size.x / 2.0f, rightHandBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.rightThumbSize.z % 2 != 0) backGrid.GetComponent<DrawGrid>().rightThumbTilemap.gameObject.transform.position = new Vector3(rightThumbBorder.transform.position.x - rightThumbBorder.size.x / 2.0f, rightThumbBorder.transform.position.y + 0.5f, transform.position.z);
                else backGrid.GetComponent<DrawGrid>().rightThumbTilemap.gameObject.transform.position = new Vector3(rightThumbBorder.transform.position.x - rightThumbBorder.size.x / 2.0f, rightThumbBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.rightIndexSize.z % 2 != 0) backGrid.GetComponent<DrawGrid>().rightIndexTilemap.gameObject.transform.position = new Vector3(rightIndexBorder.transform.position.x - rightIndexBorder.size.x / 2.0f, rightIndexBorder.transform.position.y + 0.5f, transform.position.z);
                else backGrid.GetComponent<DrawGrid>().rightIndexTilemap.gameObject.transform.position = new Vector3(rightIndexBorder.transform.position.x - rightIndexBorder.size.x / 2.0f, rightIndexBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.rightMiddleSize.z % 2 != 0) backGrid.GetComponent<DrawGrid>().rightMiddleTilemap.gameObject.transform.position = new Vector3(rightMiddleBorder.transform.position.x - rightMiddleBorder.size.x / 2.0f, rightMiddleBorder.transform.position.y + 0.5f, transform.position.z);
                else backGrid.GetComponent<DrawGrid>().rightMiddleTilemap.gameObject.transform.position = new Vector3(rightMiddleBorder.transform.position.x - rightMiddleBorder.size.x / 2.0f, rightMiddleBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.rightRingSize.z % 2 != 0) backGrid.GetComponent<DrawGrid>().rightRingTilemap.gameObject.transform.position = new Vector3(rightRingBorder.transform.position.x - rightRingBorder.size.x / 2.0f, rightRingBorder.transform.position.y + 0.5f, transform.position.z);
                else backGrid.GetComponent<DrawGrid>().rightRingTilemap.gameObject.transform.position = new Vector3(rightRingBorder.transform.position.x - rightRingBorder.size.x / 2.0f, rightRingBorder.transform.position.y + 1, transform.position.z);
                if (characterSettings.rightPinkySize.z % 2 != 0) backGrid.GetComponent<DrawGrid>().rightPinkyTilemap.gameObject.transform.position = new Vector3(rightPinkyBorder.transform.position.x - rightPinkyBorder.size.x / 2.0f, rightPinkyBorder.transform.position.y + 0.5f, transform.position.z);
                else backGrid.GetComponent<DrawGrid>().rightPinkyTilemap.gameObject.transform.position = new Vector3(rightPinkyBorder.transform.position.x - rightPinkyBorder.size.x / 2.0f, rightPinkyBorder.transform.position.y + 1, transform.position.z);

                if (characterSettings.leftLegSize.x % 2 != 0) backGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftLegBorder.size.x / 2.0f + leftLegOffset, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else backGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftLegBorder.size.x / 2.0f + leftLegOffset + 1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.leftFootSize.z % 2 != 0) backGrid.GetComponent<DrawGrid>().leftFootTilemap.gameObject.transform.position = new Vector3(leftFootBorder.transform.position.x - leftFootOffset + 1, leftFootBorder.transform.position.y - 0.5f, transform.position.z);
                else backGrid.GetComponent<DrawGrid>().leftFootTilemap.gameObject.transform.position = new Vector3(leftFootBorder.transform.position.x - leftFootOffset + 1, leftFootBorder.transform.position.y - 1, transform.position.z);

                if (characterSettings.rightLegSize.x % 2 != 0) backGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(Mathf.Floor(torsoBorder.size.x / 2.0f) - rightLegBorder.size.x / 2.0f + rightLegOffset, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else backGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(Mathf.Floor(torsoBorder.size.x / 2.0f) - rightLegBorder.size.x / 2.0f + rightLegOffset + 1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.rightFootSize.z % 2 != 0) backGrid.GetComponent<DrawGrid>().rightFootTilemap.gameObject.transform.position = new Vector3(rightFootBorder.transform.position.x - rightFootOffset + 1, rightFootBorder.transform.position.y - 0.5f, transform.position.z);
                else backGrid.GetComponent<DrawGrid>().rightFootTilemap.gameObject.transform.position = new Vector3(rightFootBorder.transform.position.x - rightFootOffset + 1, rightFootBorder.transform.position.y - 1, transform.position.z);

                //backGrid.GetComponent<DrawGrid>().CleanAllTilemaps();
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
                leftHandBorder.size = new Vector2(characterSettings.leftHandSize.x, characterSettings.leftHandSize.z);
                leftThumbBorder.size = new Vector2(characterSettings.leftThumbSize.x, characterSettings.leftThumbSize.z);
                leftIndexBorder.size = new Vector2(characterSettings.leftIndexSize.x, characterSettings.leftIndexSize.z);
                leftMiddleBorder.size = new Vector2(characterSettings.leftMiddleSize.x, characterSettings.leftMiddleSize.z);
                leftRingBorder.size = new Vector2(characterSettings.leftRingSize.x, characterSettings.leftRingSize.z);
                leftPinkyBorder.size = new Vector2(characterSettings.leftPinkySize.x, characterSettings.leftPinkySize.z);
                rightArmBorder.size = new Vector2(characterSettings.rightArmSize.x, characterSettings.rightArmSize.z);
                rightHandBorder.size = new Vector2(characterSettings.rightHandSize.x, characterSettings.rightHandSize.z);
                rightThumbBorder.size = new Vector2(characterSettings.rightThumbSize.x, characterSettings.rightThumbSize.z);
                rightIndexBorder.size = new Vector2(characterSettings.rightIndexSize.x, characterSettings.rightIndexSize.z);
                rightMiddleBorder.size = new Vector2(characterSettings.rightMiddleSize.x, characterSettings.rightMiddleSize.z);
                rightRingBorder.size = new Vector2(characterSettings.rightRingSize.x, characterSettings.rightRingSize.z);
                rightPinkyBorder.size = new Vector2(characterSettings.rightPinkySize.x, characterSettings.rightPinkySize.z);
                leftLegBorder.size = new Vector2(characterSettings.leftLegSize.z, characterSettings.leftLegSize.y);
                leftFootBorder.size = new Vector2(characterSettings.leftFootSize.y, characterSettings.leftFootSize.z);
                rightLegBorder.size = new Vector2(characterSettings.rightLegSize.z, characterSettings.rightLegSize.y);
                rightFootBorder.size = new Vector2(characterSettings.rightFootSize.y, characterSettings.rightFootSize.z);

                // Set the offsets of each border to line up with the rest of the body properly
                if (characterSettings.headSize.z % 2 != 0) // Odd
                {
                    headPositionX = -0.5f;
                }
                if (characterSettings.leftArmSize.x % 2 != 0) // Odd
                {
                    leftArmOffset = -0.5f;
                }
                if (characterSettings.leftHandSize.x % 2 != 0) // Odd
                {
                    leftHandOffset = -0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftArmSize.z % 2)
                {
                    leftHandOffsetY = 0.5f;
                }
                if (characterSettings.leftThumbSize.x % 2 != 0) // Odd
                {
                    leftThumbOffset = -0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftThumbSize.z % 2)
                {
                    leftThumbOffsetY = 0.5f;
                }
                if (characterSettings.leftIndexSize.x % 2 != 0) // Odd
                {
                    leftIndexOffset = -0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftIndexSize.z % 2)
                {
                    leftIndexOffsetY = 0.5f;
                }
                if (characterSettings.leftMiddleSize.x % 2 != 0) // Odd
                {
                    leftMiddleOffset = -0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftMiddleSize.z % 2)
                {
                    leftMiddleOffsetY = 0.5f;
                }
                if (characterSettings.leftRingSize.x % 2 != 0) // Odd
                {
                    leftRingOffset = -0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftRingSize.z % 2)
                {
                    leftRingOffsetY = 0.5f;
                }
                if (characterSettings.leftPinkySize.x % 2 != 0) // Odd
                {
                    leftPinkyOffset = -0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftPinkySize.z % 2)
                {
                    leftPinkyOffsetY = 0.5f;
                }
                if (characterSettings.rightArmSize.x % 2 != 0) // Odd
                {
                    rightArmOffset = -0.5f;
                }
                if (characterSettings.rightHandSize.x % 2 != 0) // Odd
                {
                    rightHandOffset = -0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightArmSize.z % 2)
                {
                    rightHandOffsetY = 0.5f;
                }
                if (characterSettings.rightThumbSize.x % 2 != 0) // Odd
                {
                    rightThumbOffset = -0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightThumbSize.z % 2)
                {
                    rightThumbOffsetY = 0.5f;
                }
                if (characterSettings.rightIndexSize.x % 2 != 0) // Odd
                {
                    rightIndexOffset = -0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightIndexSize.z % 2)
                {
                    rightIndexOffsetY = 0.5f;
                }
                if (characterSettings.rightMiddleSize.x % 2 != 0) // Odd
                {
                    rightMiddleOffset = -0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightMiddleSize.z % 2)
                {
                    rightMiddleOffsetY = 0.5f;
                }
                if (characterSettings.rightRingSize.x % 2 != 0) // Odd
                {
                    rightRingOffset = -0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightRingSize.z % 2)
                {
                    rightRingOffsetY = 0.5f;
                }
                if (characterSettings.rightPinkySize.x % 2 != 0) // Odd
                {
                    rightPinkyOffset = -0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightPinkySize.z % 2)
                {
                    rightPinkyOffsetY = 0.5f;
                }
                if (characterSettings.leftLegSize.z % 2 != 0) // Odd
                {
                    leftLegOffset = -0.5f;
                }
                if (characterSettings.leftFootSize.y % 2 != 0) // Odd
                {
                    leftFootOffset = -0.5f;
                }
                if (characterSettings.rightLegSize.z % 2 != 0) // Odd
                {
                    rightLegOffset = -0.5f;
                }
                if (characterSettings.rightFootSize.y % 2 != 0) // Odd
                {
                    rightFootOffset = -0.5f;
                }
                // The z-values determine which tilemap the user is editing (closer ones have a closer z-value)
                headBorder.gameObject.transform.position = new Vector3(headPositionX, Mathf.Ceil(torsoBorder.size.y / 2.0f) + headBorder.size.y / 2.0f, 103);
                leftArmBorder.gameObject.transform.position = new Vector3(leftArmOffset, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f, 102.9f);
                leftHandBorder.gameObject.transform.position = new Vector3(leftHandOffset, leftArmBorder.transform.position.y + leftHandOffsetY, 102.8f);
                leftThumbBorder.gameObject.transform.position = new Vector3(leftHandBorder.transform.position.x - leftHandBorder.size.x / 2.0f - leftThumbBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftThumbOffsetY, 102.7f);
                leftIndexBorder.gameObject.transform.position = new Vector3(leftHandBorder.transform.position.x - leftHandBorder.size.x / 2.0f + leftIndexBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftIndexOffsetY, 102.7f);
                leftMiddleBorder.gameObject.transform.position = new Vector3(leftHandBorder.transform.position.x - leftHandBorder.size.x / 2.0f + leftIndexBorder.size.x + leftMiddleBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftMiddleOffsetY, 102.7f);
                leftRingBorder.gameObject.transform.position = new Vector3(leftHandBorder.transform.position.x - leftHandBorder.size.x / 2.0f + leftIndexBorder.size.x + leftMiddleBorder.size.x + leftRingBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftRingOffsetY, 102.7f);
                leftPinkyBorder.gameObject.transform.position = new Vector3(leftHandBorder.transform.position.x - leftHandBorder.size.x / 2.0f + leftIndexBorder.size.x + leftMiddleBorder.size.x + leftRingBorder.size.x + leftPinkyBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftPinkyOffsetY, 102.7f);
                rightArmBorder.gameObject.transform.position = new Vector3(rightArmOffset, Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f, 103.1f);
                rightHandBorder.gameObject.transform.position = new Vector3(rightHandOffset, rightArmBorder.transform.position.y + rightHandOffsetY, 103.2f);
                rightThumbBorder.gameObject.transform.position = new Vector3(rightHandBorder.transform.position.x - rightHandBorder.size.x / 2.0f - rightThumbBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightThumbOffsetY, 103.3f);
                rightIndexBorder.gameObject.transform.position = new Vector3(rightHandBorder.transform.position.x - rightHandBorder.size.x / 2.0f + rightIndexBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightIndexOffsetY, 103.3f);
                rightMiddleBorder.gameObject.transform.position = new Vector3(rightHandBorder.transform.position.x - rightHandBorder.size.x / 2.0f + rightIndexBorder.size.x + rightMiddleBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightMiddleOffsetY, 103.3f);
                rightRingBorder.gameObject.transform.position = new Vector3(rightHandBorder.transform.position.x - rightHandBorder.size.x / 2.0f + rightIndexBorder.size.x + rightMiddleBorder.size.x + rightRingBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightRingOffsetY, 103.3f);
                rightPinkyBorder.gameObject.transform.position = new Vector3(rightHandBorder.transform.position.x - rightHandBorder.size.x / 2.0f + rightIndexBorder.size.x + rightMiddleBorder.size.x + rightRingBorder.size.x + rightPinkyBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightPinkyOffsetY, 103.3f);
                leftLegBorder.gameObject.transform.position = new Vector3(leftLegOffset, -Mathf.Floor(torsoBorder.size.y / 2.0f) - leftLegBorder.size.y / 2.0f, 102.9f);
                leftFootBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(leftFootBorder.size.x / 2.0f) + Mathf.Floor(leftLegBorder.size.x / 2.0f) + leftFootOffset, -Mathf.Floor(torsoBorder.size.y / 2.0f) - leftLegBorder.size.y - leftFootBorder.size.y / 2.0f, 102.9f);
                rightLegBorder.gameObject.transform.position = new Vector3(rightLegOffset, -Mathf.Floor(torsoBorder.size.y / 2.0f) - rightLegBorder.size.y / 2.0f, 103.1f);
                rightFootBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(rightFootBorder.size.x / 2.0f) + Mathf.Floor(rightLegBorder.size.x / 2.0f) + rightFootOffset, -Mathf.Floor(torsoBorder.size.y / 2.0f) - rightLegBorder.size.y - rightFootBorder.size.y / 2.0f, 103.1f);

                if (characterSettings.headSize.z % 2 != 0) leftGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(0, Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(1, Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.torsoSize.z % 2 != 0) leftGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(0, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.leftArmSize.z % 2 != 0) leftArmOffset = -0.5f;
                else leftArmOffset = 0;
                if (characterSettings.leftArmSize.x % 2 != 0) leftGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(0, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f + 1 + leftArmOffset, transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(1, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f + 1 + leftArmOffset, transform.position.z);

                if (characterSettings.leftHandSize.z % 2 != 0) leftHandOffsetY = 0.5f;
                else leftHandOffsetY = 1;
                if (characterSettings.leftHandSize.x % 2 != 0) leftGrid.GetComponent<DrawGrid>().leftHandTilemap.gameObject.transform.position = new Vector3(0, leftHandBorder.transform.position.y + leftHandOffsetY, transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().leftHandTilemap.gameObject.transform.position = new Vector3(1, leftHandBorder.transform.position.y + leftHandOffsetY, transform.position.z);

                if (characterSettings.leftThumbSize.z % 2 != 0) leftThumbOffsetY = 0.5f;
                else leftThumbOffsetY = 1;
                if (characterSettings.leftThumbSize.x % 2 != 0) leftGrid.GetComponent<DrawGrid>().leftThumbTilemap.gameObject.transform.position = new Vector3(leftThumbBorder.transform.position.x + 0.5f, leftThumbBorder.transform.position.y + leftThumbOffsetY, transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().leftThumbTilemap.gameObject.transform.position = new Vector3(leftThumbBorder.transform.position.x + 1, leftThumbBorder.transform.position.y + leftThumbOffsetY, transform.position.z);

                if (characterSettings.leftIndexSize.z % 2 != 0) leftIndexOffsetY = 0.5f;
                else leftIndexOffsetY = 1;
                if (characterSettings.leftIndexSize.x % 2 != 0) leftGrid.GetComponent<DrawGrid>().leftIndexTilemap.gameObject.transform.position = new Vector3(leftIndexBorder.transform.position.x + 0.5f, leftIndexBorder.transform.position.y + leftIndexOffsetY, transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().leftIndexTilemap.gameObject.transform.position = new Vector3(leftIndexBorder.transform.position.x + 1, leftIndexBorder.transform.position.y + leftIndexOffsetY, transform.position.z);

                if (characterSettings.leftMiddleSize.z % 2 != 0) leftMiddleOffsetY = 0.5f;
                else leftMiddleOffsetY = 1;
                if (characterSettings.leftMiddleSize.x % 2 != 0) leftGrid.GetComponent<DrawGrid>().leftMiddleTilemap.gameObject.transform.position = new Vector3(leftMiddleBorder.transform.position.x + 0.5f, leftMiddleBorder.transform.position.y + leftMiddleOffsetY, transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().leftMiddleTilemap.gameObject.transform.position = new Vector3(leftMiddleBorder.transform.position.x + 1, leftMiddleBorder.transform.position.y + leftMiddleOffsetY, transform.position.z);

                if (characterSettings.leftRingSize.z % 2 != 0) leftRingOffsetY = 0.5f;
                else leftRingOffsetY = 1;
                if (characterSettings.leftRingSize.x % 2 != 0) leftGrid.GetComponent<DrawGrid>().leftRingTilemap.gameObject.transform.position = new Vector3(leftRingBorder.transform.position.x + 0.5f, leftRingBorder.transform.position.y + leftRingOffsetY, transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().leftRingTilemap.gameObject.transform.position = new Vector3(leftRingBorder.transform.position.x + 1, leftRingBorder.transform.position.y + leftRingOffsetY, transform.position.z);

                if (characterSettings.leftPinkySize.z % 2 != 0) leftPinkyOffsetY = 0.5f;
                else leftPinkyOffsetY = 1;
                if (characterSettings.leftPinkySize.x % 2 != 0) leftGrid.GetComponent<DrawGrid>().leftPinkyTilemap.gameObject.transform.position = new Vector3(leftPinkyBorder.transform.position.x + 0.5f, leftPinkyBorder.transform.position.y + leftPinkyOffsetY, transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().leftPinkyTilemap.gameObject.transform.position = new Vector3(leftPinkyBorder.transform.position.x + 1, leftPinkyBorder.transform.position.y + leftPinkyOffsetY, transform.position.z);

                if (characterSettings.rightArmSize.z % 2 != 0) rightArmOffset = -0.5f;
                else rightArmOffset = 0;
                leftGrid.GetComponent<DrawGrid>().rightArmTilemap.gameObject.transform.position = new Vector3(-1, Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f + 1 + rightArmOffset, transform.position.z);

                if (characterSettings.rightHandSize.z % 2 != 0) rightHandOffsetY = 0.5f;
                else rightHandOffsetY = 1;
                leftGrid.GetComponent<DrawGrid>().rightHandTilemap.gameObject.transform.position = new Vector3(-1, rightHandBorder.transform.position.y + rightHandOffsetY, transform.position.z);

                if (characterSettings.rightThumbSize.z % 2 != 0) rightThumbOffsetY = 0.5f;
                else rightThumbOffsetY = 1;
                if (characterSettings.rightThumbSize.x % 2 != 0) leftGrid.GetComponent<DrawGrid>().rightThumbTilemap.gameObject.transform.position = new Vector3(rightThumbBorder.transform.position.x - 0.5f, rightThumbBorder.transform.position.y + rightThumbOffsetY, transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().rightThumbTilemap.gameObject.transform.position = new Vector3(rightThumbBorder.transform.position.x - 1, rightThumbBorder.transform.position.y + rightThumbOffsetY, transform.position.z);

                if (characterSettings.rightIndexSize.z % 2 != 0) rightIndexOffsetY = 0.5f;
                else rightIndexOffsetY = 1;
                if (characterSettings.rightIndexSize.x % 2 != 0) leftGrid.GetComponent<DrawGrid>().rightIndexTilemap.gameObject.transform.position = new Vector3(rightIndexBorder.transform.position.x - 0.5f, rightIndexBorder.transform.position.y + rightIndexOffsetY, transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().rightIndexTilemap.gameObject.transform.position = new Vector3(rightIndexBorder.transform.position.x - 1, rightIndexBorder.transform.position.y + rightIndexOffsetY, transform.position.z);

                if (characterSettings.rightMiddleSize.z % 2 != 0) rightMiddleOffsetY = 0.5f;
                else rightMiddleOffsetY = 1;
                if (characterSettings.rightMiddleSize.x % 2 != 0) leftGrid.GetComponent<DrawGrid>().rightMiddleTilemap.gameObject.transform.position = new Vector3(rightMiddleBorder.transform.position.x - 0.5f, rightMiddleBorder.transform.position.y + rightMiddleOffsetY, transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().rightMiddleTilemap.gameObject.transform.position = new Vector3(rightMiddleBorder.transform.position.x - 1, rightMiddleBorder.transform.position.y + rightMiddleOffsetY, transform.position.z);

                if (characterSettings.rightRingSize.z % 2 != 0) rightRingOffsetY = 0.5f;
                else rightRingOffsetY = 1;
                if (characterSettings.rightRingSize.x % 2 != 0) leftGrid.GetComponent<DrawGrid>().rightRingTilemap.gameObject.transform.position = new Vector3(rightRingBorder.transform.position.x - 0.5f, rightRingBorder.transform.position.y + rightRingOffsetY, transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().rightRingTilemap.gameObject.transform.position = new Vector3(rightRingBorder.transform.position.x - 1, rightRingBorder.transform.position.y + rightRingOffsetY, transform.position.z);

                if (characterSettings.rightPinkySize.z % 2 != 0) rightPinkyOffsetY = 0.5f;
                else rightPinkyOffsetY = 1;
                if (characterSettings.rightPinkySize.x % 2 != 0) leftGrid.GetComponent<DrawGrid>().rightPinkyTilemap.gameObject.transform.position = new Vector3(rightPinkyBorder.transform.position.x - 0.5f, rightPinkyBorder.transform.position.y + rightPinkyOffsetY, transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().rightPinkyTilemap.gameObject.transform.position = new Vector3(rightPinkyBorder.transform.position.x - 1, rightPinkyBorder.transform.position.y + rightPinkyOffsetY, transform.position.z);

                if (characterSettings.leftLegSize.z % 2 != 0) leftGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(0, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.leftFootSize.z % 2 != 0) leftGrid.GetComponent<DrawGrid>().leftFootTilemap.gameObject.transform.position = new Vector3(leftFootBorder.transform.position.x + leftFootBorder.size.x / 2.0f, leftFootBorder.transform.position.y - 0.5f, transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().leftFootTilemap.gameObject.transform.position = new Vector3(leftFootBorder.transform.position.x + leftFootBorder.size.x / 2.0f, leftFootBorder.transform.position.y - 1, transform.position.z);

                if (characterSettings.rightLegSize.z % 2 != 0) leftGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(0, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.rightFootSize.z % 2 != 0) leftGrid.GetComponent<DrawGrid>().rightFootTilemap.gameObject.transform.position = new Vector3(rightFootBorder.transform.position.x + rightFootBorder.size.x / 2.0f, rightFootBorder.transform.position.y - 0.5f, transform.position.z);
                else leftGrid.GetComponent<DrawGrid>().rightFootTilemap.gameObject.transform.position = new Vector3(rightFootBorder.transform.position.x + rightFootBorder.size.x / 2.0f, rightFootBorder.transform.position.y - 1, transform.position.z);

                //leftGrid.GetComponent<DrawGrid>().CleanAllTilemaps();
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
                leftHandBorder.size = new Vector2(characterSettings.leftHandSize.x, characterSettings.leftHandSize.z);
                leftThumbBorder.size = new Vector2(characterSettings.leftThumbSize.x, characterSettings.leftThumbSize.z);
                leftIndexBorder.size = new Vector2(characterSettings.leftIndexSize.x, characterSettings.leftIndexSize.z);
                leftMiddleBorder.size = new Vector2(characterSettings.leftMiddleSize.x, characterSettings.leftMiddleSize.z);
                leftRingBorder.size = new Vector2(characterSettings.leftRingSize.x, characterSettings.leftRingSize.z);
                leftPinkyBorder.size = new Vector2(characterSettings.leftPinkySize.x, characterSettings.leftPinkySize.z);
                rightArmBorder.size = new Vector2(characterSettings.rightArmSize.x, characterSettings.rightArmSize.z);
                rightHandBorder.size = new Vector2(characterSettings.rightHandSize.x, characterSettings.rightHandSize.z);
                rightThumbBorder.size = new Vector2(characterSettings.rightThumbSize.x, characterSettings.rightThumbSize.z);
                rightIndexBorder.size = new Vector2(characterSettings.rightIndexSize.x, characterSettings.rightIndexSize.z);
                rightMiddleBorder.size = new Vector2(characterSettings.rightMiddleSize.x, characterSettings.rightMiddleSize.z);
                rightRingBorder.size = new Vector2(characterSettings.rightRingSize.x, characterSettings.rightRingSize.z);
                rightPinkyBorder.size = new Vector2(characterSettings.rightPinkySize.x, characterSettings.rightPinkySize.z);
                leftLegBorder.size = new Vector2(characterSettings.leftLegSize.z, characterSettings.leftLegSize.y);
                leftFootBorder.size = new Vector2(characterSettings.leftFootSize.y, characterSettings.leftFootSize.z);
                rightLegBorder.size = new Vector2(characterSettings.rightLegSize.z, characterSettings.rightLegSize.y);
                rightFootBorder.size = new Vector2(characterSettings.rightFootSize.y, characterSettings.rightFootSize.z);

                // Set the offsets of each border to line up with the rest of the body properly
                if (characterSettings.headSize.z % 2 != 0) // Odd
                {
                    headPositionX = 0.5f;
                }
                if (characterSettings.leftArmSize.x % 2 != 0) // Odd
                {
                    leftArmOffset = 0.5f;
                }
                if (characterSettings.leftHandSize.x % 2 != 0) // Odd
                {
                    leftHandOffset = 0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftArmSize.z % 2)
                {
                    leftHandOffsetY = 0.5f;
                }
                if (characterSettings.leftThumbSize.x % 2 != 0) // Odd
                {
                    leftThumbOffset = 0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftThumbSize.z % 2)
                {
                    leftThumbOffsetY = 0.5f;
                }
                if (characterSettings.leftIndexSize.x % 2 != 0) // Odd
                {
                    leftIndexOffset = 0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftIndexSize.z % 2)
                {
                    leftIndexOffsetY = 0.5f;
                }
                if (characterSettings.leftMiddleSize.x % 2 != 0) // Odd
                {
                    leftMiddleOffset = 0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftMiddleSize.z % 2)
                {
                    leftMiddleOffsetY = 0.5f;
                }
                if (characterSettings.leftRingSize.x % 2 != 0) // Odd
                {
                    leftRingOffset = 0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftRingSize.z % 2)
                {
                    leftRingOffsetY = 0.5f;
                }
                if (characterSettings.leftPinkySize.x % 2 != 0) // Odd
                {
                    leftPinkyOffset = 0.5f;
                }
                if (characterSettings.leftHandSize.z % 2 != characterSettings.leftPinkySize.z % 2)
                {
                    leftPinkyOffsetY = 0.5f;
                }
                if (characterSettings.rightArmSize.x % 2 != 0) // Odd
                {
                    rightArmOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.x % 2 != 0) // Odd
                {
                    rightHandOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightArmSize.z % 2)
                {
                    rightHandOffsetY = 0.5f;
                }
                if (characterSettings.rightThumbSize.x % 2 != 0) // Odd
                {
                    rightThumbOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightThumbSize.z % 2)
                {
                    rightThumbOffsetY = 0.5f;
                }
                if (characterSettings.rightIndexSize.x % 2 != 0) // Odd
                {
                    rightIndexOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightIndexSize.z % 2)
                {
                    rightIndexOffsetY = 0.5f;
                }
                if (characterSettings.rightMiddleSize.x % 2 != 0) // Odd
                {
                    rightMiddleOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightMiddleSize.z % 2)
                {
                    rightMiddleOffsetY = 0.5f;
                }
                if (characterSettings.rightRingSize.x % 2 != 0) // Odd
                {
                    rightRingOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightRingSize.z % 2)
                {
                    rightRingOffsetY = 0.5f;
                }
                if (characterSettings.rightPinkySize.x % 2 != 0) // Odd
                {
                    rightPinkyOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.z % 2 != characterSettings.rightPinkySize.z % 2)
                {
                    rightPinkyOffsetY = 0.5f;
                }
                if (characterSettings.leftLegSize.z % 2 != 0) // Odd
                {
                    leftLegOffset = 0.5f;
                }
                if (characterSettings.leftFootSize.y % 2 != 0) // Odd
                {
                    leftFootOffset = 0.5f;
                }
                if (characterSettings.rightLegSize.z % 2 != 0) // Odd
                {
                    rightLegOffset = 0.5f;
                }
                if (characterSettings.rightFootSize.y % 2 != 0) // Odd
                {
                    rightFootOffset = 0.5f;
                }
                // The z-values determine which tilemap the user is editing (closer ones have a closer z-value)
                headBorder.gameObject.transform.position = new Vector3(headPositionX, Mathf.Ceil(torsoBorder.size.y / 2.0f) + headBorder.size.y / 2.0f, 103);
                leftArmBorder.gameObject.transform.position = new Vector3(leftArmOffset, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f, 103.1f);
                leftHandBorder.gameObject.transform.position = new Vector3(leftHandOffset, leftArmBorder.transform.position.y + leftHandOffsetY, 103.2f);
                leftThumbBorder.gameObject.transform.position = new Vector3(leftHandBorder.transform.position.x + leftHandBorder.size.x / 2.0f + leftThumbBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftThumbOffsetY, 103.3f);
                leftIndexBorder.gameObject.transform.position = new Vector3(leftHandBorder.transform.position.x + leftHandBorder.size.x / 2.0f - leftIndexBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftIndexOffsetY, 103.3f);
                leftMiddleBorder.gameObject.transform.position = new Vector3(leftHandBorder.transform.position.x + leftHandBorder.size.x / 2.0f - leftIndexBorder.size.x - leftMiddleBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftMiddleOffsetY, 103.3f);
                leftRingBorder.gameObject.transform.position = new Vector3(leftHandBorder.transform.position.x + leftHandBorder.size.x / 2.0f - leftIndexBorder.size.x - leftMiddleBorder.size.x - leftRingBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftRingOffsetY, 103.3f);
                leftPinkyBorder.gameObject.transform.position = new Vector3(leftHandBorder.transform.position.x + leftHandBorder.size.x / 2.0f - leftIndexBorder.size.x - leftMiddleBorder.size.x - leftRingBorder.size.x - leftPinkyBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftPinkyOffsetY, 103.3f);
                rightArmBorder.gameObject.transform.position = new Vector3(rightArmOffset, Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f, 102.9f);
                rightHandBorder.gameObject.transform.position = new Vector3(rightHandOffset, rightArmBorder.transform.position.y + rightHandOffsetY, 102.8f);
                rightThumbBorder.gameObject.transform.position = new Vector3(rightHandBorder.transform.position.x + rightHandBorder.size.x / 2.0f + rightThumbBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightThumbOffsetY, 102.7f);
                rightIndexBorder.gameObject.transform.position = new Vector3(rightHandBorder.transform.position.x + rightHandBorder.size.x / 2.0f - rightIndexBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightIndexOffsetY, 102.7f);
                rightMiddleBorder.gameObject.transform.position = new Vector3(rightHandBorder.transform.position.x + rightHandBorder.size.x / 2.0f - rightIndexBorder.size.x - rightMiddleBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightMiddleOffsetY, 102.7f);
                rightRingBorder.gameObject.transform.position = new Vector3(rightHandBorder.transform.position.x + rightHandBorder.size.x / 2.0f - rightIndexBorder.size.x - rightMiddleBorder.size.x - rightRingBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightRingOffsetY, 102.7f);
                rightPinkyBorder.gameObject.transform.position = new Vector3(rightHandBorder.transform.position.x + rightHandBorder.size.x / 2.0f - rightIndexBorder.size.x - rightMiddleBorder.size.x - rightRingBorder.size.x - rightPinkyBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightPinkyOffsetY, 102.7f);
                leftLegBorder.gameObject.transform.position = new Vector3(leftLegOffset, -Mathf.Floor(torsoBorder.size.y / 2.0f) - leftLegBorder.size.y / 2.0f, 103.1f);
                leftFootBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(leftFootBorder.size.x / 2.0f) - Mathf.Floor(leftLegBorder.size.x / 2.0f) - leftFootOffset, -Mathf.Floor(torsoBorder.size.y / 2.0f) - leftLegBorder.size.y - leftFootBorder.size.y / 2.0f, 103.1f);
                rightLegBorder.gameObject.transform.position = new Vector3(rightLegOffset, -Mathf.Floor(torsoBorder.size.y / 2.0f) - rightLegBorder.size.y / 2.0f, 102.9f);
                rightFootBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(rightFootBorder.size.x / 2.0f) - Mathf.Floor(rightLegBorder.size.x / 2.0f) - rightFootOffset, -Mathf.Floor(torsoBorder.size.y / 2.0f) - rightLegBorder.size.y - rightFootBorder.size.y / 2.0f, 102.9f);

                if (characterSettings.headSize.z % 2 != 0) rightGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(0, Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(-1, Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.torsoSize.z % 2 != 0) rightGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(0, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(-1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.leftArmSize.z % 2 != 0) leftArmOffset = -0.5f;
                else leftArmOffset = 0;
                if (characterSettings.leftArmSize.x % 2 != 0) rightGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(0, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f + 1 + leftArmOffset, transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(-1, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f + 1 + leftArmOffset, transform.position.z);

                if (characterSettings.leftHandSize.z % 2 != 0) leftHandOffsetY = 0.5f;
                else leftHandOffsetY = 1;
                if (characterSettings.leftHandSize.x % 2 != 0) rightGrid.GetComponent<DrawGrid>().leftHandTilemap.gameObject.transform.position = new Vector3(0, leftHandBorder.transform.position.y + leftHandOffsetY, transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().leftHandTilemap.gameObject.transform.position = new Vector3(-1, leftHandBorder.transform.position.y + leftHandOffsetY, transform.position.z);

                if (characterSettings.leftThumbSize.z % 2 != 0) leftThumbOffsetY = 0.5f;
                else leftThumbOffsetY = 1;
                if (characterSettings.leftThumbSize.x % 2 != 0) rightGrid.GetComponent<DrawGrid>().leftThumbTilemap.gameObject.transform.position = new Vector3(leftThumbBorder.size.x, leftThumbBorder.transform.position.y + leftThumbOffsetY, transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().leftThumbTilemap.gameObject.transform.position = new Vector3(leftThumbBorder.size.x - 1, leftThumbBorder.transform.position.y + leftThumbOffsetY, transform.position.z);

                if (characterSettings.leftIndexSize.z % 2 != 0) leftIndexOffsetY = 0.5f;
                else leftIndexOffsetY = 1;
                if (characterSettings.leftIndexSize.x % 2 != 0) rightGrid.GetComponent<DrawGrid>().leftIndexTilemap.gameObject.transform.position = new Vector3(leftIndexBorder.size.x, leftIndexBorder.transform.position.y + leftIndexOffsetY, transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().leftIndexTilemap.gameObject.transform.position = new Vector3(leftIndexBorder.size.x - 1, leftIndexBorder.transform.position.y + leftIndexOffsetY, transform.position.z);

                if (characterSettings.leftMiddleSize.z % 2 != 0) leftMiddleOffsetY = 0.5f;
                else leftMiddleOffsetY = 1;
                if (characterSettings.leftMiddleSize.x % 2 != 0) rightGrid.GetComponent<DrawGrid>().leftMiddleTilemap.gameObject.transform.position = new Vector3(leftMiddleBorder.size.x, leftMiddleBorder.transform.position.y + leftMiddleOffsetY, transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().leftMiddleTilemap.gameObject.transform.position = new Vector3(leftMiddleBorder.size.x - 1, leftMiddleBorder.transform.position.y + leftMiddleOffsetY, transform.position.z);

                if (characterSettings.leftRingSize.z % 2 != 0) leftRingOffsetY = 0.5f;
                else leftRingOffsetY = 1;
                if (characterSettings.leftRingSize.x % 2 != 0) rightGrid.GetComponent<DrawGrid>().leftRingTilemap.gameObject.transform.position = new Vector3(leftRingBorder.size.x, leftRingBorder.transform.position.y + leftRingOffsetY, transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().leftRingTilemap.gameObject.transform.position = new Vector3(leftRingBorder.size.x - 1, leftRingBorder.transform.position.y + leftRingOffsetY, transform.position.z);

                if (characterSettings.leftPinkySize.z % 2 != 0) leftPinkyOffsetY = 0.5f;
                else leftPinkyOffsetY = 1;
                if (characterSettings.leftPinkySize.x % 2 != 0) rightGrid.GetComponent<DrawGrid>().leftPinkyTilemap.gameObject.transform.position = new Vector3(leftPinkyBorder.size.x, leftPinkyBorder.transform.position.y + leftPinkyOffsetY, transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().leftPinkyTilemap.gameObject.transform.position = new Vector3(leftPinkyBorder.size.x - 1, leftPinkyBorder.transform.position.y + leftPinkyOffsetY, transform.position.z);

                if (characterSettings.rightArmSize.z % 2 != 0) rightArmOffset = -0.5f;
                else rightArmOffset = 0;
                rightGrid.GetComponent<DrawGrid>().rightArmTilemap.gameObject.transform.position = new Vector3(1, Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f + 1 + rightArmOffset, transform.position.z);

                if (characterSettings.rightHandSize.z % 2 != 0) rightHandOffsetY = 0.5f;
                else rightHandOffsetY = 1;
                rightGrid.GetComponent<DrawGrid>().rightHandTilemap.gameObject.transform.position = new Vector3(1, rightHandBorder.transform.position.y + rightHandOffsetY, transform.position.z);

                if (characterSettings.rightThumbSize.z % 2 != 0) rightThumbOffsetY = 0.5f;
                else rightThumbOffsetY = 1;
                if (characterSettings.rightThumbSize.x % 2 != 0) rightGrid.GetComponent<DrawGrid>().rightThumbTilemap.gameObject.transform.position = new Vector3(rightThumbBorder.transform.position.x + 0.5f, rightThumbBorder.transform.position.y + rightThumbOffsetY, transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().rightThumbTilemap.gameObject.transform.position = new Vector3(rightThumbBorder.transform.position.x + 1, rightThumbBorder.transform.position.y + rightThumbOffsetY, transform.position.z);

                if (characterSettings.rightIndexSize.z % 2 != 0) rightIndexOffsetY = 0.5f;
                else rightIndexOffsetY = 1;
                if (characterSettings.rightIndexSize.x % 2 != 0) rightGrid.GetComponent<DrawGrid>().rightIndexTilemap.gameObject.transform.position = new Vector3(rightIndexBorder.transform.position.x + 0.5f, rightIndexBorder.transform.position.y + rightIndexOffsetY, transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().rightIndexTilemap.gameObject.transform.position = new Vector3(rightIndexBorder.transform.position.x + 1, rightIndexBorder.transform.position.y + rightIndexOffsetY, transform.position.z);

                if (characterSettings.rightMiddleSize.z % 2 != 0) rightMiddleOffsetY = 0.5f;
                else rightMiddleOffsetY = 1;
                if (characterSettings.rightMiddleSize.x % 2 != 0) rightGrid.GetComponent<DrawGrid>().rightMiddleTilemap.gameObject.transform.position = new Vector3(rightMiddleBorder.transform.position.x + 0.5f, rightMiddleBorder.transform.position.y + rightMiddleOffsetY, transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().rightMiddleTilemap.gameObject.transform.position = new Vector3(rightMiddleBorder.transform.position.x + 1, rightMiddleBorder.transform.position.y + rightMiddleOffsetY, transform.position.z);

                if (characterSettings.rightRingSize.z % 2 != 0) rightRingOffsetY = 0.5f;
                else rightRingOffsetY = 1;
                if (characterSettings.rightRingSize.x % 2 != 0) rightGrid.GetComponent<DrawGrid>().rightRingTilemap.gameObject.transform.position = new Vector3(rightRingBorder.transform.position.x + 0.5f, rightRingBorder.transform.position.y + rightRingOffsetY, transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().rightRingTilemap.gameObject.transform.position = new Vector3(rightRingBorder.transform.position.x + 1, rightRingBorder.transform.position.y + rightRingOffsetY, transform.position.z);

                if (characterSettings.rightPinkySize.z % 2 != 0) rightPinkyOffsetY = 0.5f;
                else rightPinkyOffsetY = 1;
                if (characterSettings.rightPinkySize.x % 2 != 0) rightGrid.GetComponent<DrawGrid>().rightPinkyTilemap.gameObject.transform.position = new Vector3(rightPinkyBorder.transform.position.x + 0.5f, rightPinkyBorder.transform.position.y + rightPinkyOffsetY, transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().rightPinkyTilemap.gameObject.transform.position = new Vector3(rightPinkyBorder.transform.position.x + 1, rightPinkyBorder.transform.position.y + rightPinkyOffsetY, transform.position.z);

                if (characterSettings.leftLegSize.z % 2 != 0) rightGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(0, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(-1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.leftFootSize.z % 2 != 0) rightGrid.GetComponent<DrawGrid>().leftFootTilemap.gameObject.transform.position = new Vector3(leftFootBorder.transform.position.x - leftFootBorder.size.x / 2.0f, leftFootBorder.transform.position.y - 0.5f, transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().leftFootTilemap.gameObject.transform.position = new Vector3(leftFootBorder.transform.position.x - leftFootBorder.size.x / 2.0f, leftFootBorder.transform.position.y - 1, transform.position.z);

                if (characterSettings.rightLegSize.z % 2 != 0) rightGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(0, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(-1, -Mathf.Ceil(torsoBorder.size.y / 2.0f), transform.position.z);

                if (characterSettings.rightFootSize.z % 2 != 0) rightGrid.GetComponent<DrawGrid>().rightFootTilemap.gameObject.transform.position = new Vector3(rightFootBorder.transform.position.x - rightFootBorder.size.x / 2.0f, rightFootBorder.transform.position.y - 0.5f, transform.position.z);
                else rightGrid.GetComponent<DrawGrid>().rightFootTilemap.gameObject.transform.position = new Vector3(rightFootBorder.transform.position.x - rightFootBorder.size.x / 2.0f, rightFootBorder.transform.position.y - 1, transform.position.z);

                //rightGrid.GetComponent<DrawGrid>().CleanAllTilemaps();
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
                leftHandBorder.size = new Vector2(characterSettings.leftHandSize.y, characterSettings.leftHandSize.x);
                leftThumbBorder.size = new Vector2(characterSettings.leftThumbSize.y, characterSettings.leftThumbSize.x);
                leftIndexBorder.size = new Vector2(characterSettings.leftIndexSize.y, characterSettings.leftIndexSize.x);
                leftMiddleBorder.size = new Vector2(characterSettings.leftMiddleSize.y, characterSettings.leftMiddleSize.x);
                leftRingBorder.size = new Vector2(characterSettings.leftRingSize.y, characterSettings.leftRingSize.x);
                leftPinkyBorder.size = new Vector2(characterSettings.leftPinkySize.y, characterSettings.leftPinkySize.x);
                rightArmBorder.size = new Vector2(characterSettings.rightArmSize.y, characterSettings.rightArmSize.x);
                rightHandBorder.size = new Vector2(characterSettings.rightHandSize.y, characterSettings.rightHandSize.x);
                rightThumbBorder.size = new Vector2(characterSettings.rightThumbSize.y, characterSettings.rightThumbSize.x);
                rightIndexBorder.size = new Vector2(characterSettings.rightIndexSize.y, characterSettings.rightIndexSize.x);
                rightMiddleBorder.size = new Vector2(characterSettings.rightMiddleSize.y, characterSettings.rightMiddleSize.x);
                rightRingBorder.size = new Vector2(characterSettings.rightRingSize.y, characterSettings.rightRingSize.x);
                rightPinkyBorder.size = new Vector2(characterSettings.rightPinkySize.y, characterSettings.rightPinkySize.x);
                leftLegBorder.size = new Vector2(characterSettings.leftLegSize.x, characterSettings.leftLegSize.z);
                leftFootBorder.size = new Vector2(characterSettings.leftFootSize.x, characterSettings.leftFootSize.y);
                rightLegBorder.size = new Vector2(characterSettings.rightLegSize.x, characterSettings.rightLegSize.z);
                rightFootBorder.size = new Vector2(characterSettings.rightFootSize.x, characterSettings.rightFootSize.y);

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
                if (characterSettings.leftHandSize.x % 2 != 0)
                {
                    leftHandOffset = -0.5f;
                }
                if (characterSettings.rightArmSize.x % 2 != 0) // Odd
                {
                    rightArmOffset = -0.5f;
                }
                if (characterSettings.rightHandSize.x % 2 != 0)
                {
                    rightHandOffset = -0.5f;
                }
                if (characterSettings.leftLegSize.z % 2 != 0) // Odd
                {
                    leftLegOffset = -0.5f;
                }
                if (characterSettings.leftLegSize.x % 2 != characterSettings.leftFootSize.x % 2)
                {
                    leftFootOffset = 0.5f;
                }
                if (characterSettings.leftFootSize.y % 2 != 0)
                {
                    leftFootOffsetY = 0.5f;
                }
                if (characterSettings.rightLegSize.z % 2 != 0) // Odd
                {
                    rightLegOffset = -0.5f;
                }
                if (characterSettings.rightLegSize.x % 2 != characterSettings.rightFootSize.x % 2)
                {
                    rightFootOffset = 0.5f;
                }
                if (characterSettings.rightFootSize.y % 2 != 0)
                {
                    rightFootOffsetY = 0.5f;
                }
                // The z-values determine which tilemap the user is editing (closer ones have a closer z-value)
                headBorder.gameObject.transform.position = new Vector3(headPositionX, headPositionZ, 102.9f);
                leftArmBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x / 2.0f, leftArmOffset, 103f);
                leftHandBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x + leftHandBorder.size.x / 2.0f, leftHandOffset, 103f);
                leftThumbBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x + Mathf.Floor(leftHandBorder.size.x / 2.0f) + leftThumbBorder.size.x / 2.0f, leftHandBorder.transform.position.y - leftHandBorder.size.y / 2.0f - leftThumbBorder.size.y / 2.0f, 103f);
                leftIndexBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x + leftHandBorder.size.x + leftIndexBorder.size.x / 2.0f, leftHandBorder.transform.position.y - leftHandBorder.size.y / 2.0f + leftIndexBorder.size.y / 2.0f, 103f);
                leftMiddleBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x + leftHandBorder.size.x + leftMiddleBorder.size.x / 2.0f, leftHandBorder.transform.position.y - leftHandBorder.size.y / 2.0f + leftIndexBorder.size.y + leftMiddleBorder.size.y / 2.0f, 103f);
                leftRingBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x + leftHandBorder.size.x + leftRingBorder.size.x / 2.0f, leftHandBorder.transform.position.y - leftHandBorder.size.y / 2.0f + leftIndexBorder.size.y + leftMiddleBorder.size.y + leftRingBorder.size.y / 2.0f, 103f);
                leftPinkyBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x + leftHandBorder.size.x + leftPinkyBorder.size.x / 2.0f, leftHandBorder.transform.position.y - leftHandBorder.size.y / 2.0f + leftIndexBorder.size.y + leftMiddleBorder.size.y + leftRingBorder.size.y + leftPinkyBorder.size.y / 2.0f, 103f);
                rightArmBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x / 2.0f, rightArmOffset, 103f);
                rightHandBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x - rightHandBorder.size.x / 2.0f, rightHandOffset, 103f);
                rightThumbBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x - Mathf.Floor(rightHandBorder.size.x / 2.0f) - rightThumbBorder.size.x / 2.0f, rightHandBorder.transform.position.y - rightHandBorder.size.y / 2.0f - rightThumbBorder.size.y / 2.0f, 103f);
                rightIndexBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x - rightHandBorder.size.x - rightIndexBorder.size.x / 2.0f, rightHandBorder.transform.position.y - rightHandBorder.size.y / 2.0f + rightIndexBorder.size.y / 2.0f, 103f);
                rightMiddleBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x - rightHandBorder.size.x - rightMiddleBorder.size.x / 2.0f, rightHandBorder.transform.position.y - rightHandBorder.size.y / 2.0f + rightIndexBorder.size.y + rightMiddleBorder.size.y / 2.0f, 103f);
                rightRingBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x - rightHandBorder.size.x - rightRingBorder.size.x / 2.0f, rightHandBorder.transform.position.y - rightHandBorder.size.y / 2.0f + rightIndexBorder.size.y + rightMiddleBorder.size.y + rightRingBorder.size.y / 2.0f, 103f);
                rightPinkyBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x - rightHandBorder.size.x - rightPinkyBorder.size.x / 2.0f, rightHandBorder.transform.position.y - rightHandBorder.size.y / 2.0f + rightIndexBorder.size.y + rightMiddleBorder.size.y + rightRingBorder.size.y + rightPinkyBorder.size.y / 2.0f, 103f);
                leftLegBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftLegBorder.size.x / 2.0f, leftLegOffset, 103.1f);
                leftFootBorder.gameObject.transform.position = new Vector3(leftLegBorder.transform.position.x + leftFootOffset, -Mathf.Ceil(leftFootBorder.size.y / 2.0f) + Mathf.Floor(leftLegBorder.size.y / 2.0f) + leftFootOffsetY, 103.2f);
                rightLegBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) + rightLegBorder.size.x / 2.0f, rightLegOffset, 103.1f);
                rightFootBorder.gameObject.transform.position = new Vector3(rightLegBorder.transform.position.x - rightFootOffset, -Mathf.Ceil(rightFootBorder.size.y / 2.0f) + Mathf.Floor(rightLegBorder.size.y / 2.0f) + rightFootOffsetY, 103.2f);

                if (characterSettings.headSize.z % 2 != 0) topGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(1, 0, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(1, 1, transform.position.z);

                if (characterSettings.torsoSize.z % 2 != 0) topGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(1, 0, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(1, 1, transform.position.z);

                if (characterSettings.leftArmSize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f), 0, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f), 1, transform.position.z);

                if (characterSettings.leftHandSize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().leftHandTilemap.gameObject.transform.position = new Vector3(leftHandBorder.transform.position.x - leftHandBorder.size.x / 2.0f, leftHandBorder.transform.position.y + 0.5f, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().leftHandTilemap.gameObject.transform.position = new Vector3(leftHandBorder.transform.position.x - leftHandBorder.size.x / 2.0f, leftHandBorder.transform.position.y + 1, transform.position.z);

                if (characterSettings.leftThumbSize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().leftThumbTilemap.gameObject.transform.position = new Vector3(leftThumbBorder.transform.position.x - leftThumbBorder.size.x / 2.0f, leftThumbBorder.transform.position.y + 0.5f, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().leftThumbTilemap.gameObject.transform.position = new Vector3(leftThumbBorder.transform.position.x - leftThumbBorder.size.x / 2.0f, leftThumbBorder.transform.position.y + 1, transform.position.z);

                if (characterSettings.leftIndexSize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().leftIndexTilemap.gameObject.transform.position = new Vector3(leftIndexBorder.transform.position.x - leftIndexBorder.size.x / 2.0f, leftIndexBorder.transform.position.y + 0.5f, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().leftIndexTilemap.gameObject.transform.position = new Vector3(leftIndexBorder.transform.position.x - leftIndexBorder.size.x / 2.0f, leftIndexBorder.transform.position.y + 1, transform.position.z);

                if (characterSettings.leftMiddleSize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().leftMiddleTilemap.gameObject.transform.position = new Vector3(leftMiddleBorder.transform.position.x - leftMiddleBorder.size.x / 2.0f, leftMiddleBorder.transform.position.y + 0.5f, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().leftMiddleTilemap.gameObject.transform.position = new Vector3(leftMiddleBorder.transform.position.x - leftMiddleBorder.size.x / 2.0f, leftMiddleBorder.transform.position.y + 1, transform.position.z);

                if (characterSettings.leftRingSize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().leftRingTilemap.gameObject.transform.position = new Vector3(leftRingBorder.transform.position.x - leftRingBorder.size.x / 2.0f, leftRingBorder.transform.position.y + 0.5f, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().leftRingTilemap.gameObject.transform.position = new Vector3(leftRingBorder.transform.position.x - leftRingBorder.size.x / 2.0f, leftRingBorder.transform.position.y + 1, transform.position.z);

                if (characterSettings.leftPinkySize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().leftPinkyTilemap.gameObject.transform.position = new Vector3(leftPinkyBorder.transform.position.x - leftPinkyBorder.size.x / 2.0f, leftPinkyBorder.transform.position.y + 0.5f, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().leftPinkyTilemap.gameObject.transform.position = new Vector3(leftPinkyBorder.transform.position.x - leftPinkyBorder.size.x / 2.0f, leftPinkyBorder.transform.position.y + 1, transform.position.z);

                topGrid.GetComponent<DrawGrid>().rightArmTilemap.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f), -1, transform.position.z);

                if (characterSettings.rightHandSize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().rightHandTilemap.gameObject.transform.position = new Vector3(rightHandBorder.transform.position.x + rightHandBorder.size.x / 2.0f, rightHandBorder.transform.position.y - 0.5f, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().rightHandTilemap.gameObject.transform.position = new Vector3(rightHandBorder.transform.position.x + rightHandBorder.size.x / 2.0f, rightHandBorder.transform.position.y - 1, transform.position.z);

                if (characterSettings.rightThumbSize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().rightThumbTilemap.gameObject.transform.position = new Vector3(rightThumbBorder.transform.position.x + rightThumbBorder.size.x / 2.0f, rightThumbBorder.transform.position.y - 0.5f, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().rightThumbTilemap.gameObject.transform.position = new Vector3(rightThumbBorder.transform.position.x + rightThumbBorder.size.x / 2.0f, rightThumbBorder.transform.position.y - 1, transform.position.z);

                if (characterSettings.rightIndexSize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().rightIndexTilemap.gameObject.transform.position = new Vector3(rightIndexBorder.transform.position.x + rightIndexBorder.size.x / 2.0f, rightIndexBorder.transform.position.y - 0.5f, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().rightIndexTilemap.gameObject.transform.position = new Vector3(rightIndexBorder.transform.position.x + rightIndexBorder.size.x / 2.0f, rightIndexBorder.transform.position.y - 1, transform.position.z);

                if (characterSettings.rightMiddleSize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().rightMiddleTilemap.gameObject.transform.position = new Vector3(rightMiddleBorder.transform.position.x + rightMiddleBorder.size.x / 2.0f, rightMiddleBorder.transform.position.y - 0.5f, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().rightMiddleTilemap.gameObject.transform.position = new Vector3(rightMiddleBorder.transform.position.x + rightMiddleBorder.size.x / 2.0f, rightMiddleBorder.transform.position.y - 1, transform.position.z);

                if (characterSettings.rightRingSize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().rightRingTilemap.gameObject.transform.position = new Vector3(rightRingBorder.transform.position.x + rightRingBorder.size.x / 2.0f, rightRingBorder.transform.position.y - 0.5f, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().rightRingTilemap.gameObject.transform.position = new Vector3(rightRingBorder.transform.position.x + rightRingBorder.size.x / 2.0f, rightRingBorder.transform.position.y - 1, transform.position.z);

                if (characterSettings.rightPinkySize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().rightPinkyTilemap.gameObject.transform.position = new Vector3(rightPinkyBorder.transform.position.x + rightPinkyBorder.size.x / 2.0f, rightPinkyBorder.transform.position.y - 0.5f, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().rightPinkyTilemap.gameObject.transform.position = new Vector3(rightPinkyBorder.transform.position.x + rightPinkyBorder.size.x / 2.0f, rightPinkyBorder.transform.position.y - 1, transform.position.z);

                if (characterSettings.leftLegSize.z % 2 != 0) leftLegOffset = 0;
                else leftLegOffset = 1;
                if (characterSettings.leftLegSize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftLegBorder.size.x / 2.0f - 0.5f, leftLegOffset, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftLegBorder.size.x / 2.0f - 1, leftLegOffset, transform.position.z);

                if (characterSettings.leftFootSize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().leftFootTilemap.gameObject.transform.position = new Vector3(leftFootBorder.transform.position.x - 0.5f, leftFootBorder.transform.position.y + leftFootBorder.size.y / 2.0f, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().leftFootTilemap.gameObject.transform.position = new Vector3(leftFootBorder.transform.position.x - 1, leftFootBorder.transform.position.y + leftFootBorder.size.y / 2.0f, transform.position.z);

                if (characterSettings.rightLegSize.z % 2 != 0) rightLegOffset = 0;
                else rightLegOffset = 1;
                if (characterSettings.rightLegSize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) + rightLegBorder.size.x / 2.0f - 0.5f, rightLegOffset, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) + rightLegBorder.size.x / 2.0f - 1, rightLegOffset, transform.position.z);

                if (characterSettings.rightFootSize.x % 2 != 0) topGrid.GetComponent<DrawGrid>().rightFootTilemap.gameObject.transform.position = new Vector3(rightFootBorder.transform.position.x - 0.5f, rightFootBorder.transform.position.y + rightFootBorder.size.y / 2.0f, transform.position.z);
                else topGrid.GetComponent<DrawGrid>().rightFootTilemap.gameObject.transform.position = new Vector3(rightFootBorder.transform.position.x - 1, rightFootBorder.transform.position.y + rightFootBorder.size.y / 2.0f, transform.position.z);

                //topGrid.GetComponent<DrawGrid>().CleanAllTilemaps();
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
                leftHandBorder.size = new Vector2(characterSettings.leftHandSize.y, characterSettings.leftHandSize.x);
                leftThumbBorder.size = new Vector2(characterSettings.leftThumbSize.y, characterSettings.leftThumbSize.x);
                leftIndexBorder.size = new Vector2(characterSettings.leftIndexSize.y, characterSettings.leftIndexSize.x);
                leftMiddleBorder.size = new Vector2(characterSettings.leftMiddleSize.y, characterSettings.leftMiddleSize.x);
                leftRingBorder.size = new Vector2(characterSettings.leftRingSize.y, characterSettings.leftRingSize.x);
                leftPinkyBorder.size = new Vector2(characterSettings.leftPinkySize.y, characterSettings.leftPinkySize.x);
                rightArmBorder.size = new Vector2(characterSettings.rightArmSize.y, characterSettings.rightArmSize.x);
                rightHandBorder.size = new Vector2(characterSettings.rightHandSize.y, characterSettings.rightHandSize.x);
                rightThumbBorder.size = new Vector2(characterSettings.rightThumbSize.y, characterSettings.rightThumbSize.x);
                rightIndexBorder.size = new Vector2(characterSettings.rightIndexSize.y, characterSettings.rightIndexSize.x);
                rightMiddleBorder.size = new Vector2(characterSettings.rightMiddleSize.y, characterSettings.rightMiddleSize.x);
                rightRingBorder.size = new Vector2(characterSettings.rightRingSize.y, characterSettings.rightRingSize.x);
                rightPinkyBorder.size = new Vector2(characterSettings.rightPinkySize.y, characterSettings.rightPinkySize.x);
                leftLegBorder.size = new Vector2(characterSettings.leftLegSize.x, characterSettings.leftLegSize.z);
                leftFootBorder.size = new Vector2(characterSettings.leftFootSize.x, characterSettings.leftFootSize.y);
                rightLegBorder.size = new Vector2(characterSettings.rightLegSize.x, characterSettings.rightLegSize.z);
                rightFootBorder.size = new Vector2(characterSettings.rightFootSize.x, characterSettings.rightFootSize.y);

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
                if (characterSettings.leftHandSize.x % 2 != 0)
                {
                    leftHandOffset = 0.5f;
                }
                if (characterSettings.rightArmSize.x % 2 != 0) // Odd
                {
                    rightArmOffset = 0.5f;
                }
                if (characterSettings.rightHandSize.x % 2 != 0)
                {
                    rightHandOffset = 0.5f;
                }
                if (characterSettings.leftLegSize.z % 2 != 0) // Odd
                {
                    leftLegOffset = 0.5f;
                }
                if (characterSettings.leftLegSize.x % 2 != characterSettings.leftFootSize.x % 2)
                {
                    leftFootOffset = 0.5f;
                }
                if (characterSettings.leftFootSize.y % 2 != 0)
                {
                    leftFootOffsetY = 0.5f;
                }
                if (characterSettings.rightLegSize.z % 2 != 0) // Odd
                {
                    rightLegOffset = 0.5f;
                }
                if (characterSettings.rightLegSize.x % 2 != characterSettings.rightFootSize.x % 2)
                {
                    rightFootOffset = 0.5f;
                }
                if (characterSettings.rightFootSize.y % 2 != 0)
                {
                    rightFootOffsetY = 0.5f;
                }
                // The z-values determine which tilemap the user is editing (closer ones have a closer z-value)
                headBorder.gameObject.transform.position = new Vector3(headPositionX, headPositionZ, 103.1f);
                leftArmBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x / 2.0f, leftArmOffset, 103);
                leftHandBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x + leftHandBorder.size.x / 2.0f, leftHandOffset, 103f);
                leftThumbBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x + Mathf.Floor(leftHandBorder.size.x / 2.0f) + leftThumbBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftHandBorder.size.y / 2.0f + leftThumbBorder.size.y / 2.0f, 103f);
                leftIndexBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x + leftHandBorder.size.x + leftIndexBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftHandBorder.size.y / 2.0f - leftIndexBorder.size.y / 2.0f, 103f);
                leftMiddleBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x + leftHandBorder.size.x + leftMiddleBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftHandBorder.size.y / 2.0f - leftIndexBorder.size.y - leftMiddleBorder.size.y / 2.0f, 103f);
                leftRingBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x + leftHandBorder.size.x + leftRingBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftHandBorder.size.y / 2.0f - leftIndexBorder.size.y - leftMiddleBorder.size.y - leftRingBorder.size.y / 2.0f, 103f);
                leftPinkyBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x + leftHandBorder.size.x + leftPinkyBorder.size.x / 2.0f, leftHandBorder.transform.position.y + leftHandBorder.size.y / 2.0f - leftIndexBorder.size.y - leftMiddleBorder.size.y - leftRingBorder.size.y - leftPinkyBorder.size.y / 2.0f, 103f);
                rightArmBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x / 2.0f, rightArmOffset, 103);
                rightHandBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x - rightHandBorder.size.x / 2.0f, rightHandOffset, 103f);
                rightThumbBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x - Mathf.Floor(rightHandBorder.size.x / 2.0f) - rightThumbBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightHandBorder.size.y / 2.0f + rightThumbBorder.size.y / 2.0f, 103f);
                rightIndexBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x - rightHandBorder.size.x - rightIndexBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightHandBorder.size.y / 2.0f - rightIndexBorder.size.y / 2.0f, 103f);
                rightMiddleBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x - rightHandBorder.size.x - rightMiddleBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightHandBorder.size.y / 2.0f - rightIndexBorder.size.y - rightMiddleBorder.size.y / 2.0f, 103f);
                rightRingBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x - rightHandBorder.size.x - rightRingBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightHandBorder.size.y / 2.0f - rightIndexBorder.size.y - rightMiddleBorder.size.y - rightRingBorder.size.y / 2.0f, 103f);
                rightPinkyBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x - rightHandBorder.size.x - rightPinkyBorder.size.x / 2.0f, rightHandBorder.transform.position.y + rightHandBorder.size.y / 2.0f - rightIndexBorder.size.y - rightMiddleBorder.size.y - rightRingBorder.size.y - rightPinkyBorder.size.y / 2.0f, 103f);
                leftLegBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftLegBorder.size.x / 2.0f, leftLegOffset, 102.9f);
                leftFootBorder.gameObject.transform.position = new Vector3(leftLegBorder.transform.position.x + leftFootOffset, Mathf.Ceil(leftFootBorder.size.y / 2.0f) - Mathf.Floor(leftLegBorder.size.y / 2.0f) - leftFootOffsetY, 102.8f);
                rightLegBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) + rightLegBorder.size.x / 2.0f, rightLegOffset, 102.9f);
                rightFootBorder.gameObject.transform.position = new Vector3(rightLegBorder.transform.position.x - rightFootOffset, Mathf.Ceil(rightFootBorder.size.y / 2.0f) - Mathf.Floor(rightLegBorder.size.y / 2.0f) - rightFootOffsetY, 102.8f);

                if (characterSettings.headSize.z % 2 != 0) bottomGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(1, 0, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().headTilemap.gameObject.transform.position = new Vector3(1, -1, transform.position.z);

                if (characterSettings.torsoSize.z % 2 != 0) bottomGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(1, 0, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().torsoTilemap.gameObject.transform.position = new Vector3(1, -1, transform.position.z);

                if (characterSettings.leftArmSize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f), 0, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().leftArmTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f), -1, transform.position.z);

                if (characterSettings.leftHandSize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().leftHandTilemap.gameObject.transform.position = new Vector3(leftHandBorder.transform.position.x - leftHandBorder.size.x / 2.0f, leftHandBorder.transform.position.y - 0.5f, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().leftHandTilemap.gameObject.transform.position = new Vector3(leftHandBorder.transform.position.x - leftHandBorder.size.x / 2.0f, leftHandBorder.transform.position.y - 1, transform.position.z);

                if (characterSettings.leftThumbSize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().leftThumbTilemap.gameObject.transform.position = new Vector3(leftThumbBorder.transform.position.x - leftThumbBorder.size.x / 2.0f, leftThumbBorder.transform.position.y - 0.5f, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().leftThumbTilemap.gameObject.transform.position = new Vector3(leftThumbBorder.transform.position.x - leftThumbBorder.size.x / 2.0f, leftThumbBorder.transform.position.y - 1, transform.position.z);

                if (characterSettings.leftIndexSize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().leftIndexTilemap.gameObject.transform.position = new Vector3(leftIndexBorder.transform.position.x - leftIndexBorder.size.x / 2.0f, leftIndexBorder.transform.position.y - 0.5f, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().leftIndexTilemap.gameObject.transform.position = new Vector3(leftIndexBorder.transform.position.x - leftIndexBorder.size.x / 2.0f, leftIndexBorder.transform.position.y - 1, transform.position.z);

                if (characterSettings.leftMiddleSize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().leftMiddleTilemap.gameObject.transform.position = new Vector3(leftMiddleBorder.transform.position.x - leftMiddleBorder.size.x / 2.0f, leftMiddleBorder.transform.position.y - 0.5f, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().leftMiddleTilemap.gameObject.transform.position = new Vector3(leftMiddleBorder.transform.position.x - leftMiddleBorder.size.x / 2.0f, leftMiddleBorder.transform.position.y - 1, transform.position.z);

                if (characterSettings.leftRingSize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().leftRingTilemap.gameObject.transform.position = new Vector3(leftRingBorder.transform.position.x - leftRingBorder.size.x / 2.0f, leftRingBorder.transform.position.y - 0.5f, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().leftRingTilemap.gameObject.transform.position = new Vector3(leftRingBorder.transform.position.x - leftRingBorder.size.x / 2.0f, leftRingBorder.transform.position.y - 1, transform.position.z);

                if (characterSettings.leftPinkySize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().leftPinkyTilemap.gameObject.transform.position = new Vector3(leftPinkyBorder.transform.position.x - leftPinkyBorder.size.x / 2.0f, leftPinkyBorder.transform.position.y - 0.5f, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().leftPinkyTilemap.gameObject.transform.position = new Vector3(leftPinkyBorder.transform.position.x - leftPinkyBorder.size.x / 2.0f, leftPinkyBorder.transform.position.y - 1, transform.position.z);

                bottomGrid.GetComponent<DrawGrid>().rightArmTilemap.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f), 1, transform.position.z);

                if (characterSettings.rightHandSize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().rightHandTilemap.gameObject.transform.position = new Vector3(rightHandBorder.transform.position.x + rightHandBorder.size.x / 2.0f, rightHandBorder.transform.position.y + 0.5f, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().rightHandTilemap.gameObject.transform.position = new Vector3(rightHandBorder.transform.position.x + rightHandBorder.size.x / 2.0f, rightHandBorder.transform.position.y + 1, transform.position.z);

                if (characterSettings.rightThumbSize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().rightThumbTilemap.gameObject.transform.position = new Vector3(rightThumbBorder.transform.position.x + rightThumbBorder.size.x / 2.0f, rightThumbBorder.transform.position.y + 0.5f, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().rightThumbTilemap.gameObject.transform.position = new Vector3(rightThumbBorder.transform.position.x + rightThumbBorder.size.x / 2.0f, rightThumbBorder.transform.position.y + 1, transform.position.z);

                if (characterSettings.rightIndexSize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().rightIndexTilemap.gameObject.transform.position = new Vector3(rightIndexBorder.transform.position.x + rightIndexBorder.size.x / 2.0f, rightIndexBorder.transform.position.y + 0.5f, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().rightIndexTilemap.gameObject.transform.position = new Vector3(rightIndexBorder.transform.position.x + rightIndexBorder.size.x / 2.0f, rightIndexBorder.transform.position.y + 1, transform.position.z);

                if (characterSettings.rightMiddleSize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().rightMiddleTilemap.gameObject.transform.position = new Vector3(rightMiddleBorder.transform.position.x + rightMiddleBorder.size.x / 2.0f, rightMiddleBorder.transform.position.y + 0.5f, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().rightMiddleTilemap.gameObject.transform.position = new Vector3(rightMiddleBorder.transform.position.x + rightMiddleBorder.size.x / 2.0f, rightMiddleBorder.transform.position.y + 1, transform.position.z);

                if (characterSettings.rightRingSize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().rightRingTilemap.gameObject.transform.position = new Vector3(rightRingBorder.transform.position.x + rightRingBorder.size.x / 2.0f, rightRingBorder.transform.position.y + 0.5f, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().rightRingTilemap.gameObject.transform.position = new Vector3(rightRingBorder.transform.position.x + rightRingBorder.size.x / 2.0f, rightRingBorder.transform.position.y + 1, transform.position.z);

                if (characterSettings.rightPinkySize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().rightPinkyTilemap.gameObject.transform.position = new Vector3(rightPinkyBorder.transform.position.x + rightPinkyBorder.size.x / 2.0f, rightPinkyBorder.transform.position.y + 0.5f, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().rightPinkyTilemap.gameObject.transform.position = new Vector3(rightPinkyBorder.transform.position.x + rightPinkyBorder.size.x / 2.0f, rightPinkyBorder.transform.position.y + 1, transform.position.z);

                if (characterSettings.leftLegSize.z % 2 != 0) leftLegOffset = 0;
                else leftLegOffset = -1;
                if (characterSettings.leftLegSize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftLegBorder.size.x / 2.0f - 0.5f, leftLegOffset, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().leftLegTilemap.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftLegBorder.size.x / 2.0f - 1, leftLegOffset, transform.position.z);

                if (characterSettings.leftFootSize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().leftFootTilemap.gameObject.transform.position = new Vector3(leftFootBorder.transform.position.x - 0.5f, leftFootBorder.transform.position.y - leftFootBorder.size.y / 2.0f, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().leftFootTilemap.gameObject.transform.position = new Vector3(leftFootBorder.transform.position.x - 1, leftFootBorder.transform.position.y - leftFootBorder.size.y / 2.0f, transform.position.z);

                if (characterSettings.rightLegSize.z % 2 != 0) rightLegOffset = 0;
                else rightLegOffset = -1;
                if (characterSettings.rightLegSize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) + rightLegBorder.size.x / 2.0f - 0.5f, rightLegOffset, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().rightLegTilemap.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) + rightLegBorder.size.x / 2.0f - 1, rightLegOffset, transform.position.z);

                if (characterSettings.rightFootSize.x % 2 != 0) bottomGrid.GetComponent<DrawGrid>().rightFootTilemap.gameObject.transform.position = new Vector3(rightFootBorder.transform.position.x - 0.5f, rightFootBorder.transform.position.y - rightFootBorder.size.y / 2.0f, transform.position.z);
                else bottomGrid.GetComponent<DrawGrid>().rightFootTilemap.gameObject.transform.position = new Vector3(rightFootBorder.transform.position.x - 1, rightFootBorder.transform.position.y - rightFootBorder.size.y / 2.0f, transform.position.z);

                //bottomGrid.GetComponent<DrawGrid>().CleanAllTilemaps();
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

    /// <summary>
    /// Displays a list of the empty tilemaps
    /// </summary>
    public void DisplayWarningText(bool mouseOver)
    {
        if (mouseOver)
        {
            warningText.SetActive(true);
            TMP_Text text = warningText.transform.GetChild(0).GetComponent<TMP_Text>();
            text.text = "Some body parts in this view are empty!";

            // Add each empty tilemap to the text list
            switch (currentView)
            {
                case GridViews.Front:
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().headTilemap) == 0) text.text += "\n- Head";
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().torsoTilemap) == 0) text.text += "\n- Torso";
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().leftArmTilemap) == 0) text.text += "\n- Left Arm";
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().leftHandTilemap) == 0) text.text += "\n- Left Hand";
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().leftThumbTilemap) == 0) text.text += "\n- Left Thumb";
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().leftIndexTilemap) == 0) text.text += "\n- Left Index Finger";
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().leftMiddleTilemap) == 0) text.text += "\n- Left Middle Finger";
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().leftRingTilemap) == 0) text.text += "\n- Left Ring Finger";
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().leftPinkyTilemap) == 0) text.text += "\n- Left Pinky";
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().rightArmTilemap) == 0) text.text += "\n- Right Arm";
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().rightHandTilemap) == 0) text.text += "\n- Right Hand";
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().rightThumbTilemap) == 0) text.text += "\n- Right Thumb";
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().rightIndexTilemap) == 0) text.text += "\n- Right Index Finger";
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().rightMiddleTilemap) == 0) text.text += "\n- Right Middle Finger";
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().rightRingTilemap) == 0) text.text += "\n- Right Ring Finger";
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().rightPinkyTilemap) == 0) text.text += "\n- Right Pinky";
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().leftLegTilemap) == 0) text.text += "\n- Left Leg";
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().leftFootTilemap) == 0) text.text += "\n- Left Foot";
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().rightLegTilemap) == 0) text.text += "\n- Right Leg";
                    if (GetNumberOfTiles(frontGrid.GetComponent<DrawGrid>().rightFootTilemap) == 0) text.text += "\n- Right Foot";
                    break;
                case GridViews.Back:
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().headTilemap) == 0) text.text += "\n- Head";
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().torsoTilemap) == 0) text.text += "\n- Torso";
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().leftArmTilemap) == 0) text.text += "\n- Left Arm";
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().leftHandTilemap) == 0) text.text += "\n- Left Hand";
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().leftThumbTilemap) == 0) text.text += "\n- Left Thumb";
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().leftIndexTilemap) == 0) text.text += "\n- Left Index Finger";
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().leftMiddleTilemap) == 0) text.text += "\n- Left Middle Finger";
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().leftRingTilemap) == 0) text.text += "\n- Left Ring Finger";
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().leftPinkyTilemap) == 0) text.text += "\n- Left Pinky";
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().rightArmTilemap) == 0) text.text += "\n- Right Arm";
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().rightHandTilemap) == 0) text.text += "\n- Right Hand";
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().rightThumbTilemap) == 0) text.text += "\n- Right Thumb";
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().rightIndexTilemap) == 0) text.text += "\n- Right Index Finger";
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().rightMiddleTilemap) == 0) text.text += "\n- Right Middle Finger";
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().rightRingTilemap) == 0) text.text += "\n- Right Ring Finger";
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().rightPinkyTilemap) == 0) text.text += "\n- Right Pinky";
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().leftLegTilemap) == 0) text.text += "\n- Left Leg";
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().leftFootTilemap) == 0) text.text += "\n- Left Foot";
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().rightLegTilemap) == 0) text.text += "\n- Right Leg";
                    if (GetNumberOfTiles(backGrid.GetComponent<DrawGrid>().rightFootTilemap) == 0) text.text += "\n- Right Foot";
                    break;
                case GridViews.Left:
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().headTilemap) == 0) text.text += "\n- Head";
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().torsoTilemap) == 0) text.text += "\n- Torso";
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().leftArmTilemap) == 0) text.text += "\n- Left Arm";
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().leftHandTilemap) == 0) text.text += "\n- Left Hand";
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().leftThumbTilemap) == 0) text.text += "\n- Left Thumb";
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().leftIndexTilemap) == 0) text.text += "\n- Left Index Finger";
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().leftMiddleTilemap) == 0) text.text += "\n- Left Middle Finger";
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().leftRingTilemap) == 0) text.text += "\n- Left Ring Finger";
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().leftPinkyTilemap) == 0) text.text += "\n- Left Pinky";
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().rightArmTilemap) == 0) text.text += "\n- Right Arm";
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().rightHandTilemap) == 0) text.text += "\n- Right Hand";
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().rightThumbTilemap) == 0) text.text += "\n- Right Thumb";
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().rightIndexTilemap) == 0) text.text += "\n- Right Index Finger";
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().rightMiddleTilemap) == 0) text.text += "\n- Right Middle Finger";
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().rightRingTilemap) == 0) text.text += "\n- Right Ring Finger";
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().rightPinkyTilemap) == 0) text.text += "\n- Right Pinky";
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().leftLegTilemap) == 0) text.text += "\n- Left Leg";
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().leftFootTilemap) == 0) text.text += "\n- Left Foot";
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().rightLegTilemap) == 0) text.text += "\n- Right Leg";
                    if (GetNumberOfTiles(leftGrid.GetComponent<DrawGrid>().rightFootTilemap) == 0) text.text += "\n- Right Foot";
                    break;
                case GridViews.Right:
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().headTilemap) == 0) text.text += "\n- Head";
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().torsoTilemap) == 0) text.text += "\n- Torso";
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().leftArmTilemap) == 0) text.text += "\n- Left Arm";
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().leftHandTilemap) == 0) text.text += "\n- Left Hand";
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().leftThumbTilemap) == 0) text.text += "\n- Left Thumb";
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().leftIndexTilemap) == 0) text.text += "\n- Left Index Finger";
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().leftMiddleTilemap) == 0) text.text += "\n- Left Middle Finger";
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().leftRingTilemap) == 0) text.text += "\n- Left Ring Finger";
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().leftPinkyTilemap) == 0) text.text += "\n- Left Pinky";
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().rightArmTilemap) == 0) text.text += "\n- Right Arm";
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().rightHandTilemap) == 0) text.text += "\n- Right Hand";
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().rightThumbTilemap) == 0) text.text += "\n- Right Thumb";
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().rightIndexTilemap) == 0) text.text += "\n- Right Index Finger";
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().rightMiddleTilemap) == 0) text.text += "\n- Right Middle Finger";
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().rightRingTilemap) == 0) text.text += "\n- Right Ring Finger";
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().rightPinkyTilemap) == 0) text.text += "\n- Right Pinky";
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().leftLegTilemap) == 0) text.text += "\n- Left Leg";
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().leftFootTilemap) == 0) text.text += "\n- Left Foot";
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().rightLegTilemap) == 0) text.text += "\n- Right Leg";
                    if (GetNumberOfTiles(rightGrid.GetComponent<DrawGrid>().rightFootTilemap) == 0) text.text += "\n- Right Foot";
                    break;
                case GridViews.Top:
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().headTilemap) == 0) text.text += "\n- Head";
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().torsoTilemap) == 0) text.text += "\n- Torso";
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().leftArmTilemap) == 0) text.text += "\n- Left Arm";
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().leftHandTilemap) == 0) text.text += "\n- Left Hand";
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().leftThumbTilemap) == 0) text.text += "\n- Left Thumb";
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().leftIndexTilemap) == 0) text.text += "\n- Left Index Finger";
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().leftMiddleTilemap) == 0) text.text += "\n- Left Middle Finger";
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().leftRingTilemap) == 0) text.text += "\n- Left Ring Finger";
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().leftPinkyTilemap) == 0) text.text += "\n- Left Pinky";
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().rightArmTilemap) == 0) text.text += "\n- Right Arm";
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().rightHandTilemap) == 0) text.text += "\n- Right Hand";
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().rightThumbTilemap) == 0) text.text += "\n- Right Thumb";
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().rightIndexTilemap) == 0) text.text += "\n- Right Index Finger";
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().rightMiddleTilemap) == 0) text.text += "\n- Right Middle Finger";
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().rightRingTilemap) == 0) text.text += "\n- Right Ring Finger";
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().rightPinkyTilemap) == 0) text.text += "\n- Right Pinky";
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().leftLegTilemap) == 0) text.text += "\n- Left Leg";
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().leftFootTilemap) == 0) text.text += "\n- Left Foot";
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().rightLegTilemap) == 0) text.text += "\n- Right Leg";
                    if (GetNumberOfTiles(topGrid.GetComponent<DrawGrid>().rightFootTilemap) == 0) text.text += "\n- Right Foot";
                    break;
                case GridViews.Bottom:
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().headTilemap) == 0) text.text += "\n- Head";
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().torsoTilemap) == 0) text.text += "\n- Torso";
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().leftArmTilemap) == 0) text.text += "\n- Left Arm";
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().leftHandTilemap) == 0) text.text += "\n- Left Hand";
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().leftThumbTilemap) == 0) text.text += "\n- Left Thumb";
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().leftIndexTilemap) == 0) text.text += "\n- Left Index Finger";
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().leftMiddleTilemap) == 0) text.text += "\n- Left Middle Finger";
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().leftRingTilemap) == 0) text.text += "\n- Left Ring Finger";
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().leftPinkyTilemap) == 0) text.text += "\n- Left Pinky";
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().rightArmTilemap) == 0) text.text += "\n- Right Arm";
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().rightHandTilemap) == 0) text.text += "\n- Right Hand";
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().rightThumbTilemap) == 0) text.text += "\n- Right Thumb";
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().rightIndexTilemap) == 0) text.text += "\n- Right Index Finger";
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().rightMiddleTilemap) == 0) text.text += "\n- Right Middle Finger";
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().rightRingTilemap) == 0) text.text += "\n- Right Ring Finger";
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().rightPinkyTilemap) == 0) text.text += "\n- Right Pinky";
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().leftLegTilemap) == 0) text.text += "\n- Left Leg";
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().leftFootTilemap) == 0) text.text += "\n- Left Foot";
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().rightLegTilemap) == 0) text.text += "\n- Right Leg";
                    if (GetNumberOfTiles(bottomGrid.GetComponent<DrawGrid>().rightFootTilemap) == 0) text.text += "\n- Right Foot";
                    break;
            }
        }
        else
        {
            warningText.SetActive(false);
        }
    }

    public static int GetNumberOfTiles(Tilemap tilemap)
    {
        tilemap.CompressBounds();
        TileBase[] tiles = tilemap.GetTilesBlock(tilemap.cellBounds);
        return tiles.Where(x => x != null).ToArray().Length;
    }

    /// <summary>
    /// Erases tiles outside of the borders
    /// </summary>
    public void CleanTilemap(ref Tilemap tilemap, Vector3Int bodyPartSize)
    {
        tilemap.CompressBounds();

        BoundsInt bounds = tilemap.cellBounds;

        for (int x = bounds.min.x; x < bounds.max.x; x++)
        {
            for (int y = bounds.min.y; y < bounds.max.y; y++)
            {
                for (int z = bounds.min.z; z < bounds.max.z; z++)
                {
                    TileBase tile = tilemap.GetTile(new Vector3Int(x, y, z));
                    if (tile != null)
                    {
                        if (x > Mathf.Floor(bodyPartSize.x / 2.0f) || x < -Mathf.Ceil(bodyPartSize.x / 2.0f - 1.0f) ||
                            y > bodyPartSize.y - 1 || y < 0 ||
                            z > Mathf.Floor(bodyPartSize.z / 2.0f) || z < -Mathf.Ceil(bodyPartSize.z / 2.0f - 1.0f))
                        {
                            tilemap.SetTile(new Vector3Int(x, y, z), null);
                        }
                    }
                }
            }
        }
    }
}
