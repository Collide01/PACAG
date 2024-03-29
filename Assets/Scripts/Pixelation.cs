using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Tilemaps;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Pixelation : MonoBehaviour
{
    private GameObject mannequin;
    [SerializeField] private Tilemap pixelGrid;
    [SerializeField] private Tile pixelTile;
    [HideInInspector] public int frameRate;
    // cellPositions and cellColors store the pixel data for each frame of the animation
    [HideInInspector] public List<List<Vector3Int>> cellPositions;
    [HideInInspector] public List<List<Color>> cellColors;
    [HideInInspector] public GameObject[] pixelLocations;
    // These variables help to create the animation
    private float animationLength;
    private List<float> animationFrames;
    private bool animationSet;
    // Coroutines
    IEnumerator animationPreReq;
    IEnumerator animateMannequin;

    private void Start()
    {
        mannequin = GameObject.FindGameObjectWithTag("Mannequin");
        frameRate = GameObject.FindGameObjectWithTag("CharacterSettings").GetComponent<CharacterSettings>().frameRate;
        animationFrames = new List<float>();
        cellPositions = new List<List<Vector3Int>>();
        cellColors = new List<List<Color>>();
        animationPreReq = AnimationPreReq();
        animateMannequin = AnimateMannequin();

        animationLength = mannequin.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length;
        mannequin.GetComponent<Animator>().SetFloat("motionTime", 0);
    }

    public void StartAnimationProcess()
    {
        StopCoroutine(animateMannequin);
        cellPositions.Clear();
        cellColors.Clear();
        animationFrames.Clear();
        animationSet = false;
        StartCoroutine(animationPreReq);
    }

    /// <summary>
    /// Waits a little bit for the program to receive the Animator Clip Data
    /// </summary>
    /// <returns></returns>
    private IEnumerator AnimationPreReq()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.25f);

            if (mannequin.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length > 0)
            {
                SetAnimationEvents();
            }
            else
            {
                Debug.Log("No animation clip info");
            }
        }
    }

    /// <summary>
    /// Create animation events for the animation based on the frame rate
    /// </summary>
    public void SetAnimationEvents()
    {
        StopCoroutine(animationPreReq);

        animationLength = mannequin.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length;
        mannequin.GetComponent<Animator>().SetFloat("motionTime", 0);

        UpdatePixelList();
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

            animationFrames.Add(frameInterval * eventIndex);

            eventIndex++;
        }

        // Organizes the sprite data based on their z-positions.
        // This makes it so pixels that already have a color can't be drawn over.
        Array.Sort(pixelLocations, ZPositionComparison);

        mannequin.GetComponent<Animator>().SetFloat("motionTime", 0);
    }

    /// <summary>
    /// The function that AnimationEvents call as the animation plays.
    /// AnimationEvents are used to make the sprite rendering more accurate.
    /// </summary>
    public void AnimationEventFunction(int frame)
    {
        Debug.Log(frame + ", " + animationFrames.Count);
        if (!animationSet)
        {
            CreateSpriteData(frame);
        }
        else
        {
            CreateSprite(frame);
        }
    }

    /// <summary>
    /// Create pixels for each frame.
    /// </summary>
    /// <param name="frame">Frame of the animation</param>
    public void CreateSpriteData(int frame)
    {
        // Creates a frame for the first loop of the animation
        while (cellPositions.Count <= frame)
        {
            cellPositions.Add(new List<Vector3Int>());
            cellColors.Add(new List<Color>());
        }
        
        // Creates the pixels
        for (int i = 0; i < pixelLocations.Length; i++)
        {
            Vector3Int cellPosition = pixelGrid.WorldToCell(pixelLocations[i].transform.position);
            if (!cellPositions[frame].Contains(cellPosition))
            {
                cellPositions[frame].Add(cellPosition);
                cellColors[frame].Add(pixelLocations[i].GetComponent<PixelData>().GetColor());
            }
        }

        // If this is the last frame in the animation, the animation is complete
        if (frame == mannequin.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.events.Length - 1)
        {
            animationSet = true;
            StartCoroutine(animateMannequin);
        }
        else
        {
            mannequin.GetComponent<Animator>().SetFloat("motionTime", animationFrames[frame + 1]);
        }
    }

    private IEnumerator AnimateMannequin()
    {
        int frame = 0;
        while (animationSet)
        {
            mannequin.GetComponent<Animator>().SetFloat("motionTime", animationFrames[frame]);

            yield return new WaitForSecondsRealtime(1000.0f / frameRate / 1000.0f);

            frame++;
            if (frame >= animationFrames.Count)
            {
                frame = 0;
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