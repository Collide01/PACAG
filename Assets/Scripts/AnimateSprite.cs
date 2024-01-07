using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AnimateSprite : MonoBehaviour
{
    // This process creates multiple grids for each frame of the animation.
    // It is done this way to improve performance.
    public GameObject pixelGrid;
    [HideInInspector] public List<GameObject> pixelGrids;
    public int currentFrame; // index of pixelGrids
    [HideInInspector] public int frameRate;
    [HideInInspector] public int frame;
    private MannequinPart[] jointObjects;
    private FPSCounter fpsCounter;
    // These floats get the animation length in seconds to determine how long the frame creation process occurs
    private float animationLength;
    private float currentAnimationTime;
    private int creatingAnimation; // 0 = Creating grids; 1 = Checking for repetition; 2 = Done

    // Start is called before the first frame update
    void Start()
    {
        frameRate = GameObject.FindGameObjectWithTag("CharacterSettings").GetComponent<CharacterSettings>().frameRate;
        jointObjects = (MannequinPart[])FindObjectsOfType(typeof(MannequinPart));
        fpsCounter = GameObject.FindGameObjectWithTag("FPSController").GetComponent<FPSCounter>();
        animationLength = GameObject.FindGameObjectWithTag("Mannequin").GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length;
        GameObject.FindGameObjectWithTag("Mannequin").GetComponent<Animator>().speed = 0;
        creatingAnimation = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fpsCounter.fps >= 59.0f && fpsCounter.fps <= 61.0f)
        {
            GameObject.FindGameObjectWithTag("Mannequin").GetComponent<Animator>().speed = 1;
            currentAnimationTime += Time.unscaledDeltaTime;
            frame++;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Mannequin").GetComponent<Animator>().speed = 0;
        }
        
        if (frame >= 60 / frameRate && fpsCounter.fps >= 59.0f && fpsCounter.fps <= 61.0f)
        {
            switch (creatingAnimation)
            {
                case 0:
                    for (int i = 0; i < pixelGrids.Count; i++)
                    {
                        pixelGrids[i].SetActive(false);
                    }
                    GameObject currentGrid = Instantiate(pixelGrid, transform);
                    pixelGrids.Add(currentGrid);

                    // Set the appropriate data for each GameObject with the script
                    foreach (MannequinPart jointObject in jointObjects)
                    {
                        jointObject.pixelation = currentGrid.GetComponent<Pixelation>();
                        jointObject.pixelation.UpdatePixelList();
                        jointObject.pixelation.SetSpriteData();
                    }
                    break;
                case 1:
                    /*// Add more grids in case the animation timing is off
                    GameObject currentGrid = Instantiate(pixelGrid, transform);
                    pixelGrids.Add(currentGrid);

                    // Set the appropriate data for each GameObject with the script
                    foreach (MannequinPart jointObject in jointObjects)
                    {
                        jointObject.pixelation = currentGrid.GetComponent<Pixelation>();
                        jointObject.pixelation.UpdatePixelList();
                        jointObject.pixelation.SetSpriteData();
                    }

                    // If we successfully reach a loop, generate all of the grid cells
                    if (currentGrid.GetComponent<Pixelation>().cellPositions == pixelGrids[0].GetComponent<Pixelation>().cellPositions)
                    {
                        pixelGrids.Remove(currentGrid);

                        for (int i = 0; i < pixelGrids.Count; i++)
                        {
                            pixelGrids[i].GetComponent<Pixelation>().CreateSpriteFrame();
                        }

                        // After that's all done, only show the active one
                        for (int i = 0; i < pixelGrids.Count; i++)
                        {
                            if (i != currentFrame)
                            {
                                pixelGrids[i].SetActive(false);
                            }
                            else
                            {
                                pixelGrids[i].SetActive(true);
                            }
                        }

                        creatingAnimation = 2;
                    }*/
                    break;
                case 2:
                    for (int i = 0; i < pixelGrids.Count; i++)
                    {
                        if (i != currentFrame)
                        {
                            pixelGrids[i].SetActive(false);
                        }
                        else
                        {
                            pixelGrids[i].SetActive(true);
                        }
                    }
                    break;
            }
            currentFrame++;
        }
    }

    private void LateUpdate()
    {
        if (currentAnimationTime > animationLength)
        {
            currentAnimationTime = 0;
            currentFrame = 0;
            if (creatingAnimation == 0)
            {
                creatingAnimation = 1;
            }
        }

        if (frame >= 60 / frameRate)
        {
            frame = 0;
        }
    }
}
