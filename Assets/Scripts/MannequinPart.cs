using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MannequinPart : MonoBehaviour
{
    const float PIXEL_SIZE = 0.2f; // In world size units
    private CharacterSettings characterSettings;
    public GridLayout pixelGrid;
    public Tilemap pixelTilemap;
    public Pixelation pixelation;
    public GameObject pixel;

    public enum BodyPart
    {
        Hips,
        LeftUpLeg,
        LeftLeg,
        LeftFoot,
        LeftToeBase,
        LeftToeEnd,
        RightUpLeg,
        RightLeg,
        RightFoot,
        RightToeBase,
        RightToeEnd,
        Spine,
        Spine1,
        Spine2,
        Neck,
        Head,
        HeadTop,
        LeftShoulder,
        LeftArm,
        LeftForearm,
        LeftHand,
        RightShoulder,
        RightArm,
        RightForearm,
        RightHand
    }
    public BodyPart bodyPart;
    public Color partColor;

    // Start is called before the first frame update
    void Start()
    {
        characterSettings = GameObject.FindGameObjectWithTag("CharacterSettings").GetComponent<CharacterSettings>();

        // Create the PixelGrid objects and set them as children of the object
        switch (bodyPart)
        {
            case BodyPart.Hips:
                CreatePixelBlocks(characterSettings.torsoSize.x, characterSettings.torsoJoint1, characterSettings.torsoSize.z);
                break;
        }

        /*Vector3Int cellPosition = pixelGrid.WorldToCell(transform.position);
        pixelation.SetTileColor(partColor, cellPosition, pixelTilemap);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (pixelation.frame >= 60 / pixelation.frameRate)
        {
            Vector3Int cellPosition = pixelGrid.WorldToCell(transform.position);
            pixelation.SetTileColor(partColor, cellPosition, pixelTilemap);
        }
    }

    private void CreatePixelBlocks(int partSizeX, int partSizeY, int partSizeZ)
    {
        for (int y = 0; y < partSizeY; y++)
        {
            for (int x = 0; x < partSizeX; x++)
            {
                for (int z = 0; z < partSizeZ; z++)
                {
                    GameObject pixelInstance = Instantiate(pixel, transform.position, transform.rotation);
                    pixelInstance.transform.parent = transform;
                    float pixelSize = pixelInstance.transform.localScale.x;

                    float currentXPosition = 0;
                    float currentZPosition = 0;

                    if (partSizeX % 2 == 0) // If the length is even
                    {
                        if (x % 2 == 1) // odd numbers
                        {
                            currentXPosition = pixelInstance.transform.localPosition.x + pixelSize * (x / 2) + pixelSize / 2;
                        }
                        else
                        {
                            currentXPosition = pixelInstance.transform.localPosition.x - pixelSize * (x / 2) - pixelSize / 2;
                        }
                    }
                    else
                    {
                        if (x % 2 == 1) // odd numbers
                        {
                            currentXPosition = pixelInstance.transform.localPosition.x + pixelSize * Mathf.Ceil(x / 2.0f);
                        }
                        else
                        {
                            currentXPosition = pixelInstance.transform.localPosition.x - pixelSize * (x / 2);
                        }
                    }

                    if (partSizeZ % 2 == 0) // If the width is even
                    {
                        if (z % 2 == 1) // odd numbers
                        {
                            currentZPosition = pixelInstance.transform.localPosition.z + pixelSize * (z / 2) + pixelSize / 2;
                        }
                        else
                        {
                            currentZPosition = pixelInstance.transform.localPosition.z - pixelSize * (z / 2) - pixelSize / 2;
                        }
                    }
                    else
                    {
                        if (z % 2 == 1) // odd numbers
                        {
                            currentZPosition = pixelInstance.transform.localPosition.z + pixelSize * Mathf.Ceil(z / 2.0f);
                        }
                        else
                        {
                            currentZPosition = pixelInstance.transform.localPosition.z - pixelSize * (z / 2);
                        }
                    }

                    pixelInstance.transform.localPosition = new Vector3(currentXPosition, y * pixelSize, currentZPosition);
                }
            }
        }
    }
}
