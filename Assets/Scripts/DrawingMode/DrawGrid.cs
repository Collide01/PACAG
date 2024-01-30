using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DrawGrid : MonoBehaviour
{
    [SerializeField] DrawingManager drawingManager;
    [SerializeField] Tilemap tilemap;
    [SerializeField] Tile tile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !drawingManager.changingColors)
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int position = tilemap.WorldToCell(worldPoint);

            if (drawingManager.currentMode == DrawModes.Draw)
            {
                // Set the tile for color creation.
                tilemap.SetTile(position, tile);

                // Flag the tile, inidicating that it can change color.
                // By default it's set to "Lock Color".
                tilemap.SetTileFlags(position, TileFlags.None);

                // Set the color.
                tilemap.SetColor(position, drawingManager.currentColor);
            }
            else if (drawingManager.currentMode == DrawModes.Erase)
            {
                // Erase the tile
                tilemap.SetTile(position, null);
            }
        }
    }
}
