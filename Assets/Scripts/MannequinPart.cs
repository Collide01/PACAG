using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MannequinPart : MonoBehaviour
{
    private CharacterSettings characterSettings;
    public GridLayout pixelGrid;
    public Tilemap pixelTilemap;
    public Pixelation pixelation;
    public GameObject pixel;
    public GameObject jointPoint;
    public BodyPart bodyPart;
    public Color partColor;

    // Start is called before the first frame update
    void Start()
    {
        characterSettings = GameObject.FindGameObjectWithTag("CharacterSettings").GetComponent<CharacterSettings>();

        // Create the PixelGrid objects and joints and set them as children of the object
        switch (bodyPart)
        {
            case BodyPart.Hips:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.torsoSize.x, characterSettings.torsoJoint1, characterSettings.torsoSize.z);
                }
                
                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.Spine, Color.red, characterSettings.torsoJoint1, true);
                }
                break;

            case BodyPart.Spine:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.torsoSize.x, characterSettings.torsoJoint2 - characterSettings.torsoJoint1, characterSettings.torsoSize.z);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.Spine1, Color.red, characterSettings.torsoJoint2 - characterSettings.torsoJoint1, true);
                }
                break;

            case BodyPart.Spine1:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.torsoSize.x, characterSettings.torsoJoint3 - characterSettings.torsoJoint2, characterSettings.torsoSize.z);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.Spine2, Color.red, characterSettings.torsoJoint3 - characterSettings.torsoJoint2, true);
                }
                break;

            case BodyPart.Spine2:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.torsoSize.x, characterSettings.torsoSize.y - characterSettings.torsoJoint3, characterSettings.torsoSize.z);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.Neck, Color.yellow, characterSettings.torsoSize.y - characterSettings.torsoJoint3, true);
                }
                break;

            case BodyPart.Neck:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.headSize.x, characterSettings.headSize.y, characterSettings.headSize.z);
                }
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

    private void CreateJoint(BodyPart joint, Color jointColor, int height, bool createNewJoint)
    {
        GameObject jointInstance = Instantiate(jointPoint, transform.position, transform.rotation);

        JointData jointData = jointInstance.GetComponent<JointData>();
        jointData.modelJoint = joint;

        MannequinPart jointMannequinPart = jointInstance.GetComponent<MannequinPart>();
        jointMannequinPart.pixelGrid = pixelGrid;
        jointMannequinPart.pixelTilemap = pixelTilemap;
        jointMannequinPart.pixelation = pixelation;
        if (createNewJoint)
        {
            jointMannequinPart.pixel = pixel;
            jointMannequinPart.jointPoint = jointPoint;
        }
        jointMannequinPart.bodyPart = joint;
        jointMannequinPart.partColor = jointColor;

        jointInstance.transform.parent = transform;
        float pixelSize = jointInstance.transform.localScale.x;
        jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x, jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
    }
}
