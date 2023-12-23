using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Pixelation : MonoBehaviour
{
    [SerializeField] private Tilemap pixelGrid;
    [SerializeField] private Tile pixelTile;
    [HideInInspector] public int frameRate;
    [HideInInspector] public int frame;
    [HideInInspector] public GameObject[] pixelLocations;

    private void Start()
    {
        frameRate = GameObject.FindGameObjectWithTag("CharacterSettings").GetComponent<CharacterSettings>().frameRate;
    }

    private void FixedUpdate()
    {
        frame++;
        if (frame >= 60 / frameRate)
        {
            pixelGrid.ClearAllTiles();
            // Gets the pixel objects and draws sprites in them in order based on their z-positions
            // This makes it so pixels that already have a color can't be drawn over.
            System.Array.Sort(pixelLocations, ZPositionComparison);
            foreach (GameObject pixel in pixelLocations)
            {
                Vector3Int cellPosition = pixelGrid.WorldToCell(pixel.transform.position);
                if (!pixelGrid.HasTile(cellPosition))
                {
                    SetTileColor(pixel.GetComponent<PixelData>().pixelColor, cellPosition, pixelGrid);
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (frame >= 60 / frameRate)
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

    public void UpdatePixelList()
    {
        pixelLocations = GameObject.FindGameObjectsWithTag("GridTransform");
    }

    private int ZPositionComparison(GameObject a, GameObject b)
    {
        //null check, I consider nulls to be less than non-null
        if (a == null) return (b == null) ? 0 : -1;
        if (b == null) return 1;

        var za = a.transform.position.z;
        var zb = b.transform.position.z;
        return za.CompareTo(zb); //here I use the default comparison of floats
    }
}
