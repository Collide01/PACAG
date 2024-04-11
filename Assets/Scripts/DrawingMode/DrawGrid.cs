using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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

    // Start is called before the first frame update
    void Start()
    {
        characterSettings = GameObject.FindGameObjectWithTag("CharacterSettings").GetComponent<CharacterSettings>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !drawingManager.changingColors && drawingManager.mouseInDrawField && drawingManager.mouseInBorder)
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int position = drawingManager.currentTilemap.WorldToCell(worldPoint);

            if (Mathf.Abs(position.x) >= 100)
            {
                position = new Vector3Int(0, position.y, position.z);
            }
            if (Mathf.Abs(position.y) >= 100)
            {
                position = new Vector3Int(position.x, 0, position.z);
            }
            if (Mathf.Abs(position.z) >= 100)
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
            }
            else if (drawingManager.currentMode == DrawModes.Erase)
            {
                // Erase the tile
                drawingManager.currentTilemap.SetTile(position, null);
                drawingManager.currentTilemap.CompressBounds();
            }
            else if (drawingManager.currentMode == DrawModes.Fill)
            {
                // Fill the highlighted part of the body
                Fill(drawingManager.currentTilemap);
            }
        }
    }

    private void Fill(Tilemap currentTilemap)
    {
        
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
