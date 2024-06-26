using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class DrawGrid : MonoBehaviour
{
    private CharacterSettings characterSettings;
    [SerializeField] private DrawingManager drawingManager;
    public Tilemap headTilemap;
    public Tilemap torsoTilemap;
    public Tilemap leftArmTilemap;
    public Tilemap leftHandTilemap;
    public Tilemap leftThumbTilemap;
    public Tilemap leftIndexTilemap;
    public Tilemap leftMiddleTilemap;
    public Tilemap leftRingTilemap;
    public Tilemap leftPinkyTilemap;
    public Tilemap rightArmTilemap;
    public Tilemap rightHandTilemap;
    public Tilemap rightThumbTilemap;
    public Tilemap rightIndexTilemap;
    public Tilemap rightMiddleTilemap;
    public Tilemap rightRingTilemap;
    public Tilemap rightPinkyTilemap;
    public Tilemap leftLegTilemap;
    public Tilemap leftFootTilemap;
    public Tilemap rightLegTilemap;
    public Tilemap rightFootTilemap;
    [SerializeField] private Tile tile;

    private Vector3Int prevPosition;

    // Start is called before the first frame update
    void Start()
    {
        characterSettings = GameObject.FindGameObjectWithTag("CharacterSettings").GetComponent<CharacterSettings>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && drawingManager.mouseInDrawField && drawingManager.mouseInBorder)
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int position = drawingManager.currentTilemap.WorldToCell(worldPoint);

            if (position != prevPosition)
            {
                prevPosition = position;

                if (drawingManager.currentTilemap.gameObject.transform.right.z != 0)
                {
                    position = new Vector3Int(0, position.y, position.z);
                }
                else if (drawingManager.currentTilemap.gameObject.transform.up.z != 0)
                {
                    position = new Vector3Int(position.x, 0, position.z);
                }
                else if (drawingManager.currentTilemap.gameObject.transform.forward.z != 0)
                {
                    position = new Vector3Int(position.x, position.y, 0);
                }
                Debug.Log(drawingManager.currentTilemap.name + ", " + position);

                if (drawingManager.currentMode == DrawModes.Draw)
                {
                    // Set the tile for color creation.
                    drawingManager.currentTilemap.SetTile(position, tile);

                    // Flag the tile, inidicating that it can change color.
                    // By default it's set to "Lock Color".
                    drawingManager.currentTilemap.SetTileFlags(position, TileFlags.None);

                    // Set the color.
                    drawingManager.currentTilemap.SetColor(position, drawingManager.currentColor);

                    CheckForEmptyTilemaps();
                }
                else if (drawingManager.currentMode == DrawModes.Erase)
                {
                    // Erase the tile
                    drawingManager.currentTilemap.SetTile(position, null);
                    drawingManager.currentTilemap.CompressBounds();

                    CheckForEmptyTilemaps();
                }
                else if (drawingManager.currentMode == DrawModes.Fill && Input.GetMouseButtonDown(0))
                {
                    // Fill the highlighted part of the body
                    int minX = 0;
                    int maxX = 0;
                    int minY = 0;
                    int maxY = 0;
                    int minZ = 0;
                    int maxZ = 0;

                    if (drawingManager.currentTilemap == headTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.headSize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.headSize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.headSize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.headSize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.headSize.z / 2.0f);
                    }
                    else if (drawingManager.currentTilemap == torsoTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.torsoSize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.torsoSize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.torsoSize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.torsoSize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.torsoSize.z / 2.0f);
                    }
                    else if (drawingManager.currentTilemap == leftArmTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.leftArmSize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.leftArmSize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.leftArmSize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.leftArmSize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.leftArmSize.z / 2.0f);
                    }
                    else if (drawingManager.currentTilemap == leftHandTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.leftHandSize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.leftHandSize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.leftHandSize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.leftHandSize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.leftHandSize.z / 2.0f);
                    }
                    else if (drawingManager.currentTilemap == leftThumbTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.leftThumbSize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.leftThumbSize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.leftThumbSize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.leftThumbSize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.leftThumbSize.z / 2.0f);
                    }
                    else if (drawingManager.currentTilemap == leftIndexTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.leftIndexSize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.leftIndexSize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.leftIndexSize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.leftIndexSize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.leftIndexSize.z / 2.0f);
                    }
                    else if (drawingManager.currentTilemap == leftMiddleTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.leftMiddleSize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.leftMiddleSize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.leftMiddleSize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.leftMiddleSize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.leftMiddleSize.z / 2.0f);
                    }
                    else if (drawingManager.currentTilemap == leftRingTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.leftRingSize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.leftRingSize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.leftRingSize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.leftRingSize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.leftRingSize.z / 2.0f);
                    }
                    else if (drawingManager.currentTilemap == leftPinkyTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.leftPinkySize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.leftPinkySize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.leftPinkySize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.leftPinkySize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.leftPinkySize.z / 2.0f);
                    }
                    else if (drawingManager.currentTilemap == rightArmTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.rightArmSize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.rightArmSize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.rightArmSize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.rightArmSize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.rightArmSize.z / 2.0f);
                    }
                    else if (drawingManager.currentTilemap == rightHandTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.rightHandSize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.rightHandSize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.rightHandSize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.rightHandSize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.rightHandSize.z / 2.0f);
                    }
                    else if (drawingManager.currentTilemap == rightThumbTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.rightThumbSize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.rightThumbSize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.rightThumbSize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.rightThumbSize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.rightThumbSize.z / 2.0f);
                    }
                    else if (drawingManager.currentTilemap == rightIndexTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.rightIndexSize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.rightIndexSize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.rightIndexSize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.rightIndexSize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.rightIndexSize.z / 2.0f);
                    }
                    else if (drawingManager.currentTilemap == rightMiddleTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.rightMiddleSize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.rightMiddleSize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.rightMiddleSize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.rightMiddleSize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.rightMiddleSize.z / 2.0f);
                    }
                    else if (drawingManager.currentTilemap == rightRingTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.rightRingSize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.rightRingSize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.rightRingSize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.rightRingSize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.rightRingSize.z / 2.0f);
                    }
                    else if (drawingManager.currentTilemap == rightPinkyTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.rightPinkySize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.rightPinkySize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.rightPinkySize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.rightPinkySize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.rightPinkySize.z / 2.0f);
                    }
                    else if (drawingManager.currentTilemap == leftLegTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.leftLegSize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.leftLegSize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.leftLegSize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.leftLegSize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.leftLegSize.z / 2.0f);
                    }
                    else if (drawingManager.currentTilemap == leftFootTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.leftFootSize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.leftFootSize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.leftFootSize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.leftFootSize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.leftFootSize.z / 2.0f);
                    }
                    else if (drawingManager.currentTilemap == rightLegTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.rightLegSize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.rightLegSize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.rightLegSize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.rightLegSize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.rightLegSize.z / 2.0f);
                    }
                    else if (drawingManager.currentTilemap == rightFootTilemap)
                    {
                        minX = (int)-Mathf.Ceil(characterSettings.rightFootSize.x / 2.0f - 1.0f);
                        maxX = (int)Mathf.Floor(characterSettings.rightFootSize.x / 2.0f);
                        minY = 0;
                        maxY = characterSettings.rightFootSize.y - 1;
                        minZ = (int)-Mathf.Ceil(characterSettings.rightFootSize.z / 2.0f - 1.0f);
                        maxZ = (int)Mathf.Floor(characterSettings.rightFootSize.z / 2.0f);
                    }

                    // Reduce the axis facing towards the camera to 0
                    if (drawingManager.currentTilemap.gameObject.transform.right.z != 0)
                    {
                        minX = 0;
                        maxX = 0;
                    }
                    else if (drawingManager.currentTilemap.gameObject.transform.up.z != 0)
                    {
                        minY = 0;
                        maxY = 0;
                    }
                    else if (drawingManager.currentTilemap.gameObject.transform.forward.z != 0)
                    {
                        minZ = 0;
                        maxZ = 0;
                    }

                    TileBase selectedTile = null;
                    Color oldColor = Color.white;
                    // Determine if the selected grid spot has a tile
                    if (drawingManager.currentTilemap.HasTile(position))
                    {
                        selectedTile = drawingManager.currentTilemap.GetTile(position);
                        oldColor = drawingManager.currentTilemap.GetColor(position);
                    }

                    Fill(drawingManager.currentTilemap, minX, maxX, minY, maxY, minZ, maxZ, position, selectedTile, oldColor);

                    CheckForEmptyTilemaps();
                }
                else if (drawingManager.currentMode == DrawModes.Picker && Input.GetMouseButtonDown(0))
                {
                    if (drawingManager.currentTilemap.HasTile(position))
                    {
                        drawingManager.currentColor = drawingManager.currentTilemap.GetColor(position);
                        drawingManager.colorPicker.GetComponent<FlexibleColorPicker>().color = drawingManager.currentColor;
                    }
                }
                else if (drawingManager.currentMode == DrawModes.Select && Input.GetMouseButtonDown(0))
                {
                    if (drawingManager.currentTilemap == headTilemap) drawingManager.partScrollbar.value = 20.0f / 20.0f;
                    else if (drawingManager.currentTilemap == torsoTilemap) drawingManager.partScrollbar.value = 18.8f / 20.0f;
                    else if (drawingManager.currentTilemap == leftArmTilemap) drawingManager.partScrollbar.value = 17.7f / 20.0f;
                    else if (drawingManager.currentTilemap == leftHandTilemap) drawingManager.partScrollbar.value = 16.6f / 20.0f;
                    else if (drawingManager.currentTilemap == leftThumbTilemap) drawingManager.partScrollbar.value = 15.5f / 20.0f;
                    else if (drawingManager.currentTilemap == leftIndexTilemap) drawingManager.partScrollbar.value = 14.4f / 20.0f;
                    else if (drawingManager.currentTilemap == leftMiddleTilemap) drawingManager.partScrollbar.value = 13.3f / 20.0f;
                    else if (drawingManager.currentTilemap == leftRingTilemap) drawingManager.partScrollbar.value = 12.2f / 20.0f;
                    else if (drawingManager.currentTilemap == leftPinkyTilemap) drawingManager.partScrollbar.value = 11.1f / 20.0f;
                    else if (drawingManager.currentTilemap == rightArmTilemap) drawingManager.partScrollbar.value = 10.0f / 20.0f;
                    else if (drawingManager.currentTilemap == rightHandTilemap) drawingManager.partScrollbar.value = 9.9f / 20.0f;
                    else if (drawingManager.currentTilemap == rightThumbTilemap) drawingManager.partScrollbar.value = 8.8f / 20.0f;
                    else if (drawingManager.currentTilemap == rightIndexTilemap) drawingManager.partScrollbar.value = 7.7f / 20.0f;
                    else if (drawingManager.currentTilemap == rightMiddleTilemap) drawingManager.partScrollbar.value = 6.6f / 20.0f;
                    else if (drawingManager.currentTilemap == rightRingTilemap) drawingManager.partScrollbar.value = 5.5f / 20.0f;
                    else if (drawingManager.currentTilemap == rightPinkyTilemap) drawingManager.partScrollbar.value = 4.4f / 20.0f;
                    else if (drawingManager.currentTilemap == leftLegTilemap) drawingManager.partScrollbar.value = 3.3f / 20.0f;
                    else if (drawingManager.currentTilemap == leftFootTilemap) drawingManager.partScrollbar.value = 2.2f / 20.0f;
                    else if (drawingManager.currentTilemap == rightLegTilemap) drawingManager.partScrollbar.value = 1.1f / 20.0f;
                    else if (drawingManager.currentTilemap == rightFootTilemap) drawingManager.partScrollbar.value = 0.0f / 20.0f;
                }
            }
        }
        else
        {
            prevPosition = new Vector3Int(int.MaxValue, int.MaxValue, int.MaxValue);
        }
    }

    private void Fill(Tilemap currentTilemap, int minX, int maxX, int minY, int maxY, int minZ, int maxZ, Vector3Int position, TileBase selectedTile, Color oldColor)
    {
        if (selectedTile != null && oldColor != drawingManager.currentColor)
        {
            // Set the tile for color creation.
            drawingManager.currentTilemap.SetTile(position, tile);

            // Flag the tile, inidicating that it can change color.
            // By default it's set to "Lock Color".
            drawingManager.currentTilemap.SetTileFlags(position, TileFlags.None);

            // Set the color.
            drawingManager.currentTilemap.SetColor(position, drawingManager.currentColor);

            // Check if adjacent tiles are the same as the one clicked
            if (drawingManager.currentTilemap.HasTile(new Vector3Int(position.x + 1, position.y, position.z)) &&
                drawingManager.currentTilemap.GetColor(new Vector3Int(position.x + 1, position.y, position.z)) == oldColor && 
                position.x + 1 <= maxX)
            {
                Fill(currentTilemap, minX, maxX, minY, maxY, minZ, maxZ, new Vector3Int(position.x + 1, position.y, position.z), selectedTile, oldColor);
            }
            if (drawingManager.currentTilemap.HasTile(new Vector3Int(position.x - 1, position.y, position.z)) &&
                drawingManager.currentTilemap.GetColor(new Vector3Int(position.x - 1, position.y, position.z)) == oldColor &&
                position.x - 1 >= minX)
            {
                Fill(currentTilemap, minX, maxX, minY, maxY, minZ, maxZ, new Vector3Int(position.x - 1, position.y, position.z), selectedTile, oldColor);
            }
            if (drawingManager.currentTilemap.HasTile(new Vector3Int(position.x, position.y + 1, position.z)) &&
                drawingManager.currentTilemap.GetColor(new Vector3Int(position.x, position.y + 1, position.z)) == oldColor &&
                position.y + 1 <= maxY)
            {
                Fill(currentTilemap, minX, maxX, minY, maxY, minZ, maxZ, new Vector3Int(position.x, position.y + 1, position.z), selectedTile, oldColor);
            }
            if (drawingManager.currentTilemap.HasTile(new Vector3Int(position.x, position.y - 1, position.z)) &&
                drawingManager.currentTilemap.GetColor(new Vector3Int(position.x, position.y - 1, position.z)) == oldColor &&
                position.y - 1 >= minY)
            {
                Fill(currentTilemap, minX, maxX, minY, maxY, minZ, maxZ, new Vector3Int(position.x, position.y - 1, position.z), selectedTile, oldColor);
            }
            if (drawingManager.currentTilemap.HasTile(new Vector3Int(position.x, position.y, position.z + 1)) &&
                drawingManager.currentTilemap.GetColor(new Vector3Int(position.x, position.y, position.z + 1)) == oldColor &&
                position.z + 1 <= maxZ)
            {
                Fill(currentTilemap, minX, maxX, minY, maxY, minZ, maxZ, new Vector3Int(position.x, position.y, position.z + 1), selectedTile, oldColor);
            }
            if (drawingManager.currentTilemap.HasTile(new Vector3Int(position.x, position.y, position.z - 1)) &&
                drawingManager.currentTilemap.GetColor(new Vector3Int(position.x, position.y, position.z - 1)) == oldColor &&
                position.z - 1 >= minZ)
            {
                Fill(currentTilemap, minX, maxX, minY, maxY, minZ, maxZ, new Vector3Int(position.x, position.y, position.z - 1), selectedTile, oldColor);
            }
        }
        else
        {
            // Set the tile for color creation.
            drawingManager.currentTilemap.SetTile(position, tile);

            // Flag the tile, inidicating that it can change color.
            // By default it's set to "Lock Color".
            drawingManager.currentTilemap.SetTileFlags(position, TileFlags.None);

            // Set the color.
            drawingManager.currentTilemap.SetColor(position, drawingManager.currentColor);

            // Check if adjacent spots have tiles
            if (!drawingManager.currentTilemap.HasTile(new Vector3Int(position.x + 1, position.y, position.z)) &&
                position.x + 1 <= maxX)
            {
                Fill(currentTilemap, minX, maxX, minY, maxY, minZ, maxZ, new Vector3Int(position.x + 1, position.y, position.z), selectedTile, oldColor);
            }
            if (!drawingManager.currentTilemap.HasTile(new Vector3Int(position.x - 1, position.y, position.z)) &&
                position.x - 1 >= minX)
            {
                Fill(currentTilemap, minX, maxX, minY, maxY, minZ, maxZ, new Vector3Int(position.x - 1, position.y, position.z), selectedTile, oldColor);
            }
            if (!drawingManager.currentTilemap.HasTile(new Vector3Int(position.x, position.y + 1, position.z)) &&
                position.y + 1 <= maxY)
            {
                Fill(currentTilemap, minX, maxX, minY, maxY, minZ, maxZ, new Vector3Int(position.x, position.y + 1, position.z), selectedTile, oldColor);
            }
            if (!drawingManager.currentTilemap.HasTile(new Vector3Int(position.x, position.y - 1, position.z)) &&
                position.y - 1 >= minY)
            {
                Fill(currentTilemap, minX, maxX, minY, maxY, minZ, maxZ, new Vector3Int(position.x, position.y - 1, position.z), selectedTile, oldColor);
            }
            if (!drawingManager.currentTilemap.HasTile(new Vector3Int(position.x, position.y, position.z + 1)) &&
                position.z + 1 <= maxZ)
            {
                Fill(currentTilemap, minX, maxX, minY, maxY, minZ, maxZ, new Vector3Int(position.x, position.y, position.z + 1), selectedTile, oldColor);
            }
            if (!drawingManager.currentTilemap.HasTile(new Vector3Int(position.x, position.y, position.z - 1)) &&
                position.z - 1 >= minZ)
            {
                Fill(currentTilemap, minX, maxX, minY, maxY, minZ, maxZ, new Vector3Int(position.x, position.y, position.z - 1), selectedTile, oldColor);
            }
        }
    }

    public void CheckForEmptyTilemaps()
    {
        if (GetNumberOfTiles(headTilemap) == 0 ||
        GetNumberOfTiles(torsoTilemap) == 0 ||
        GetNumberOfTiles(leftArmTilemap) == 0 ||
        GetNumberOfTiles(leftHandTilemap) == 0 ||
        GetNumberOfTiles(leftThumbTilemap) == 0 ||
        GetNumberOfTiles(leftIndexTilemap) == 0 ||
        GetNumberOfTiles(leftMiddleTilemap) == 0 ||
        GetNumberOfTiles(leftRingTilemap) == 0 ||
        GetNumberOfTiles(leftPinkyTilemap) == 0 ||
        GetNumberOfTiles(rightArmTilemap) == 0 ||
        GetNumberOfTiles(rightHandTilemap) == 0 ||
        GetNumberOfTiles(rightThumbTilemap) == 0 ||
        GetNumberOfTiles(rightIndexTilemap) == 0 ||
        GetNumberOfTiles(rightMiddleTilemap) == 0 ||
        GetNumberOfTiles(rightRingTilemap) == 0 ||
        GetNumberOfTiles(rightPinkyTilemap) == 0 ||
        GetNumberOfTiles(leftLegTilemap) == 0 ||
        GetNumberOfTiles(leftFootTilemap) == 0 ||
        GetNumberOfTiles(rightLegTilemap) == 0 ||
        GetNumberOfTiles(rightFootTilemap) == 0)
        {
            drawingManager.warningSign.SetActive(true);
        }
        else
        {
            drawingManager.warningSign.SetActive(false);
        }
    }

    public static int GetNumberOfTiles(Tilemap tilemap)
    {
        tilemap.CompressBounds();
        TileBase[] tiles = tilemap.GetTilesBlock(tilemap.cellBounds);
        return tiles.Where(x => x != null).ToArray().Length;
    }

    public void CleanAllTilemaps()
    {
        drawingManager.CleanTilemap(ref headTilemap, characterSettings.headSize);
        drawingManager.CleanTilemap(ref torsoTilemap, characterSettings.torsoSize);
        drawingManager.CleanTilemap(ref leftArmTilemap, characterSettings.leftArmSize);
        drawingManager.CleanTilemap(ref leftHandTilemap, characterSettings.leftHandSize);
        drawingManager.CleanTilemap(ref leftThumbTilemap, characterSettings.leftThumbSize);
        drawingManager.CleanTilemap(ref leftIndexTilemap, characterSettings.leftIndexSize);
        drawingManager.CleanTilemap(ref leftMiddleTilemap, characterSettings.leftMiddleSize);
        drawingManager.CleanTilemap(ref leftRingTilemap, characterSettings.leftRingSize);
        drawingManager.CleanTilemap(ref leftPinkyTilemap, characterSettings.leftPinkySize);
        drawingManager.CleanTilemap(ref rightArmTilemap, characterSettings.rightArmSize);
        drawingManager.CleanTilemap(ref rightHandTilemap, characterSettings.rightHandSize);
        drawingManager.CleanTilemap(ref rightThumbTilemap, characterSettings.rightThumbSize);
        drawingManager.CleanTilemap(ref rightIndexTilemap, characterSettings.rightIndexSize);
        drawingManager.CleanTilemap(ref rightMiddleTilemap, characterSettings.rightMiddleSize);
        drawingManager.CleanTilemap(ref rightRingTilemap, characterSettings.rightRingSize);
        drawingManager.CleanTilemap(ref rightPinkyTilemap, characterSettings.rightPinkySize);
        drawingManager.CleanTilemap(ref leftLegTilemap, characterSettings.leftLegSize);
        drawingManager.CleanTilemap(ref leftFootTilemap, characterSettings.leftFootSize);
        drawingManager.CleanTilemap(ref rightLegTilemap, characterSettings.rightLegSize);
        drawingManager.CleanTilemap(ref rightFootTilemap, characterSettings.rightFootSize);
    }
}
