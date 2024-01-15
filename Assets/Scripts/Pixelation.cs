using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Pixelation : MonoBehaviour
{
    private GameObject mannequin;
    [SerializeField] private Tilemap pixelGrid;
    [SerializeField] private Tile pixelTile;
    [HideInInspector] public int frameRate;
    private int prevFrameRate; // Checks if the frame rate changed during runtime
    // cellPositions and cellColors store the pixel data for each frame of the animation
    [HideInInspector] public List<List<Vector3Int>> cellPositions;
    [HideInInspector] public List<List<Color>> cellColors;
    [HideInInspector] public GameObject[] pixelLocations;
    private int pixelDrawnCount;
    private FPSCounter fpsCounter;
    // These floats get the animation length in seconds to determine how long the frame creation process occurs
    private float animationLength;

    private void Start()
    {
        mannequin = GameObject.FindGameObjectWithTag("Mannequin");
        frameRate = GameObject.FindGameObjectWithTag("CharacterSettings").GetComponent<CharacterSettings>().frameRate;
        fpsCounter = GameObject.FindGameObjectWithTag("FPSController").GetComponent<FPSCounter>();
        cellPositions = new List<List<Vector3Int>>();
        cellColors = new List<List<Color>>();
        animationLength = mannequin.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length;
        mannequin.GetComponent<Animator>().speed = 0;
    }

    /// <summary>
    /// Create animation events for the animation based on the frame rate
    /// </summary>
    public void SetAnimationEvents()
    {
        UpdatePixelList();
        mannequin.GetComponent<Animator>().speed = 1;
        mannequin.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.events = null;
        float frameInterval = 1000.0f / frameRate / 1000.0f;

        // Creates new Animation Events at specific intervals based on the frame rate
        int eventIndex = 0;
        while (frameInterval * eventIndex < animationLength)
        {
            AnimationEvent evt = new AnimationEvent();
            evt.time = frameInterval * eventIndex;
            evt.intParameter = eventIndex;
            evt.functionName = "AnimationEventFunction";

            mannequin.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.AddEvent(evt);

            eventIndex++;
        }

        // Organizes the sprite data based on their z-positions.
        // This makes it so pixels that already have a color can't be drawn over.
        Array.Sort(pixelLocations, ZPositionComparison);
    }

    /// <summary>
    /// The function that AnimationEvents call as the animation plays.
    /// AnimationEvents are used to make the sprite rendering more accurate.
    /// </summary>
    public void AnimationEventFunction(int frame)
    {
        Debug.Log(pixelDrawnCount + ", " + pixelLocations.Length);
        if (pixelDrawnCount < pixelLocations.Length)
        {
            CreateSpriteData(frame);
        }
        else
        {
            mannequin.GetComponent<Mannequin>().CallRemove();
            CreateSprite(frame);
        }
    }

    /// <summary>
    /// Create pixels for each frame, 1000 at a time.
    /// </summary>
    /// <param name="frame">Frame of the animation</param>
    public void CreateSpriteData(int frame)
    {
        // Creates a frame for the first loop of the animation
        if (cellPositions.Count <= frame)
        {
            cellPositions.Add(new List<Vector3Int>());
            cellColors.Add(new List<Color>());
        }

        // Counter for the first 1000 pixels for the loop
        int pixelCount = 0;
        if (pixelLocations.Length - pixelDrawnCount >= 1000)
        {
            pixelCount = 1000;
        }
        else
        {
            pixelCount = pixelLocations.Length - pixelDrawnCount;
        }
        
        // Creates the pixels
        for (int i = pixelDrawnCount; i < pixelDrawnCount + pixelCount; i++)
        {
            Vector3Int cellPosition = pixelGrid.WorldToCell(pixelLocations[i].transform.position);
            if (!cellPositions[frame].Contains(cellPosition))
            {
                cellPositions[frame].Add(cellPosition);
                cellColors[frame].Add(pixelLocations[i].GetComponent<PixelData>().pixelColor);
            }
        }

        // If this is the last frame in the animation, delete the pixel block
        if (frame == mannequin.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.events.Length - 1)
        {
            pixelDrawnCount += pixelCount;
        }
    }

    private void CreateSprite(int frame)
    {
        Debug.Log(frame);
        pixelGrid.ClearAllTiles();
        //Debug.Log(cellPositions.Count + ", " + frame);
        // Gets the pixel objects and draws sprites in them based on the sprite data
        for (int i = 0; i < cellPositions[frame].Count; i++)
        {
            SetTileColor(cellColors[frame][i], cellPositions[frame][i], pixelGrid);
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