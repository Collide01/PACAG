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
    // These floats get the animation length in seconds to determine how long the frame creation process occurs
    private float animationLength;
    private float currentAnimationTime;

    // Start is called before the first frame update
    void Start()
    {
        frameRate = GameObject.FindGameObjectWithTag("CharacterSettings").GetComponent<CharacterSettings>().frameRate;
        jointObjects = (MannequinPart[])FindObjectsOfType(typeof(MannequinPart));
        animationLength = GameObject.FindGameObjectWithTag("Mannequin").GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length;

        // Create all of the pixel grids for the animation
        int numberOfFrames = Mathf.FloorToInt(animationLength * frameRate);
        for (int i = 0; i < numberOfFrames; i++)
        {
            GameObject currentGrid = Instantiate(pixelGrid, transform);
            pixelGrids.Add(currentGrid);
        }

        // Set the first pixel grid as the active one
        for (int i = 0; i < pixelGrids.Count; i++)
        {
            pixelGrids[i].SetActive(false);
        }
        pixelGrids[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        currentAnimationTime += Time.unscaledDeltaTime;
        frame++;
        if (frame >= 60 / frameRate)
        {
            for (int i = 0; i < pixelGrids.Count; i++)
            {
                if (i != currentFrame)
                {
                    pixelGrids[i].SetActive(false);
                }
                else
                {
                    pixelGrids[i].SetActive(true);

                    // Set the appropriate data for each GameObject with the script
                    foreach (MannequinPart jointObject in jointObjects)
                    {
                        jointObject.pixelation = pixelGrids[i].GetComponent<Pixelation>();
                        jointObject.pixelation.UpdatePixelList();
                        jointObject.pixelation.SetSpriteFrame();
                    }
                }
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
        }

        if (frame >= 60 / frameRate)
        {
            frame = 0;
        }
    }
}
