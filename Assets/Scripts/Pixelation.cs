using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Pixelation : MonoBehaviour
{
    [SerializeField] private Tilemap pixelGrid;
    [SerializeField] private Tile pixelTile;
    public int frameRate;
    [HideInInspector] public int frame;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        frame++;
        if (frame >= 1 / frameRate)
        {
            pixelGrid.ClearAllTiles();
        }
    }

    private void LateUpdate()
    {
        if (frame >= 1 / frameRate)
        {
            frame = 0;
        }
    }

    /// <summary>
    /// Set the color of a tile.
    /// </summary>
    /// <param name="color">The desired color.</param>
    /// <param name="position">The position of the tile.</param>
    /// <param name="tilemap">The tilemap the tile belongs to.</param>
    public void SetTileColor(Color color, Vector3Int position, Tilemap tilemap)
    {
        // Set the tile for color creation.
        tilemap.SetTile(position, pixelTile);

        // Flag the tile, inidicating that it can change color.
        // By default it's set to "Lock Color".
        tilemap.SetTileFlags(position, TileFlags.None);

        // Set the color.
        tilemap.SetColor(position, color);
    }
}
