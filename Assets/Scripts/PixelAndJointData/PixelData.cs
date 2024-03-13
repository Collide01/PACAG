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

    private void Start()
    {
        CharacterSettings characterSettings = GameObject.FindGameObjectWithTag("CharacterSettings").GetComponent<CharacterSettings>();
        // Sets the associated colors from the drawing tilemaps
        JointData parentJoint = transform.parent.GetComponent<JointData>();
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
            case BodyPart.LeftForearm:
                
                break;
            case BodyPart.LeftHand:
                
                break;
            case BodyPart.LeftThumb1:
            case BodyPart.LeftThumb2:
            case BodyPart.LeftThumb3:
            case BodyPart.LeftThumb4:
                
                break;
            case BodyPart.LeftIndex1:
            case BodyPart.LeftIndex2:
            case BodyPart.LeftIndex3:
            case BodyPart.LeftIndex4:
                
                break;
            case BodyPart.LeftMiddle1:
            case BodyPart.LeftMiddle2:
            case BodyPart.LeftMiddle3:
            case BodyPart.LeftMiddle4:
                
                break;
            case BodyPart.LeftRing1:
            case BodyPart.LeftRing2:
            case BodyPart.LeftRing3:
            case BodyPart.LeftRing4:
                
                break;
            case BodyPart.LeftPinky1:
            case BodyPart.LeftPinky2:
            case BodyPart.LeftPinky3:
            case BodyPart.LeftPinky4:
                
                break;
            case BodyPart.RightArm:
            case BodyPart.RightForearm:
                
                break;
            case BodyPart.RightHand:
                
                break;
            case BodyPart.RightThumb1:
            case BodyPart.RightThumb2:
            case BodyPart.RightThumb3:
            case BodyPart.RightThumb4:
                
                break;
            case BodyPart.RightIndex1:
            case BodyPart.RightIndex2:
            case BodyPart.RightIndex3:
            case BodyPart.RightIndex4:
                
                break;
            case BodyPart.RightMiddle1:
            case BodyPart.RightMiddle2:
            case BodyPart.RightMiddle3:
            case BodyPart.RightMiddle4:
                
                break;
            case BodyPart.RightRing1:
            case BodyPart.RightRing2:
            case BodyPart.RightRing3:
            case BodyPart.RightRing4:
                
                break;
            case BodyPart.RightPinky1:
            case BodyPart.RightPinky2:
            case BodyPart.RightPinky3:
            case BodyPart.RightPinky4:
                
                break;
            case BodyPart.LeftUpLeg:
            case BodyPart.LeftLeg:
                
                break;
            case BodyPart.LeftFoot:
            case BodyPart.LeftToeBase:
                
                break;
            case BodyPart.RightUpLeg:
            case BodyPart.RightLeg:
                
                break;
            case BodyPart.RightFoot:
            case BodyPart.RightToeBase:
                
                break;
        }
    }

    public Color GetColor()
    {
        JointData parentJoint = transform.parent.GetComponent<JointData>();
        GridViews currentDirection = parentJoint.GetFaceToward();
        switch (currentDirection)
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
        return currentColor;
    }
}
