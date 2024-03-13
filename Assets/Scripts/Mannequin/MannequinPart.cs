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

    public void Init()
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
                    CreateJoint(BodyPart.LeftThumb1, characterSettings.leftHandSize.y / 2.0f, true);
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
                    CreateJoint(BodyPart.RightThumb1, characterSettings.leftHandSize.y / 2.0f, true);
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
                    CreateJoint(BodyPart.RightFoot, characterSettings.rightLegSize.y - characterSettings.rightKnee, true);
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
                    pixelInstance.GetComponent<PixelData>().pixelPosition = new Vector3Int(xCoordinate, y, zCoordinate);

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

        // Assign the associated tilemaps to each joint
        switch (jointData.modelJoint)
        {
            case BodyPart.Hips:
            case BodyPart.Spine:
            case BodyPart.Spine1:
            case BodyPart.Spine2:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().torsoTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().torsoTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().torsoTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().torsoTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().torsoTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().torsoTilemap;
                break;
            case BodyPart.Neck:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().headTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().headTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().headTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().headTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().headTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().headTilemap;
                break;
            case BodyPart.LeftArm:
            case BodyPart.LeftForearm:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().leftArmTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().leftArmTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().leftArmTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().leftArmTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().leftArmTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().leftArmTilemap;
                break;
            case BodyPart.LeftHand:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().leftHandTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().leftHandTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().leftHandTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().leftHandTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().leftHandTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().leftHandTilemap;
                break;
            case BodyPart.LeftThumb1:
            case BodyPart.LeftThumb2:
            case BodyPart.LeftThumb3:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().leftThumbTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().leftThumbTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().leftThumbTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().leftThumbTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().leftThumbTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().leftThumbTilemap;
                break;
            case BodyPart.LeftIndex1:
            case BodyPart.LeftIndex2:
            case BodyPart.LeftIndex3:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().leftIndexTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().leftIndexTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().leftIndexTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().leftIndexTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().leftIndexTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().leftIndexTilemap;
                break;
            case BodyPart.LeftMiddle1:
            case BodyPart.LeftMiddle2:
            case BodyPart.LeftMiddle3:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().leftMiddleTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().leftMiddleTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().leftMiddleTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().leftMiddleTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().leftMiddleTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().leftMiddleTilemap;
                break;
            case BodyPart.LeftRing1:
            case BodyPart.LeftRing2:
            case BodyPart.LeftRing3:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().leftRingTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().leftRingTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().leftRingTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().leftRingTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().leftRingTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().leftRingTilemap;
                break;
            case BodyPart.LeftPinky1:
            case BodyPart.LeftPinky2:
            case BodyPart.LeftPinky3:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().leftPinkyTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().leftPinkyTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().leftPinkyTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().leftPinkyTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().leftPinkyTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().leftPinkyTilemap;
                break;
            case BodyPart.RightArm:
            case BodyPart.RightForearm:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().rightArmTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().rightArmTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().rightArmTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().rightArmTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().rightArmTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().rightArmTilemap;
                break;
            case BodyPart.RightHand:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().rightHandTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().rightHandTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().rightHandTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().rightHandTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().rightHandTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().rightHandTilemap;
                break;
            case BodyPart.RightThumb1:
            case BodyPart.RightThumb2:
            case BodyPart.RightThumb3:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().rightThumbTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().rightThumbTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().rightThumbTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().rightThumbTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().rightThumbTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().rightThumbTilemap;
                break;
            case BodyPart.RightIndex1:
            case BodyPart.RightIndex2:
            case BodyPart.RightIndex3:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().rightIndexTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().rightIndexTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().rightIndexTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().rightIndexTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().rightIndexTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().rightIndexTilemap;
                break;
            case BodyPart.RightMiddle1:
            case BodyPart.RightMiddle2:
            case BodyPart.RightMiddle3:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().rightMiddleTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().rightMiddleTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().rightMiddleTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().rightMiddleTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().rightMiddleTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().rightMiddleTilemap;
                break;
            case BodyPart.RightRing1:
            case BodyPart.RightRing2:
            case BodyPart.RightRing3:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().rightRingTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().rightRingTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().rightRingTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().rightRingTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().rightRingTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().rightRingTilemap;
                break;
            case BodyPart.RightPinky1:
            case BodyPart.RightPinky2:
            case BodyPart.RightPinky3:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().rightPinkyTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().rightPinkyTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().rightPinkyTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().rightPinkyTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().rightPinkyTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().rightPinkyTilemap;
                break;
            case BodyPart.LeftUpLeg:
            case BodyPart.LeftLeg:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().leftLegTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().leftLegTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().leftLegTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().leftLegTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().leftLegTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().leftLegTilemap;
                break;
            case BodyPart.LeftFoot:
            case BodyPart.LeftToeBase:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().leftFootTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().leftFootTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().leftFootTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().leftFootTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().leftFootTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().leftFootTilemap;
                break;
            case BodyPart.RightUpLeg:
            case BodyPart.RightLeg:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().rightLegTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().rightLegTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().rightLegTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().rightLegTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().rightLegTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().rightLegTilemap;
                break;
            case BodyPart.RightFoot:
            case BodyPart.RightToeBase:
                jointData.associatedTilemapFront = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().frontGrid.GetComponent<DrawGrid>().rightFootTilemap;
                jointData.associatedTilemapBack = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().backGrid.GetComponent<DrawGrid>().rightFootTilemap;
                jointData.associatedTilemapLeft = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().leftGrid.GetComponent<DrawGrid>().rightFootTilemap;
                jointData.associatedTilemapRight = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().rightGrid.GetComponent<DrawGrid>().rightFootTilemap;
                jointData.associatedTilemapTop = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().topGrid.GetComponent<DrawGrid>().rightFootTilemap;
                jointData.associatedTilemapBottom = GameObject.FindGameObjectWithTag("DrawGrids").GetComponent<DrawingManager>().bottomGrid.GetComponent<DrawGrid>().rightFootTilemap;
                break;
        }

        // Assign the associated levels to each joint
        switch (jointData.modelJoint)
        {
            case BodyPart.Spine:
            case BodyPart.LeftForearm:
            case BodyPart.RightForearm:
            case BodyPart.LeftThumb2:
            case BodyPart.LeftIndex2:
            case BodyPart.LeftMiddle2:
            case BodyPart.LeftRing2:
            case BodyPart.LeftPinky2:
            case BodyPart.RightThumb2:
            case BodyPart.RightIndex2:
            case BodyPart.RightMiddle2:
            case BodyPart.RightRing2:
            case BodyPart.RightPinky2:
            case BodyPart.LeftLeg:
            case BodyPart.RightLeg:
            case BodyPart.LeftToeBase:
            case BodyPart.RightToeBase:
                jointData.partLevel = 1;
                break;
            case BodyPart.Spine1:
            case BodyPart.LeftThumb3:
            case BodyPart.LeftIndex3:
            case BodyPart.LeftMiddle3:
            case BodyPart.LeftRing3:
            case BodyPart.LeftPinky3:
            case BodyPart.RightThumb3:
            case BodyPart.RightIndex3:
            case BodyPart.RightMiddle3:
            case BodyPart.RightRing3:
            case BodyPart.RightPinky3:
                jointData.partLevel = 2;
                break;
            case BodyPart.Spine2:
                jointData.partLevel = 3;
                break;
        }

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

        jointMannequinPart.Init();
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
