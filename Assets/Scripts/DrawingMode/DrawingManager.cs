using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
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

    // Grid Tiles
    [HideInInspector] public List<Vector3Int> headGridTiles;
    [HideInInspector] public List<Vector3Int> torsoGridTiles;
    [HideInInspector] public List<Vector3Int> leftArmGridTiles;
    [HideInInspector] public List<Vector3Int> rightArmGridTiles;
    [HideInInspector] public List<Vector3Int> leftLegGridTiles;
    [HideInInspector] public List<Vector3Int> rightLegGridTiles;

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
        headGridTiles = new List<Vector3Int>();
        torsoGridTiles = new List<Vector3Int>();
        leftArmGridTiles = new List<Vector3Int>();
        rightArmGridTiles = new List<Vector3Int>();
        leftLegGridTiles = new List<Vector3Int>();
        rightLegGridTiles = new List<Vector3Int>();
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
        ChangeBorderSizes();
        AssignGridToBodyParts();

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
        AssignGridToBodyParts();
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
        characterSettings.rightArmSize.x = int.Parse(rightArmX.text);
        characterSettings.rightArmSize.y = int.Parse(rightArmY.text);
        characterSettings.rightArmSize.z = int.Parse(rightArmZ.text);
        characterSettings.leftLegSize.x = int.Parse(leftLegX.text);
        characterSettings.leftLegSize.y = int.Parse(leftLegY.text);
        characterSettings.leftLegSize.z = int.Parse(leftLegZ.text);
        characterSettings.rightLegSize.x = int.Parse(rightLegX.text);
        characterSettings.rightLegSize.y = int.Parse(rightLegY.text);
        characterSettings.rightLegSize.z = int.Parse(rightLegZ.text);
        ChangeBorderSizes();
        AssignGridToBodyParts();
    }

    public void ChangeBorderSizes()
    {
        float positionX = 0;
        float positionY = 0;
        float headPositionX = 0;
        float headPositionZ = 0;
        float leftArmPositionX = 0;
        float leftArmPositionZ = 0;
        float rightArmPositionX = 0;
        float rightArmPositionZ = 0;
        float leftLegPositionX = 0;
        float leftLegPositionZ = 0;
        float rightLegPositionX = 0;
        float rightLegPositionZ = 0;
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
                leftArmBorder.size = new Vector2(characterSettings.leftArmSize.y, characterSettings.leftArmSize.x);
                rightArmBorder.size = new Vector2(characterSettings.rightArmSize.y, characterSettings.rightArmSize.x);
                leftLegBorder.size = new Vector2(characterSettings.leftLegSize.x, characterSettings.leftLegSize.y);
                rightLegBorder.size = new Vector2(characterSettings.rightLegSize.x, characterSettings.rightLegSize.y);

                if (characterSettings.headSize.x % 2 != 0) // Odd
                {
                    headPositionX = 0.5f;
                }
                headBorder.gameObject.transform.position = new Vector3(headPositionX, Mathf.Ceil(torsoBorder.size.y / 2.0f) + headBorder.size.y / 2.0f, headBorder.gameObject.transform.position.z);
                leftArmBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x / 2.0f, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f, leftArmBorder.gameObject.transform.position.z);
                rightArmBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x / 2.0f, Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f, rightArmBorder.gameObject.transform.position.z);
                leftLegBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftLegBorder.size.x / 2.0f, -Mathf.Floor(torsoBorder.size.y / 2.0f) - leftLegBorder.size.y / 2.0f, leftLegBorder.gameObject.transform.position.z);
                rightLegBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) + rightLegBorder.size.x / 2.0f, -Mathf.Floor(torsoBorder.size.y / 2.0f) - rightLegBorder.size.y / 2.0f, rightLegBorder.gameObject.transform.position.z);

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
                leftArmBorder.size = new Vector2(characterSettings.leftArmSize.y, characterSettings.leftArmSize.x);
                rightArmBorder.size = new Vector2(characterSettings.rightArmSize.y, characterSettings.rightArmSize.x);
                leftLegBorder.size = new Vector2(characterSettings.leftLegSize.x, characterSettings.leftLegSize.y);
                rightLegBorder.size = new Vector2(characterSettings.rightLegSize.x, characterSettings.rightLegSize.y);

                if (characterSettings.headSize.x % 2 != 0) // Odd
                {
                    headPositionX = -0.5f;
                }
                headBorder.gameObject.transform.position = new Vector3(headPositionX, Mathf.Ceil(torsoBorder.size.y / 2.0f) + headBorder.size.y / 2.0f, headBorder.gameObject.transform.position.z);
                leftArmBorder.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftArmBorder.size.x / 2.0f, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f, leftArmBorder.gameObject.transform.position.z);
                rightArmBorder.gameObject.transform.position = new Vector3(Mathf.Floor(torsoBorder.size.x / 2.0f) + rightArmBorder.size.x / 2.0f, Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f, rightArmBorder.gameObject.transform.position.z);
                leftLegBorder.gameObject.transform.position = new Vector3(-Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftLegBorder.size.x / 2.0f, -Mathf.Floor(torsoBorder.size.y / 2.0f) - leftLegBorder.size.y / 2.0f, leftLegBorder.gameObject.transform.position.z);
                rightLegBorder.gameObject.transform.position = new Vector3(Mathf.Floor(torsoBorder.size.x / 2.0f) - rightLegBorder.size.x / 2.0f, -Mathf.Floor(torsoBorder.size.y / 2.0f) - rightLegBorder.size.y / 2.0f, rightLegBorder.gameObject.transform.position.z);

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
                leftArmBorder.size = new Vector2(characterSettings.leftArmSize.z, characterSettings.leftArmSize.x);
                rightArmBorder.size = new Vector2(characterSettings.rightArmSize.z, characterSettings.rightArmSize.x);
                leftLegBorder.size = new Vector2(characterSettings.leftLegSize.z, characterSettings.leftLegSize.y);
                rightLegBorder.size = new Vector2(characterSettings.rightLegSize.z, characterSettings.rightLegSize.y);

                if (characterSettings.headSize.z % 2 != 0) // Odd
                {
                    headPositionX = -0.5f;
                }
                if (characterSettings.leftArmSize.z % 2 != 0) // Odd
                {
                    leftArmPositionX = -0.5f;
                }
                if (characterSettings.rightArmSize.z % 2 != 0) // Odd
                {
                    rightArmPositionX = -0.5f;
                }
                if (characterSettings.leftLegSize.z % 2 != 0) // Odd
                {
                    leftLegPositionX = -0.5f;
                }
                if (characterSettings.rightLegSize.z % 2 != 0) // Odd
                {
                    rightLegPositionX = -0.5f;
                }
                headBorder.gameObject.transform.position = new Vector3(headPositionX, Mathf.Ceil(torsoBorder.size.y / 2.0f) + headBorder.size.y / 2.0f, headBorder.gameObject.transform.position.z);
                leftArmBorder.gameObject.transform.position = new Vector3(leftArmPositionX, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f, leftArmBorder.gameObject.transform.position.z);
                rightArmBorder.gameObject.transform.position = new Vector3(rightArmPositionX, Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f, rightArmBorder.gameObject.transform.position.z);
                leftLegBorder.gameObject.transform.position = new Vector3(leftLegPositionX, -Mathf.Floor(torsoBorder.size.y / 2.0f) - leftLegBorder.size.y / 2.0f, leftLegBorder.gameObject.transform.position.z);
                rightLegBorder.gameObject.transform.position = new Vector3(rightLegPositionX, -Mathf.Floor(torsoBorder.size.y / 2.0f) - rightLegBorder.size.y / 2.0f, rightLegBorder.gameObject.transform.position.z);
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
                leftArmBorder.size = new Vector2(characterSettings.leftArmSize.z, characterSettings.leftArmSize.x);
                rightArmBorder.size = new Vector2(characterSettings.rightArmSize.z, characterSettings.rightArmSize.x);
                leftLegBorder.size = new Vector2(characterSettings.leftLegSize.z, characterSettings.leftLegSize.y);
                rightLegBorder.size = new Vector2(characterSettings.rightLegSize.z, characterSettings.rightLegSize.y);

                if (characterSettings.headSize.z % 2 != 0) // Odd
                {
                    headPositionX = 0.5f;
                }
                if (characterSettings.leftArmSize.z % 2 != 0) // Odd
                {
                    leftArmPositionX = 0.5f;
                }
                if (characterSettings.rightArmSize.z % 2 != 0) // Odd
                {
                    rightArmPositionX = 0.5f;
                }
                if (characterSettings.leftLegSize.z % 2 != 0) // Odd
                {
                    leftLegPositionX = 0.5f;
                }
                if (characterSettings.rightLegSize.z % 2 != 0) // Odd
                {
                    rightLegPositionX = 0.5f;
                }
                headBorder.gameObject.transform.position = new Vector3(headPositionX, Mathf.Ceil(torsoBorder.size.y / 2.0f) + headBorder.size.y / 2.0f, headBorder.gameObject.transform.position.z);
                leftArmBorder.gameObject.transform.position = new Vector3(leftArmPositionX, Mathf.Ceil(torsoBorder.size.y / 2.0f) - leftArmBorder.size.y / 2.0f, leftArmBorder.gameObject.transform.position.z);
                rightArmBorder.gameObject.transform.position = new Vector3(rightArmPositionX, Mathf.Ceil(torsoBorder.size.y / 2.0f) - rightArmBorder.size.y / 2.0f, rightArmBorder.gameObject.transform.position.z);
                leftLegBorder.gameObject.transform.position = new Vector3(leftLegPositionX, -Mathf.Floor(torsoBorder.size.y / 2.0f) - leftLegBorder.size.y / 2.0f, leftLegBorder.gameObject.transform.position.z);
                rightLegBorder.gameObject.transform.position = new Vector3(rightLegPositionX, -Mathf.Floor(torsoBorder.size.y / 2.0f) - rightLegBorder.size.y / 2.0f, rightLegBorder.gameObject.transform.position.z);
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
                leftArmBorder.size = new Vector2(characterSettings.leftArmSize.y, characterSettings.leftArmSize.z);
                rightArmBorder.size = new Vector2(characterSettings.rightArmSize.y, characterSettings.rightArmSize.z);
                leftLegBorder.size = new Vector2(characterSettings.leftLegSize.x, characterSettings.leftLegSize.z);
                rightLegBorder.size = new Vector2(characterSettings.rightLegSize.x, characterSettings.rightLegSize.z);

                if (characterSettings.headSize.x % 2 != 0) // Odd
                {
                    headPositionX = 0.5f;
                }
                if (characterSettings.headSize.z % 2 != 0) // Odd
                {
                    headPositionZ = -0.5f;
                }
                if (characterSettings.leftArmSize.z % 2 != 0) // Odd
                {
                    leftArmPositionZ = -0.5f;
                }
                if (characterSettings.rightArmSize.z % 2 != 0) // Odd
                {
                    rightArmPositionZ = -0.5f;
                }
                if (characterSettings.leftLegSize.z % 2 != 0) // Odd
                {
                    leftLegPositionZ = -0.5f;
                }
                if (characterSettings.rightLegSize.z % 2 != 0) // Odd
                {
                    rightLegPositionZ = -0.5f;
                }
                headBorder.gameObject.transform.position = new Vector3(headPositionX, headPositionZ, headBorder.gameObject.transform.position.z);
                leftArmBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x / 2.0f, leftArmPositionZ, leftArmBorder.gameObject.transform.position.z);
                rightArmBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x / 2.0f, rightArmPositionZ, rightArmBorder.gameObject.transform.position.z);
                leftLegBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftLegBorder.size.x / 2.0f, leftLegPositionZ, leftLegBorder.gameObject.transform.position.z);
                rightLegBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) + rightLegBorder.size.x / 2.0f, rightLegPositionZ, rightLegBorder.gameObject.transform.position.z);
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
                leftArmBorder.size = new Vector2(characterSettings.leftArmSize.y, characterSettings.leftArmSize.z);
                rightArmBorder.size = new Vector2(characterSettings.rightArmSize.y, characterSettings.rightArmSize.z);
                leftLegBorder.size = new Vector2(characterSettings.leftLegSize.x, characterSettings.leftLegSize.z);
                rightLegBorder.size = new Vector2(characterSettings.rightLegSize.x, characterSettings.rightLegSize.z);

                if (characterSettings.headSize.x % 2 != 0) // Odd
                {
                    headPositionX = 0.5f;
                }
                if (characterSettings.headSize.z % 2 != 0) // Odd
                {
                    headPositionZ = 0.5f;
                }
                if (characterSettings.leftArmSize.z % 2 != 0) // Odd
                {
                    leftArmPositionZ = 0.5f;
                }
                if (characterSettings.rightArmSize.z % 2 != 0) // Odd
                {
                    rightArmPositionZ = 0.5f;
                }
                if (characterSettings.leftLegSize.z % 2 != 0) // Odd
                {
                    leftLegPositionZ = 0.5f;
                }
                if (characterSettings.rightLegSize.z % 2 != 0) // Odd
                {
                    rightLegPositionZ = 0.5f;
                }
                headBorder.gameObject.transform.position = new Vector3(headPositionX, headPositionZ, headBorder.gameObject.transform.position.z);
                leftArmBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) + leftArmBorder.size.x / 2.0f, leftArmPositionZ, leftArmBorder.gameObject.transform.position.z);
                rightArmBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) - rightArmBorder.size.x / 2.0f, rightArmPositionZ, rightArmBorder.gameObject.transform.position.z);
                leftLegBorder.gameObject.transform.position = new Vector3(Mathf.Ceil(torsoBorder.size.x / 2.0f) - leftLegBorder.size.x / 2.0f, leftLegPositionZ, leftLegBorder.gameObject.transform.position.z);
                rightLegBorder.gameObject.transform.position = new Vector3(-Mathf.Floor(torsoBorder.size.x / 2.0f) + rightLegBorder.size.x / 2.0f, rightLegPositionZ, rightLegBorder.gameObject.transform.position.z);
                break;
        }
        headBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        torsoBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        leftArmBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        rightArmBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        leftLegBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
        rightLegBorder.gameObject.GetComponent<DrawBorder>().ChangeColliderSize();
    }

    public void AssignGridToBodyParts()
    {
        // Create copies of each of the tile coordinate lists
        List<Vector3Int> prevHeadGridTiles = new List<Vector3Int>(headGridTiles);
        List<Vector3Int> prevTorsoGridTiles = new List<Vector3Int>(torsoGridTiles);
        List<Vector3Int> prevLeftArmGridTiles = new List<Vector3Int>(leftArmGridTiles);
        List<Vector3Int> prevRightArmGridTiles = new List<Vector3Int>(rightArmGridTiles);
        List<Vector3Int> prevLeftLegGridTiles = new List<Vector3Int>(leftLegGridTiles);
        List<Vector3Int> prevRightLegGridTiles = new List<Vector3Int>(rightLegGridTiles);
        
        // Clear the original lists to refill them again
        headGridTiles.Clear();
        torsoGridTiles.Clear();
        leftArmGridTiles.Clear();
        rightArmGridTiles.Clear();
        leftLegGridTiles.Clear();
        rightLegGridTiles.Clear();
        
        //Vector3Int centerPoint = frontGrid.GetComponent<DrawGrid>().tilemap.WorldToCell(torsoBorder.transform.position);
        int leftmostPoint = 0;
        int bottomPoint = 0;
        switch (currentView)
        {
            case GridViews.Front:
                // TORSO -----------------------------------------------------------------
                IdentifyGridSpots(frontGrid, torsoGridTiles, ref prevTorsoGridTiles, characterSettings.torsoSize, ref leftmostPoint, ref bottomPoint);
                /*if (characterSettings.torsoSize.x % 2 == 1) // Odd
                {
                    leftmostPoint = (characterSettings.torsoSize.x - 1) / 2;
                }
                else
                {
                    leftmostPoint = characterSettings.torsoSize.x / 2;
                }
                leftmostPoint *= -1;

                if (characterSettings.torsoSize.y % 2 == 1) // Odd
                {
                    bottomPoint = (characterSettings.torsoSize.y - 1) / 2;
                }
                else
                {
                    bottomPoint = characterSettings.torsoSize.y / 2;
                }
                bottomPoint *= -1;
                
                // Identify which tiles are in each body part
                for (int i = 0; i < characterSettings.torsoSize.x; i++)
                {
                    for (int j = 0; j < characterSettings.torsoSize.y; j++)
                    {
                        torsoGridTiles.Add(new Vector3Int(leftmostPoint + i, bottomPoint + j, 0));
                    }
                }

                // If the grid changed size and the tile is no longer in the grid, delete it
                foreach (Vector3Int tileCoordinate in prevTorsoGridTiles)
                {
                    if (!torsoGridTiles.Contains(tileCoordinate))
                    {
                        frontGrid.GetComponent<DrawGrid>().tilemap.SetTile(tileCoordinate, null);
                    }
                }*/

                // HEAD ------------------------------------------------------------------------------


                // LEFT ARM ------------------------------------------------------------------------


                // RIGHT ARM -----------------------------------------------------------------------


                // LEFT LEG --------------------------------------------------------------------------


                // RIGHT LEG -------------------------------------------------------------------------
                break;
            case GridViews.Back:
                
                break;
            case GridViews.Left:
                
                break;
            case GridViews.Right:
                
                break;
            case GridViews.Top:
                
                break;
            case GridViews.Bottom:
                
                break;
        }
    }

    private void IdentifyGridSpots(GameObject grid, List<Vector3Int> partGridTiles, ref List<Vector3Int> prevPartGridTiles, Vector3Int bodyPartSize, ref int leftmostPoint, ref int bottomPoint)
    {
        if (bodyPartSize.x % 2 == 1) // Odd
        {
            leftmostPoint = (bodyPartSize.x - 1) / 2;
        }
        else
        {
            leftmostPoint = bodyPartSize.x / 2;
        }
        leftmostPoint *= -1;

        if (bodyPartSize.y % 2 == 1) // Odd
        {
            bottomPoint = (bodyPartSize.y - 1) / 2;
        }
        else
        {
            bottomPoint = bodyPartSize.y / 2;
        }
        bottomPoint *= -1;

        // Identify which tiles are in each body part
        for (int i = 0; i < bodyPartSize.x; i++)
        {
            for (int j = 0; j < bodyPartSize.y; j++)
            {
                partGridTiles.Add(new Vector3Int(leftmostPoint + i, bottomPoint + j, 0));
            }
        }

        // If the grid changed size and the tile is no longer in the grid, delete it
        foreach (Vector3Int tileCoordinate in prevPartGridTiles)
        {
            if (!partGridTiles.Contains(tileCoordinate))
            {
                //grid.GetComponent<DrawGrid>().tilemap.SetTile(tileCoordinate, null);
            }
        }
    }
}
