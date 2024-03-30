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
    private int currentFrame;
    private float animationLength;
    public List<float> animationFrames;
    public bool animationSet;
    // Coroutines
    private IEnumerator animationPreReq;
    private IEnumerator handleSpriteData;

    private void Start()
    {
        mannequin = GameObject.FindGameObjectWithTag("Mannequin");
        frameRate = GameObject.FindGameObjectWithTag("CharacterSettings").GetComponent<CharacterSettings>().frameRate;
        animationFrames = new List<float>();
        cellPositions = new List<List<Vector3Int>>();
        cellColors = new List<List<Color>>();
        animationPreReq = AnimationPreReq();
        handleSpriteData = HandleSpriteData();
        StartCoroutine(handleSpriteData);
    }

    public void StartAnimationProcess()
    {
        // Reset animation values
        cellPositions.Clear();
        cellColors.Clear();
        pixelGrid.ClearAllTiles();
        animationFrames.Clear();
        animationSet = false;
        currentFrame = 0;

        frameRate = GameObject.FindGameObjectWithTag("CharacterSettings").GetComponent<CharacterSettings>().frameRate;
        UpdatePixelList();
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

        // Organizes the sprite data based on their z-positions.
        // This makes it so pixels that already have a color can't be drawn over.
        Array.Sort(pixelLocations, ZPositionComparison);

        animationLength = mannequin.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length;
        mannequin.GetComponent<Animator>().SetFloat("motionTime", 0);

        float frameInterval = 1000.0f / frameRate / 1000.0f;

        // Creates animation frame times based on the frame rate
        int frameIndex = 0;
        while (frameInterval * frameIndex < animationLength)
        {
            animationFrames.Add(frameInterval * frameIndex);

            frameIndex++;
        }
    }

    /// <summary>
    /// Create pixels for each frame.
    /// </summary>
    private IEnumerator HandleSpriteData()
    {
        while (true)
        {
            if (animationFrames.Count > 0)
            {
                if (!animationSet)
                {
                    // Creates a frame for the first loop of the animation
                    while (cellPositions.Count <= currentFrame)
                    {
                        cellPositions.Add(new List<Vector3Int>());
                        cellColors.Add(new List<Color>());
                    }

                    // Creates the pixels
                    for (int i = 0; i < pixelLocations.Length; i++)
                    {
                        Vector3Int cellPosition = pixelGrid.WorldToCell(pixelLocations[i].transform.position);
                        if (!cellPositions[currentFrame].Contains(cellPosition))
                        {
                            cellPositions[currentFrame].Add(cellPosition);
                            cellColors[currentFrame].Add(pixelLocations[i].GetComponent<PixelData>().GetColor());
                        }
                    }

                    // If this is the last frame in the animation, the animation is complete
                    if (currentFrame == animationFrames.Count - 1)
                    {
                        animationSet = true;
                        currentFrame = 0;
                    }
                    else
                    {
                        currentFrame++;
                        mannequin.GetComponent<Animator>().SetFloat("motionTime", animationFrames[currentFrame]);
                    }

                    yield return null;
                }
                else
                {
                    CreateSprite(currentFrame);
                    
                    yield return new WaitForSecondsRealtime(1000.0f / frameRate / 1000.0f);

                    currentFrame++;
                    if (currentFrame >= animationFrames.Count)
                    {
                        currentFrame = 0;
                    }
                }
            }
            else
            {
                yield return null;
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