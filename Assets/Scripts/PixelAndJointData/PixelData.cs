using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelData : MonoBehaviour
{
    public Color pixelColorFront;
    public Color pixelColorBack;
    public Color pixelColorLeft;
    public Color pixelColorRight;
    public Color pixelColorTop;
    public Color pixelColorBottom;
    private Color currentColor;
    public Vector3Int pixelPosition;

    // Gets the adjacent pixels on ewach side of this pixel
    public PixelData frontPixelData;
    public PixelData backPixelData;
    public PixelData leftPixelData;
    public PixelData rightPixelData;
    public PixelData topPixelData;
    public PixelData bottomPixelData;

    private void Start()
    {
        CharacterSettings characterSettings = GameObject.FindGameObjectWithTag("CharacterSettings").GetComponent<CharacterSettings>();
        // Sets the associated colors from the drawing tilemaps
        JointData parentJoint = transform.parent.GetComponent<JointData>();
        int additionalPixel = 0;
        switch (parentJoint.modelJoint)
        {
            case BodyPart.Hips:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                break;
            case BodyPart.Spine:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.torsoJoint1, 0)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.torsoJoint1, 0));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.torsoJoint1, 0)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.torsoJoint1, 0));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(0, pixelPosition.y + characterSettings.torsoJoint1, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(0, pixelPosition.y + characterSettings.torsoJoint1, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(0, pixelPosition.y + characterSettings.torsoJoint1, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(0, pixelPosition.y + characterSettings.torsoJoint1, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                break;
            case BodyPart.Spine1:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.torsoJoint2, 0)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.torsoJoint2, 0));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.torsoJoint2, 0)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.torsoJoint2, 0));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(0, pixelPosition.y + characterSettings.torsoJoint2, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(0, pixelPosition.y + characterSettings.torsoJoint2, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(0, pixelPosition.y + characterSettings.torsoJoint2, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(0, pixelPosition.y + characterSettings.torsoJoint2, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                break;
            case BodyPart.Spine2:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.torsoJoint3, 0)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.torsoJoint3, 0));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.torsoJoint3, 0)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.torsoJoint3, 0));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(0, pixelPosition.y + characterSettings.torsoJoint3, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(0, pixelPosition.y + characterSettings.torsoJoint3, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(0, pixelPosition.y + characterSettings.torsoJoint3, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(0, pixelPosition.y + characterSettings.torsoJoint3, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                break;
            case BodyPart.Neck:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                break;
            case BodyPart.LeftArm:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                break;
            case BodyPart.LeftForearm:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + characterSettings.leftElbow, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + characterSettings.leftElbow, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + characterSettings.leftElbow, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + characterSettings.leftElbow, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.leftElbow, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.leftElbow, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.leftElbow, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.leftElbow, 0));
                }
                break;
            case BodyPart.LeftHand:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                break;
            case BodyPart.LeftThumb1:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                break;
            case BodyPart.LeftThumb2:
                // Divide the pixels between each joint of the finger
                if (characterSettings.leftThumbSize.y % 3 != 0) additionalPixel = 1;
                else additionalPixel = 0;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftThumbSize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftThumbSize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftThumbSize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftThumbSize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftThumbSize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftThumbSize.y / 3.0f) + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftThumbSize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftThumbSize.y / 3.0f) + additionalPixel, 0));
                }
                break;
            case BodyPart.LeftThumb3:
                // Divide the pixels between each joint of the finger
                additionalPixel = characterSettings.leftThumbSize.y % 3;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftThumbSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftThumbSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftThumbSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftThumbSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftThumbSize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftThumbSize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftThumbSize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftThumbSize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                break;
            case BodyPart.LeftIndex1:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                break;
            case BodyPart.LeftIndex2:
                // Divide the pixels between each joint of the finger
                if (characterSettings.leftIndexSize.y % 3 != 0) additionalPixel = 1;
                else additionalPixel = 0;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftIndexSize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftIndexSize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftIndexSize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftIndexSize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftIndexSize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftIndexSize.y / 3.0f) + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftIndexSize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftIndexSize.y / 3.0f) + additionalPixel, 0));
                }
                break;
            case BodyPart.LeftIndex3:
                // Divide the pixels between each joint of the finger
                additionalPixel = characterSettings.leftIndexSize.y % 3;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftIndexSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftIndexSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftIndexSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftIndexSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftIndexSize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftIndexSize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftIndexSize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftIndexSize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                break;
            case BodyPart.LeftMiddle1:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                break;
            case BodyPart.LeftMiddle2:
                // Divide the pixels between each joint of the finger
                if (characterSettings.leftMiddleSize.y % 3 != 0) additionalPixel = 1;
                else additionalPixel = 0;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftMiddleSize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftMiddleSize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftMiddleSize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftMiddleSize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftMiddleSize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftMiddleSize.y / 3.0f) + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftMiddleSize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftMiddleSize.y / 3.0f) + additionalPixel, 0));
                }
                break;
            case BodyPart.LeftMiddle3:
                // Divide the pixels between each joint of the finger
                additionalPixel = characterSettings.leftMiddleSize.y % 3;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftMiddleSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftMiddleSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftMiddleSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftMiddleSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftMiddleSize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftMiddleSize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftMiddleSize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftMiddleSize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                break;
            case BodyPart.LeftRing1:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                break;
            case BodyPart.LeftRing2:
                // Divide the pixels between each joint of the finger
                if (characterSettings.leftRingSize.y % 3 != 0) additionalPixel = 1;
                else additionalPixel = 0;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftRingSize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftRingSize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftRingSize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftRingSize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftRingSize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftRingSize.y / 3.0f) + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftRingSize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftRingSize.y / 3.0f) + additionalPixel, 0));
                }
                break;
            case BodyPart.LeftRing3:
                // Divide the pixels between each joint of the finger
                additionalPixel = characterSettings.leftRingSize.y % 3;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftRingSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftRingSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftRingSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftRingSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftRingSize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftRingSize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftRingSize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftRingSize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                break;
            case BodyPart.LeftPinky1:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                break;
            case BodyPart.LeftPinky2:
                // Divide the pixels between each joint of the finger
                if (characterSettings.leftPinkySize.y % 3 != 0) additionalPixel = 1;
                else additionalPixel = 0;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftPinkySize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftPinkySize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftPinkySize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftPinkySize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftPinkySize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftPinkySize.y / 3.0f) + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftPinkySize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftPinkySize.y / 3.0f) + additionalPixel, 0));
                }
                break;
            case BodyPart.LeftPinky3:
                // Divide the pixels between each joint of the finger
                additionalPixel = characterSettings.leftPinkySize.y % 3;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftPinkySize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftPinkySize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftPinkySize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftPinkySize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftPinkySize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftPinkySize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftPinkySize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.leftPinkySize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                break;
            case BodyPart.RightArm:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                break;
            case BodyPart.RightForearm:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + characterSettings.rightElbow, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + characterSettings.rightElbow, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + characterSettings.rightElbow, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + characterSettings.rightElbow, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.rightElbow, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.rightElbow, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.rightElbow, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.rightElbow, 0));
                }
                break;
            case BodyPart.RightHand:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                break;
            case BodyPart.RightThumb1:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                break;
            case BodyPart.RightThumb2:
                // Divide the pixels between each joint of the finger
                if (characterSettings.rightThumbSize.y % 3 != 0) additionalPixel = 1;
                else additionalPixel = 0;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightThumbSize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightThumbSize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightThumbSize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightThumbSize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightThumbSize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightThumbSize.y / 3.0f) + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightThumbSize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightThumbSize.y / 3.0f) + additionalPixel, 0));
                }
                break;
            case BodyPart.RightThumb3:
                // Divide the pixels between each joint of the finger
                additionalPixel = characterSettings.rightThumbSize.y % 3;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightThumbSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightThumbSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightThumbSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightThumbSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightThumbSize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightThumbSize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightThumbSize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightThumbSize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                break;
            case BodyPart.RightIndex1:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                break;
            case BodyPart.RightIndex2:
                // Divide the pixels between each joint of the finger
                if (characterSettings.rightIndexSize.y % 3 != 0) additionalPixel = 1;
                else additionalPixel = 0;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightIndexSize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightIndexSize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightIndexSize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightIndexSize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightIndexSize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightIndexSize.y / 3.0f) + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightIndexSize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightIndexSize.y / 3.0f) + additionalPixel, 0));
                }
                break;
            case BodyPart.RightIndex3:
                // Divide the pixels between each joint of the finger
                additionalPixel = characterSettings.rightIndexSize.y % 3;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightIndexSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightIndexSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightIndexSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightIndexSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightIndexSize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightIndexSize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightIndexSize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightIndexSize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                break;
            case BodyPart.RightMiddle1:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                break;
            case BodyPart.RightMiddle2:
                // Divide the pixels between each joint of the finger
                if (characterSettings.rightMiddleSize.y % 3 != 0) additionalPixel = 1;
                else additionalPixel = 0;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightMiddleSize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightMiddleSize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightMiddleSize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightMiddleSize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightMiddleSize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightMiddleSize.y / 3.0f) + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightMiddleSize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightMiddleSize.y / 3.0f) + additionalPixel, 0));
                }
                break;
            case BodyPart.RightMiddle3:
                // Divide the pixels between each joint of the finger
                additionalPixel = characterSettings.rightMiddleSize.y % 3;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightMiddleSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightMiddleSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightMiddleSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightMiddleSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightMiddleSize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightMiddleSize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightMiddleSize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightMiddleSize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                break;
            case BodyPart.RightRing1:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                break;
            case BodyPart.RightRing2:
                // Divide the pixels between each joint of the finger
                if (characterSettings.rightRingSize.y % 3 != 0) additionalPixel = 1;
                else additionalPixel = 0;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightRingSize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightRingSize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightRingSize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightRingSize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightRingSize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightRingSize.y / 3.0f) + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightRingSize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightRingSize.y / 3.0f) + additionalPixel, 0));
                }
                break;
            case BodyPart.RightRing3:
                // Divide the pixels between each joint of the finger
                additionalPixel = characterSettings.rightRingSize.y % 3;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightRingSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightRingSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightRingSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightRingSize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightRingSize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightRingSize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightRingSize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightRingSize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                break;
            case BodyPart.RightPinky1:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                break;
            case BodyPart.RightPinky2:
                // Divide the pixels between each joint of the finger
                if (characterSettings.rightPinkySize.y % 3 != 0) additionalPixel = 1;
                else additionalPixel = 0;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightPinkySize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightPinkySize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightPinkySize.y / 3.0f) + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightPinkySize.y / 3.0f) + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightPinkySize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightPinkySize.y / 3.0f) + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightPinkySize.y / 3.0f) + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightPinkySize.y / 3.0f) + additionalPixel, 0));
                }
                break;
            case BodyPart.RightPinky3:
                // Divide the pixels between each joint of the finger
                additionalPixel = characterSettings.rightPinkySize.y % 3;

                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightPinkySize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightPinkySize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightPinkySize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(0, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightPinkySize.y / 3.0f) * 2 + additionalPixel, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightPinkySize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightPinkySize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightPinkySize.y / 3.0f) * 2 + additionalPixel, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + (int)Mathf.Floor(characterSettings.rightPinkySize.y / 3.0f) * 2 + additionalPixel, 0));
                }
                break;
            case BodyPart.LeftUpLeg:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                break;
            case BodyPart.LeftLeg:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.leftKnee, 0)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.leftKnee, 0));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.leftKnee, 0)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.leftKnee, 0));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(0, pixelPosition.y + characterSettings.leftKnee, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(0, pixelPosition.y + characterSettings.leftKnee, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(0, pixelPosition.y + characterSettings.leftKnee, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(0, pixelPosition.y + characterSettings.leftKnee, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                break;
            case BodyPart.LeftFoot:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                break;
            case BodyPart.LeftToeBase:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(0, pixelPosition.y + characterSettings.leftToe, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(0, pixelPosition.y + characterSettings.leftToe, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(0, pixelPosition.y + characterSettings.leftToe, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(0, pixelPosition.y + characterSettings.leftToe, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.leftToe, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.leftToe, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.leftToe, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.leftToe, 0));
                }
                break;
            case BodyPart.RightUpLeg:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                break;
            case BodyPart.RightLeg:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.rightKnee, 0)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.rightKnee, 0));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.rightKnee, 0)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.rightKnee, 0));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(0, pixelPosition.y + characterSettings.rightKnee, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(0, pixelPosition.y + characterSettings.rightKnee, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(0, pixelPosition.y + characterSettings.rightKnee, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(0, pixelPosition.y + characterSettings.rightKnee, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                break;
            case BodyPart.RightFoot:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(0, pixelPosition.y, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(0, pixelPosition.y, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y, 0));
                }
                break;
            case BodyPart.RightToeBase:
                if (parentJoint.associatedTilemapFront.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorFront = parentJoint.associatedTilemapFront.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapBack.HasTile(new Vector3Int(pixelPosition.x, 0, pixelPosition.z)))
                {
                    pixelColorBack = parentJoint.associatedTilemapBack.GetColor(new Vector3Int(pixelPosition.x, 0, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapLeft.HasTile(new Vector3Int(0, pixelPosition.y + characterSettings.rightToe, pixelPosition.z)))
                {
                    pixelColorLeft = parentJoint.associatedTilemapLeft.GetColor(new Vector3Int(0, pixelPosition.y + characterSettings.rightToe, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapRight.HasTile(new Vector3Int(0, pixelPosition.y + characterSettings.rightToe, pixelPosition.z)))
                {
                    pixelColorRight = parentJoint.associatedTilemapRight.GetColor(new Vector3Int(0, pixelPosition.y + characterSettings.rightToe, pixelPosition.z));
                }
                if (parentJoint.associatedTilemapTop.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.rightToe, 0)))
                {
                    pixelColorTop = parentJoint.associatedTilemapTop.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.rightToe, 0));
                }
                if (parentJoint.associatedTilemapBottom.HasTile(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.rightToe, 0)))
                {
                    pixelColorBottom = parentJoint.associatedTilemapBottom.GetColor(new Vector3Int(pixelPosition.x, pixelPosition.y + characterSettings.rightToe, 0));
                }
                break;
        }

        if (pixelColorFront.a == 0 || pixelColorBack.a == 0 || pixelColorLeft.a == 0 || pixelColorRight.a == 0 || pixelColorTop.a == 0 || pixelColorBottom.a == 0)
        {
            Destroy(gameObject);
        }
    }

    public Color GetColor()
    {
        JointData parentJoint = transform.parent.GetComponent<JointData>();
        GridViews firstDirection = parentJoint.GetFaceToward()[0];
        GridViews secondDirection = parentJoint.GetFaceToward()[1];
        GridViews thirdDirection = parentJoint.GetFaceToward()[2];

        // This variable tracks whether the pixel's color will be the first, second, or third one
        int directionLevel = 1;

        switch (firstDirection)
        {
            case GridViews.Front:
                if (frontPixelData != null && frontPixelData.pixelColorFront.a != 0)
                {
                    directionLevel = 2;
                }
                else
                {
                    currentColor = pixelColorFront;
                }
                break;
            case GridViews.Back:
                if (backPixelData != null && backPixelData.pixelColorBack.a != 0)
                {
                    directionLevel = 2;
                }
                else
                {
                    currentColor = pixelColorBack;
                }
                break;
            case GridViews.Left:
                if (leftPixelData != null && leftPixelData.pixelColorLeft.a != 0)
                {
                    directionLevel = 2;
                }
                else
                {
                    currentColor = pixelColorLeft;
                }
                break;
            case GridViews.Right:
                if (rightPixelData != null && rightPixelData.pixelColorRight.a != 0)
                {
                    directionLevel = 2;
                }
                else
                {
                    currentColor = pixelColorRight;
                }
                break;
            case GridViews.Top:
                if (topPixelData != null && topPixelData.pixelColorTop.a != 0)
                {
                    directionLevel = 2;
                }
                else
                {
                    currentColor = pixelColorTop;
                }
                break;
            case GridViews.Bottom:
                if (bottomPixelData != null && bottomPixelData.pixelColorBottom.a != 0)
                {
                    directionLevel = 2;
                }
                else
                {
                    currentColor = pixelColorBottom;
                }
                break;
        }

        if (directionLevel == 2)
        {
            switch (secondDirection)
            {
                case GridViews.Front:
                    if (frontPixelData != null && frontPixelData.pixelColorFront.a != 0)
                    {
                        directionLevel = 3;
                    }
                    else
                    {
                        currentColor = pixelColorFront;
                    }
                    break;
                case GridViews.Back:
                    if (backPixelData != null && backPixelData.pixelColorBack.a != 0)
                    {
                        directionLevel = 3;
                    }
                    else
                    {
                        currentColor = pixelColorBack;
                    }
                    break;
                case GridViews.Left:
                    if (leftPixelData != null && leftPixelData.pixelColorLeft.a != 0)
                    {
                        directionLevel = 3;
                    }
                    else
                    {
                        currentColor = pixelColorLeft;
                    }
                    break;
                case GridViews.Right:
                    if (rightPixelData != null && rightPixelData.pixelColorRight.a != 0)
                    {
                        directionLevel = 3;
                    }
                    else
                    {
                        currentColor = pixelColorRight;
                    }
                    break;
                case GridViews.Top:
                    if (topPixelData != null && topPixelData.pixelColorTop.a != 0)
                    {
                        directionLevel = 3;
                    }
                    else
                    {
                        currentColor = pixelColorTop;
                    }
                    break;
                case GridViews.Bottom:
                    if (bottomPixelData != null && bottomPixelData.pixelColorBottom.a != 0)
                    {
                        directionLevel = 3;
                    }
                    else
                    {
                        currentColor = pixelColorBottom;
                    }
                    break;
            }
        }

        if (directionLevel == 3)
        {
            switch (thirdDirection)
            {
                case GridViews.Front:
                    currentColor = pixelColorFront;
                    break;
                case GridViews.Back:
                    currentColor = pixelColorBack;
                    break;
                case GridViews.Left:
                    currentColor = pixelColorLeft;
                    break;
                case GridViews.Right:
                    currentColor = pixelColorRight;
                    break;
                case GridViews.Top:
                    currentColor = pixelColorTop;
                    break;
                case GridViews.Bottom:
                    currentColor = pixelColorBottom;
                    break;
            }
        }

        return currentColor;
    }
}
