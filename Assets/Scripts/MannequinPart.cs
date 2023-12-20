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
                    CreatePixelBlocks(characterSettings.torsoSize.x, characterSettings.torsoJoint1, characterSettings.torsoSize.z, Color.red);
                }
                
                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.Spine, Color.red, characterSettings.torsoJoint1, true);
                    CreateJoint(BodyPart.LeftUpLeg, Color.blue, -1, true);
                    CreateJoint(BodyPart.RightUpLeg, Color.blue, -1, true);
                }
                break;

            case BodyPart.Spine:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.torsoSize.x, characterSettings.torsoJoint2 - characterSettings.torsoJoint1, characterSettings.torsoSize.z, Color.red);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.Spine1, Color.red, characterSettings.torsoJoint2 - characterSettings.torsoJoint1, true);
                }
                break;

            case BodyPart.Spine1:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.torsoSize.x, characterSettings.torsoJoint3 - characterSettings.torsoJoint2, characterSettings.torsoSize.z, Color.red);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.Spine2, Color.red, characterSettings.torsoJoint3 - characterSettings.torsoJoint2, true);
                }
                break;

            case BodyPart.Spine2:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.torsoSize.x, characterSettings.torsoSize.y - characterSettings.torsoJoint3, characterSettings.torsoSize.z, Color.red);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.Neck, Color.yellow, characterSettings.torsoSize.y - characterSettings.torsoJoint3, true);
                    CreateJoint(BodyPart.LeftArm, Color.yellow, characterSettings.torsoSize.y - characterSettings.torsoJoint3 - 0.5f - (characterSettings.leftArmSize.z / 2.0f), true);
                    CreateJoint(BodyPart.RightArm, Color.yellow, characterSettings.torsoSize.y - characterSettings.torsoJoint3 - 0.5f - (characterSettings.leftArmSize.z / 2.0f), true);
                }
                break;

            case BodyPart.Neck:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.headSize.x, characterSettings.headSize.y, characterSettings.headSize.z, Color.yellow);
                }
                break;

            case BodyPart.LeftArm:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftArmSize.x, characterSettings.leftElbow, characterSettings.leftArmSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.LeftForearm, Color.yellow, characterSettings.leftElbow, true);
                }
                break;

            case BodyPart.LeftForearm:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftArmSize.x, characterSettings.leftArmSize.y - characterSettings.leftElbow, characterSettings.leftArmSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.LeftHand, Color.yellow, characterSettings.leftArmSize.y - characterSettings.leftElbow, false);
                }
                break;

            case BodyPart.RightArm:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightArmSize.x, characterSettings.rightElbow, characterSettings.rightArmSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.RightForearm, Color.yellow, characterSettings.rightElbow, true);
                }
                break;

            case BodyPart.RightForearm:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightArmSize.x, characterSettings.rightArmSize.y - characterSettings.rightElbow, characterSettings.rightArmSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.RightHand, Color.yellow, characterSettings.rightArmSize.y - characterSettings.rightElbow, false);
                }
                break;

            case BodyPart.LeftUpLeg:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftLegSize.x, characterSettings.leftKnee, characterSettings.leftLegSize.z, Color.blue);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.LeftLeg, Color.blue, characterSettings.leftKnee, true);
                }
                break;

            case BodyPart.LeftLeg:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftLegSize.x, characterSettings.leftLegSize.y - characterSettings.leftKnee, characterSettings.leftLegSize.z, Color.blue);
                }
                break;

            case BodyPart.RightUpLeg:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightLegSize.x, characterSettings.rightKnee, characterSettings.rightLegSize.z, Color.blue);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.RightLeg, Color.blue, characterSettings.rightKnee, true);
                }
                break;

            case BodyPart.RightLeg:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightLegSize.x, characterSettings.rightLegSize.y - characterSettings.rightKnee, characterSettings.rightLegSize.z, Color.blue);
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Creates the pixels for the pixelation
    private void CreatePixelBlocks(int partSizeX, int partSizeY, int partSizeZ, Color pixelColor)
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
                    pixelInstance.GetComponent<PixelData>().pixelColor = pixelColor;
                }
            }
        }
    }

    // Creates a joint for the pixel body
    private void CreateJoint(BodyPart joint, Color jointColor, float height, bool createNewJoint)
    {
        GameObject jointInstance = Instantiate(jointPoint, transform.position, transform.rotation);

        JointData jointData = jointInstance.GetComponent<JointData>();
        jointData.modelJoint = joint;
        jointData.jointSet = true;

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

        // Create the joints at different locations
        jointInstance.transform.parent = transform;
        float pixelSize = jointInstance.transform.localScale.x;
        switch (joint)
        {
            case BodyPart.LeftArm:
                if (characterSettings.torsoSize.x % 2 == 1) // Odd
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x - pixelSize * Mathf.Ceil(characterSettings.torsoSize.x / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                }
                else
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x - pixelSize * Mathf.Ceil(characterSettings.torsoSize.x / 2.0f) - (pixelSize / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                }
                break;
            case BodyPart.RightArm:
                if (characterSettings.torsoSize.x % 2 == 1) // Odd
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x + pixelSize * Mathf.Ceil(characterSettings.torsoSize.x / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                }
                else
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x + pixelSize * Mathf.Ceil(characterSettings.torsoSize.x / 2.0f) + (pixelSize / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                }
                break;
            case BodyPart.LeftUpLeg:
                if (characterSettings.torsoSize.x % 2 == 1) // Odd
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x - pixelSize * Mathf.Ceil(characterSettings.torsoSize.x / 2.0f) + (pixelSize / 2) + (pixelSize * characterSettings.leftLegSize.x / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                }
                else
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x - pixelSize * Mathf.Ceil(characterSettings.torsoSize.x / 2.0f) + (pixelSize * characterSettings.leftLegSize.x / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                }
                break;
            case BodyPart.RightUpLeg:
                if (characterSettings.torsoSize.x % 2 == 1) // Odd
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x + pixelSize * Mathf.Ceil(characterSettings.torsoSize.x / 2.0f) - (pixelSize / 2) - (pixelSize * characterSettings.leftLegSize.x / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                }
                else
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x + pixelSize * Mathf.Ceil(characterSettings.torsoSize.x / 2.0f) - (pixelSize * characterSettings.leftLegSize.x / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                }
                break;
            default:
                jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x, jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                break;
        }
    }
}
