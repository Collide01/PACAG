using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MannequinPart : MonoBehaviour
{
    private CharacterSettings characterSettings;
    public Pixelation pixelation;
    public GameObject pixel;
    public GameObject jointPoint;
    public BodyPart bodyPart;

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
                    CreateJoint(BodyPart.Spine, characterSettings.torsoJoint1, true);
                    CreateJoint(BodyPart.LeftUpLeg, -1, true);
                    CreateJoint(BodyPart.RightUpLeg, -1, true);
                }
                break;

            case BodyPart.Spine:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.torsoSize.x, characterSettings.torsoJoint2 - characterSettings.torsoJoint1, characterSettings.torsoSize.z, Color.red);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.Spine1, characterSettings.torsoJoint2 - characterSettings.torsoJoint1, true);
                }
                break;

            case BodyPart.Spine1:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.torsoSize.x, characterSettings.torsoJoint3 - characterSettings.torsoJoint2, characterSettings.torsoSize.z, Color.red);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.Spine2, characterSettings.torsoJoint3 - characterSettings.torsoJoint2, true);
                }
                break;

            case BodyPart.Spine2:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.torsoSize.x, characterSettings.torsoSize.y - characterSettings.torsoJoint3, characterSettings.torsoSize.z, Color.red);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.Neck, characterSettings.torsoSize.y - characterSettings.torsoJoint3, true);
                    CreateJoint(BodyPart.LeftArm, characterSettings.torsoSize.y - characterSettings.torsoJoint3 - 0.5f - (characterSettings.leftArmSize.z / 2.0f), true);
                    CreateJoint(BodyPart.RightArm, characterSettings.torsoSize.y - characterSettings.torsoJoint3 - 0.5f - (characterSettings.leftArmSize.z / 2.0f), true);
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
                    CreateJoint(BodyPart.LeftForearm, characterSettings.leftElbow, true);
                }
                break;
            case BodyPart.LeftForearm:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftArmSize.x, characterSettings.leftArmSize.y - characterSettings.leftElbow, characterSettings.leftArmSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.LeftHand, characterSettings.leftArmSize.y - characterSettings.leftElbow, true);
                }
                break;
            case BodyPart.LeftHand:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftHandSize.x, characterSettings.leftHandSize.y, characterSettings.leftHandSize.z, Color.yellow);
                }

                // Only create fingers if the hand size is big enough to show all of them
                if (jointPoint != null && characterSettings.leftHandSize.x >= 4)
                {
                    CreateJoint(BodyPart.LeftThumb1, 0, true);
                    CreateJoint(BodyPart.LeftIndex1, characterSettings.leftHandSize.y, true);
                    CreateJoint(BodyPart.LeftMiddle1, characterSettings.leftHandSize.y, true);
                    CreateJoint(BodyPart.LeftRing1, characterSettings.leftHandSize.y, true);
                    CreateJoint(BodyPart.LeftPinky1, characterSettings.leftHandSize.y, true);
                }
                break;

            // LEFT THUMB ---------------------------------------------
            case BodyPart.LeftThumb1:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftThumbSize.x, (int)Mathf.Ceil(characterSettings.leftThumbSize.y / 3.0f), characterSettings.leftThumbSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.LeftThumb2, (int)Mathf.Ceil(characterSettings.leftThumbSize.y / 3.0f), true);
                }
                break;
            case BodyPart.LeftThumb2:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftThumbSize.x, (int)Mathf.Ceil(characterSettings.leftThumbSize.y / 3.0f), characterSettings.leftThumbSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.LeftThumb3, (int)Mathf.Ceil(characterSettings.leftThumbSize.y / 3.0f), true);
                }
                break;
            case BodyPart.LeftThumb3:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftThumbSize.x, characterSettings.leftThumbSize.y - ((int)Mathf.Ceil(characterSettings.leftThumbSize.y / 3.0f) * 2), characterSettings.leftThumbSize.z, Color.yellow);
                }
                break;

            // LEFT INDEX FINGER ---------------------------------------------
            case BodyPart.LeftIndex1:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftIndexSize.x, (int)Mathf.Ceil(characterSettings.leftIndexSize.y / 3.0f), characterSettings.leftIndexSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.LeftIndex2, (int)Mathf.Ceil(characterSettings.leftIndexSize.y / 3.0f), true);
                }
                break;
            case BodyPart.LeftIndex2:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftIndexSize.x, (int)Mathf.Ceil(characterSettings.leftIndexSize.y / 3.0f), characterSettings.leftIndexSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.LeftIndex3, (int)Mathf.Ceil(characterSettings.leftIndexSize.y / 3.0f), true);
                }
                break;
            case BodyPart.LeftIndex3:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftIndexSize.x, characterSettings.leftIndexSize.y - ((int)Mathf.Ceil(characterSettings.leftIndexSize.y / 3.0f) * 2), characterSettings.leftIndexSize.z, Color.yellow);
                }
                break;

            // LEFT MIDDLE FINGER ---------------------------------------------
            case BodyPart.LeftMiddle1:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftMiddleSize.x, (int)Mathf.Ceil(characterSettings.leftMiddleSize.y / 3.0f), characterSettings.leftMiddleSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.LeftMiddle2, (int)Mathf.Ceil(characterSettings.leftMiddleSize.y / 3.0f), true);
                }
                break;
            case BodyPart.LeftMiddle2:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftMiddleSize.x, (int)Mathf.Ceil(characterSettings.leftMiddleSize.y / 3.0f), characterSettings.leftMiddleSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.LeftMiddle3, (int)Mathf.Ceil(characterSettings.leftMiddleSize.y / 3.0f), true);
                }
                break;
            case BodyPart.LeftMiddle3:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftMiddleSize.x, characterSettings.leftMiddleSize.y - ((int)Mathf.Ceil(characterSettings.leftMiddleSize.y / 3.0f) * 2), characterSettings.leftMiddleSize.z, Color.yellow);
                }
                break;

            // LEFT RING FINGER ---------------------------------------------
            case BodyPart.LeftRing1:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftRingSize.x, (int)Mathf.Ceil(characterSettings.leftRingSize.y / 3.0f), characterSettings.leftRingSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.LeftRing2, (int)Mathf.Ceil(characterSettings.leftRingSize.y / 3.0f), true);
                }
                break;
            case BodyPart.LeftRing2:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftRingSize.x, (int)Mathf.Ceil(characterSettings.leftRingSize.y / 3.0f), characterSettings.leftRingSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.LeftRing3, (int)Mathf.Ceil(characterSettings.leftRingSize.y / 3.0f), true);
                }
                break;
            case BodyPart.LeftRing3:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftRingSize.x, characterSettings.leftRingSize.y - ((int)Mathf.Ceil(characterSettings.leftRingSize.y / 3.0f) * 2), characterSettings.leftRingSize.z, Color.yellow);
                }
                break;

            // LEFT PINKY ---------------------------------------------
            case BodyPart.LeftPinky1:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftPinkySize.x, (int)Mathf.Ceil(characterSettings.leftPinkySize.y / 3.0f), characterSettings.leftPinkySize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.LeftPinky2, (int)Mathf.Ceil(characterSettings.leftPinkySize.y / 3.0f), true);
                }
                break;
            case BodyPart.LeftPinky2:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftPinkySize.x, (int)Mathf.Ceil(characterSettings.leftPinkySize.y / 3.0f), characterSettings.leftPinkySize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.LeftPinky3, (int)Mathf.Ceil(characterSettings.leftPinkySize.y / 3.0f), true);
                }
                break;
            case BodyPart.LeftPinky3:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftPinkySize.x, characterSettings.leftPinkySize.y - ((int)Mathf.Ceil(characterSettings.leftPinkySize.y / 3.0f) * 2), characterSettings.leftPinkySize.z, Color.yellow);
                }
                break;

            case BodyPart.RightArm:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightArmSize.x, characterSettings.rightElbow, characterSettings.rightArmSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.RightForearm, characterSettings.rightElbow, true);
                }
                break;
            case BodyPart.RightForearm:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightArmSize.x, characterSettings.rightArmSize.y - characterSettings.rightElbow, characterSettings.rightArmSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.RightHand, characterSettings.rightArmSize.y - characterSettings.rightElbow, true);
                }
                break;
            case BodyPart.RightHand:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightHandSize.x, characterSettings.rightHandSize.y, characterSettings.rightHandSize.z, Color.yellow);
                }

                // Only create fingers if the hand size is big enough to show all of them
                if (jointPoint != null && characterSettings.rightHandSize.x >= 4)
                {
                    CreateJoint(BodyPart.RightThumb1, 0, true);
                    CreateJoint(BodyPart.RightIndex1, characterSettings.rightHandSize.y, true);
                    CreateJoint(BodyPart.RightMiddle1, characterSettings.rightHandSize.y, true);
                    CreateJoint(BodyPart.RightRing1, characterSettings.rightHandSize.y, true);
                    CreateJoint(BodyPart.RightPinky1, characterSettings.rightHandSize.y, true);
                }
                break;

            // RIGHT THUMB ---------------------------------------------
            case BodyPart.RightThumb1:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightThumbSize.x, (int)Mathf.Ceil(characterSettings.rightThumbSize.y / 3.0f), characterSettings.rightThumbSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.RightThumb2, (int)Mathf.Ceil(characterSettings.rightThumbSize.y / 3.0f), true);
                }
                break;
            case BodyPart.RightThumb2:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightThumbSize.x, (int)Mathf.Ceil(characterSettings.rightThumbSize.y / 3.0f) * 2, characterSettings.rightThumbSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.RightThumb3, (int)Mathf.Ceil(characterSettings.rightThumbSize.y / 3.0f) * 2, true);
                }
                break;
            case BodyPart.RightThumb3:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightThumbSize.x, characterSettings.rightThumbSize.y - ((int)Mathf.Ceil(characterSettings.rightThumbSize.y / 3.0f) * 2), characterSettings.rightThumbSize.z, Color.yellow);
                }
                break;

            // RIGHT INDEX FINGER ---------------------------------------------
            case BodyPart.RightIndex1:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightIndexSize.x, (int)Mathf.Ceil(characterSettings.rightIndexSize.y / 3.0f), characterSettings.rightIndexSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.RightIndex2, (int)Mathf.Ceil(characterSettings.rightIndexSize.y / 3.0f), true);
                }
                break;
            case BodyPart.RightIndex2:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightIndexSize.x, (int)Mathf.Ceil(characterSettings.rightIndexSize.y / 3.0f), characterSettings.rightIndexSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.RightIndex3, (int)Mathf.Ceil(characterSettings.rightIndexSize.y / 3.0f), true);
                }
                break;
            case BodyPart.RightIndex3:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightIndexSize.x, characterSettings.rightIndexSize.y - ((int)Mathf.Ceil(characterSettings.rightIndexSize.y / 3.0f) * 2), characterSettings.rightIndexSize.z, Color.yellow);
                }
                break;

            // RIGHT MIDDLE FINGER ---------------------------------------------
            case BodyPart.RightMiddle1:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightMiddleSize.x, (int)Mathf.Ceil(characterSettings.rightMiddleSize.y / 3.0f), characterSettings.rightMiddleSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.RightMiddle2, (int)Mathf.Ceil(characterSettings.rightMiddleSize.y / 3.0f), true);
                }
                break;
            case BodyPart.RightMiddle2:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightMiddleSize.x, (int)Mathf.Ceil(characterSettings.rightMiddleSize.y / 3.0f), characterSettings.rightMiddleSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.RightMiddle3, (int)Mathf.Ceil(characterSettings.rightMiddleSize.y / 3.0f), true);
                }
                break;
            case BodyPart.RightMiddle3:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightMiddleSize.x, characterSettings.rightMiddleSize.y - ((int)Mathf.Ceil(characterSettings.rightMiddleSize.y / 3.0f) * 2), characterSettings.rightMiddleSize.z, Color.yellow);
                }
                break;

            // RIGHT RING FINGER ---------------------------------------------
            case BodyPart.RightRing1:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightRingSize.x, (int)Mathf.Ceil(characterSettings.rightRingSize.y / 3.0f), characterSettings.rightRingSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.RightRing2, (int)Mathf.Ceil(characterSettings.rightRingSize.y / 3.0f), true);
                }
                break;
            case BodyPart.RightRing2:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightRingSize.x, (int)Mathf.Ceil(characterSettings.rightRingSize.y / 3.0f), characterSettings.rightRingSize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.RightRing3, (int)Mathf.Ceil(characterSettings.rightRingSize.y / 3.0f), true);
                }
                break;
            case BodyPart.RightRing3:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightRingSize.x, characterSettings.rightRingSize.y - ((int)Mathf.Ceil(characterSettings.rightRingSize.y / 3.0f) * 2), characterSettings.rightRingSize.z, Color.yellow);
                }
                break;

            // RIGHT PINKY ---------------------------------------------
            case BodyPart.RightPinky1:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightPinkySize.x, (int)Mathf.Ceil(characterSettings.rightPinkySize.y / 3.0f), characterSettings.rightPinkySize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.RightPinky2, (int)Mathf.Ceil(characterSettings.rightPinkySize.y / 3.0f), true);
                }
                break;
            case BodyPart.RightPinky2:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightPinkySize.x, (int)Mathf.Ceil(characterSettings.rightPinkySize.y / 3.0f), characterSettings.rightPinkySize.z, Color.yellow);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.RightPinky3, (int)Mathf.Ceil(characterSettings.rightPinkySize.y / 3.0f), true);
                }
                break;
            case BodyPart.RightPinky3:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightPinkySize.x, characterSettings.rightPinkySize.y - ((int)Mathf.Ceil(characterSettings.rightPinkySize.y / 3.0f) * 2), characterSettings.rightPinkySize.z, Color.yellow);
                }
                break;

            case BodyPart.LeftUpLeg:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftLegSize.x, characterSettings.leftKnee, characterSettings.leftLegSize.z, Color.blue);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.LeftLeg, characterSettings.leftKnee, true);
                }
                break;

            case BodyPart.LeftLeg:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftLegSize.x, characterSettings.leftLegSize.y - characterSettings.leftKnee, characterSettings.leftLegSize.z, Color.blue);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.LeftFoot, characterSettings.leftLegSize.y - characterSettings.leftKnee, true);
                }
                break;

            case BodyPart.LeftFoot:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftFootSize.x, characterSettings.leftToe, characterSettings.leftFootSize.z, Color.gray);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.LeftToeBase, characterSettings.leftToe, true);
                }
                break;

            case BodyPart.LeftToeBase:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.leftFootSize.x, characterSettings.leftFootSize.y - characterSettings.leftToe, characterSettings.leftFootSize.z, Color.gray);
                }
                break;

            case BodyPart.RightUpLeg:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightLegSize.x, characterSettings.rightKnee, characterSettings.rightLegSize.z, Color.blue);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.RightLeg, characterSettings.rightKnee, true);
                }
                break;

            case BodyPart.RightLeg:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightLegSize.x, characterSettings.rightLegSize.y - characterSettings.rightKnee, characterSettings.rightLegSize.z, Color.blue);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.RightFoot, characterSettings.rightKnee, true);
                }
                break;

            case BodyPart.RightFoot:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightFootSize.x, characterSettings.rightToe, characterSettings.rightFootSize.z, Color.gray);
                }

                if (jointPoint != null)
                {
                    CreateJoint(BodyPart.RightToeBase, characterSettings.rightToe, true);
                }
                break;

            case BodyPart.RightToeBase:
                if (pixel != null)
                {
                    CreatePixelBlocks(characterSettings.rightFootSize.x, characterSettings.rightFootSize.y - characterSettings.rightToe, characterSettings.rightFootSize.z, Color.gray);
                }
                break;
        }
    }

    // Creates the pixels for the pixelation
    private void CreatePixelBlocks(int partSizeX, int partSizeY, int partSizeZ, Color pixelColor)
    {
        for (int y = 0; y < partSizeY; y++)
        {
            int xCoordinate = 0;
            int zCoordinate = 0;
            for (int x = 0; x < partSizeX; x++)
            {
                for (int z = 0; z < partSizeZ; z++)
                {
                    GameObject pixelInstance = Instantiate(pixel, transform.position, transform.rotation);
                    pixelInstance.transform.parent = transform;
                    float pixelSize = pixelInstance.transform.localScale.x;

                    float currentXPosition = 0;
                    float currentZPosition = 0;

                    // Creates the pixel blocks in a specific order.
                    // Order, based on numbers in grid:
                    // 24 | 22 | 20 | 19 | 21 | 23
                    // 12 | 10 | 08 | 07 | 09 | 11
                    // 06 | 04 | 02 | 01 | 03 | 05
                    // 18 | 16 | 14 | 13 | 15 | 17
                    // 30 | 28 | 26 | 25 | 27 | 29
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
                    //pixelInstance.GetComponent<PixelData>().currentColor = pixelColor; // TODO: Change this to get colors from draw
                    pixelInstance.GetComponent<PixelData>().pixelPosition = new Vector3(xCoordinate, y, zCoordinate);

                    if (zCoordinate == 0)
                    {
                        zCoordinate = 1;
                    }
                    else if (zCoordinate > 0)
                    {
                        zCoordinate *= -1;
                    }
                    else
                    {
                        zCoordinate = (zCoordinate - 1) * -1;
                    }
                }
                zCoordinate = 0;

                if (xCoordinate == 0)
                {
                    xCoordinate = 1;
                }
                else if (xCoordinate > 0)
                {
                    xCoordinate *= -1;
                }
                else
                {
                    xCoordinate = (xCoordinate - 1) * -1;
                }
            }
        }
    }

    // Creates a joint for the pixel body
    private void CreateJoint(BodyPart joint, float height, bool createNewJoint)
    {
        GameObject jointInstance = Instantiate(jointPoint, transform.position, transform.rotation);

        JointData jointData = jointInstance.GetComponent<JointData>();
        jointData.modelJoint = joint;
        jointData.SetRotationSource();

        MannequinPart jointMannequinPart = jointInstance.GetComponent<MannequinPart>();
        if (createNewJoint)
        {
            jointMannequinPart.pixel = pixel;
            jointMannequinPart.jointPoint = jointPoint;
        }
        jointMannequinPart.bodyPart = joint;

        // Create the joints at different locations
        jointInstance.transform.parent = transform;
        float pixelSize = jointInstance.transform.localScale.x;
        // Used to find the x-values for the middle and ring fingers
        float indexValue = 0;
        float pinkyValue = 0;
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
            case BodyPart.LeftThumb1:
                if (characterSettings.leftHandSize.x % 2 == 1) // Odd
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x + pixelSize * Mathf.Ceil(characterSettings.leftHandSize.x / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                }
                else
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x + pixelSize * Mathf.Ceil(characterSettings.leftHandSize.x / 2.0f) + (pixelSize / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                }
                break;
            case BodyPart.LeftIndex1:
                if (characterSettings.leftHandSize.x % 2 == 1) // Odd
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x + pixelSize * Mathf.Ceil(characterSettings.leftHandSize.x / 2.0f) - (pixelSize / 2) - (pixelSize * characterSettings.leftIndexSize.x / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                }
                else
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x + pixelSize * Mathf.Ceil(characterSettings.leftHandSize.x / 2.0f) - (pixelSize * characterSettings.leftIndexSize.x / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                }
                break;
            case BodyPart.LeftMiddle1:
                // Find the point which is one third of the way between the index and the pinky
                if (characterSettings.leftHandSize.x % 2 == 1) // Odd
                {
                    indexValue = jointInstance.transform.localPosition.x + pixelSize * Mathf.Ceil(characterSettings.leftHandSize.x / 2.0f) - (pixelSize / 2) - (pixelSize * characterSettings.leftIndexSize.x / 2.0f);
                    pinkyValue = jointInstance.transform.localPosition.x - pixelSize * Mathf.Ceil(characterSettings.leftHandSize.x / 2.0f) + (pixelSize / 2) + (pixelSize * characterSettings.leftIndexSize.x / 2.0f);
                }
                else
                {
                    indexValue = jointInstance.transform.localPosition.x + pixelSize * Mathf.Ceil(characterSettings.leftHandSize.x / 2.0f) - (pixelSize * characterSettings.leftIndexSize.x / 2.0f);
                    pinkyValue = jointInstance.transform.localPosition.x - pixelSize * Mathf.Ceil(characterSettings.leftHandSize.x / 2.0f) + (pixelSize * characterSettings.leftIndexSize.x / 2.0f);
                }
                jointInstance.transform.localPosition = new Vector3(2.0f / 3.0f * indexValue + 1.0f / 3.0f * pinkyValue, jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                break;
            case BodyPart.LeftRing1:
                // Find the point which is one third of the way between the pinky and the index
                if (characterSettings.leftHandSize.x % 2 == 1) // Odd
                {
                    indexValue = jointInstance.transform.localPosition.x + pixelSize * Mathf.Ceil(characterSettings.leftHandSize.x / 2.0f) - (pixelSize / 2) - (pixelSize * characterSettings.leftIndexSize.x / 2.0f);
                    pinkyValue = jointInstance.transform.localPosition.x - pixelSize * Mathf.Ceil(characterSettings.leftHandSize.x / 2.0f) + (pixelSize / 2) + (pixelSize * characterSettings.leftIndexSize.x / 2.0f);
                }
                else
                {
                    indexValue = jointInstance.transform.localPosition.x + pixelSize * Mathf.Ceil(characterSettings.leftHandSize.x / 2.0f) - (pixelSize * characterSettings.leftIndexSize.x / 2.0f);
                    pinkyValue = jointInstance.transform.localPosition.x - pixelSize * Mathf.Ceil(characterSettings.leftHandSize.x / 2.0f) + (pixelSize * characterSettings.leftIndexSize.x / 2.0f);
                }
                jointInstance.transform.localPosition = new Vector3(2.0f / 3.0f * pinkyValue + 1.0f / 3.0f * indexValue, jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                break;
            case BodyPart.LeftPinky1:
                if (characterSettings.leftHandSize.x % 2 == 1) // Odd
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x - pixelSize * Mathf.Ceil(characterSettings.leftHandSize.x / 2.0f) + (pixelSize / 2) + (pixelSize * characterSettings.leftIndexSize.x / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                }
                else
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x - pixelSize * Mathf.Ceil(characterSettings.leftHandSize.x / 2.0f) + (pixelSize * characterSettings.leftIndexSize.x / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
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
            case BodyPart.RightThumb1:
                if (characterSettings.rightHandSize.x % 2 == 1) // Odd
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x - pixelSize * Mathf.Ceil(characterSettings.rightHandSize.x / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                }
                else
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x - pixelSize * Mathf.Ceil(characterSettings.rightHandSize.x / 2.0f) - (pixelSize / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                }
                break;
            case BodyPart.RightIndex1:
                if (characterSettings.rightHandSize.x % 2 == 1) // Odd
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x - pixelSize * Mathf.Ceil(characterSettings.rightHandSize.x / 2.0f) + (pixelSize / 2) - (pixelSize * characterSettings.rightIndexSize.x / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                }
                else
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x - pixelSize * Mathf.Ceil(characterSettings.rightHandSize.x / 2.0f) + (pixelSize * characterSettings.rightIndexSize.x / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                }
                break;
            case BodyPart.RightMiddle1:
                // Find the point which is one third of the way between the index and the pinky
                if (characterSettings.rightHandSize.x % 2 == 1) // Odd
                {
                    indexValue = jointInstance.transform.localPosition.x - pixelSize * Mathf.Ceil(characterSettings.rightHandSize.x / 2.0f) + (pixelSize / 2) + (pixelSize * characterSettings.rightIndexSize.x / 2.0f);
                    pinkyValue = jointInstance.transform.localPosition.x + pixelSize * Mathf.Ceil(characterSettings.rightHandSize.x / 2.0f) - (pixelSize / 2) - (pixelSize * characterSettings.rightIndexSize.x / 2.0f);
                }
                else
                {
                    indexValue = jointInstance.transform.localPosition.x - pixelSize * Mathf.Ceil(characterSettings.rightHandSize.x / 2.0f) + (pixelSize * characterSettings.rightIndexSize.x / 2.0f);
                    pinkyValue = jointInstance.transform.localPosition.x + pixelSize * Mathf.Ceil(characterSettings.rightHandSize.x / 2.0f) - (pixelSize * characterSettings.rightIndexSize.x / 2.0f);
                }
                jointInstance.transform.localPosition = new Vector3(2.0f / 3.0f * indexValue + 1.0f / 3.0f * pinkyValue, jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                break;
            case BodyPart.RightRing1:
                // Find the point which is one third of the way between the pinky and the index
                if (characterSettings.rightHandSize.x % 2 == 1) // Odd
                {
                    indexValue = jointInstance.transform.localPosition.x - pixelSize * Mathf.Ceil(characterSettings.rightHandSize.x / 2.0f) + (pixelSize / 2) + (pixelSize * characterSettings.rightIndexSize.x / 2.0f);
                    pinkyValue = jointInstance.transform.localPosition.x + pixelSize * Mathf.Ceil(characterSettings.rightHandSize.x / 2.0f) - (pixelSize / 2) - (pixelSize * characterSettings.rightIndexSize.x / 2.0f);
                }
                else
                {
                    indexValue = jointInstance.transform.localPosition.x - pixelSize * Mathf.Ceil(characterSettings.rightHandSize.x / 2.0f) + (pixelSize * characterSettings.rightIndexSize.x / 2.0f);
                    pinkyValue = jointInstance.transform.localPosition.x + pixelSize * Mathf.Ceil(characterSettings.rightHandSize.x / 2.0f) - (pixelSize * characterSettings.rightIndexSize.x / 2.0f);
                }
                jointInstance.transform.localPosition = new Vector3(2.0f / 3.0f * pinkyValue + 1.0f / 3.0f * indexValue, jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                break;
            case BodyPart.RightPinky1:
                if (characterSettings.rightHandSize.x % 2 == 1) // Odd
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x + pixelSize * Mathf.Ceil(characterSettings.rightHandSize.x / 2.0f) - (pixelSize / 2) - (pixelSize * characterSettings.rightIndexSize.x / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
                }
                else
                {
                    jointInstance.transform.localPosition = new Vector3(jointInstance.transform.localPosition.x + pixelSize * Mathf.Ceil(characterSettings.rightHandSize.x / 2.0f) - (pixelSize * characterSettings.rightIndexSize.x / 2.0f), jointInstance.transform.localPosition.y + height * pixelSize, jointInstance.transform.localPosition.z);
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

    /// <summary>
    /// Remove the pixel blocks and joints from the scene to reduce memory usage
    /// </summary>
    public void RemovePixelsAndJoints()
    {
        if (bodyPart == BodyPart.Hips)
        {
            // First, destroy the spine and leg joints and all of their children
            GameObject[] joints = GameObject.FindGameObjectsWithTag("NewJoint");
            foreach (GameObject joint in joints)
            {
                Destroy(joint);
            }

            // Second, destroy the remaining pixel blocks
            GameObject[] pixelBlocks = GameObject.FindGameObjectsWithTag("GridTransform");
            foreach (GameObject pixelBlock in pixelBlocks)
            {
                Destroy(pixelBlock);
            }
        }
    }
}
