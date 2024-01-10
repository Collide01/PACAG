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
    private FPSCounter fpsCounter;
    // These floats get the animation length in seconds to determine how long the frame creation process occurs
    private float animationLength;
    private float currentAnimationTime;
    private bool creatingAnimation;

    private void Start()
    {
        mannequin = GameObject.FindGameObjectWithTag("Mannequin");
        frameRate = GameObject.FindGameObjectWithTag("CharacterSettings").GetComponent<CharacterSettings>().frameRate;
        fpsCounter = GameObject.FindGameObjectWithTag("FPSController").GetComponent<FPSCounter>();
        cellPositions = new List<List<Vector3Int>>();
        cellColors = new List<List<Color>>();
        animationLength = mannequin.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length;
        creatingAnimation = true;

        // Create animation events for the animation based on the frame rate
        SetAnimationEvents();
    }

    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        
    }

    private void SetAnimationEvents()
    {
        mannequin.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.events = null;
        float frameInterval = 1000 / frameRate / 1000;

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

        // Creates one last event at the end of the animation to signal that the sprite is complete
        AnimationEvent finalEvt = new AnimationEvent();
        finalEvt.time = animationLength;
        finalEvt.functionName = "AnimationEventFunction";

        mannequin.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.AddEvent(finalEvt);
    }

    /// <summary>
    /// The function that AnimationEvents call as the animation plays.
    /// AnimationEvents are used to make the sprite rendering more accurate.
    /// </summary>
    private void AnimationEventFunction(int frame)
    {
        switch (creatingAnimation)
        {
            case true:
                CreateSpriteData();
                Debug.Log(cellPositions.Count);
                break;
            case false:
                CreateSprite(frame);
                break;
        }
    }

    private void SwitchCreationState()
    {
        if (creatingAnimation)
        {
            creatingAnimation = false;
        }
    }

    private void CreateSpriteData()
    {
        cellPositions.Add(new List<Vector3Int>());
        cellColors.Add(new List<Color>());
        // Gets the sprite data based on their z-positions
        // This makes it so pixels that already have a color can't be drawn over.
        System.Array.Sort(pixelLocations, ZPositionComparison);
        foreach (GameObject pixel in pixelLocations)
        {
            Vector3Int cellPosition = pixelGrid.WorldToCell(pixel.transform.position);
            if (!cellPositions[cellPositions.Count - 1].Contains(cellPosition))
            {
                cellPositions[cellPositions.Count - 1].Add(cellPosition);
                cellColors[cellPositions.Count - 1].Add(pixel.GetComponent<PixelData>().pixelColor);
            }
        }
    }

    private void CreateSprite(int frame)
    {
        pixelGrid.ClearAllTiles();
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
