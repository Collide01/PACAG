using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DrawGrid : MonoBehaviour
{
    [SerializeField] private DrawingManager drawingManager;
    public Tilemap headTilemap;
    public Tilemap torsoTilemap;
    public Tilemap leftArmTilemap;
    public Tilemap rightArmTilemap;
    public Tilemap leftLegTilemap;
    public Tilemap rightLegTilemap;
    [SerializeField] private Tile tile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !drawingManager.changingColors && drawingManager.mouseInDrawField && drawingManager.mouseInBorder)
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int position = drawingManager.currentTilemap.WorldToCell(worldPoint);
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
            }
        }
    }
}
