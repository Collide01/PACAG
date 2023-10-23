using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Pixelation : MonoBehaviour
{
    [SerializeField] private Tilemap pixelGrid;
    [SerializeField] private Tile pixelTile;

    // Start is called before the first frame update
    void Start()
    {
        SetTileColour(Color.green, Vector3Int.zero, pixelGrid);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Set the color of a tile.
    /// </summary>
    /// <param name="color">The desired color.</param>
    /// <param name="position">The position of the tile.</param>
    /// <param name="tilemap">The tilemap the tile belongs to.</param>
    private void SetTileColour(Color color, Vector3Int position, Tilemap tilemap)
    {
        // Set the tile for color creation.
        tilemap.SetTile(position, pixelTile);

        // Flag the tile, inidicating that it can change color.
        // By default it's set to "Lock Color".
        tilemap.SetTileFlags(position, TileFlags.None);

        // Set the color.
        tilemap.SetColor(position, color);

        Debug.Log(tilemap.GetColor(position));
    }
}
