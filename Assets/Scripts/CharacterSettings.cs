using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSettings : MonoBehaviour
{
    // All of the user data about the character is held here
    public int torsoJoint1; // Spine in model (y-value in torso grid)
    public int torsoJoint2; // Spine1 in model (y-value in torso grid)
    public int torsoJoint3; // Spine2 in model (y-value in torso grid)
    public int leftElbow; // LeftForeArm in model (y-value in leftArm grid)
    public int rightElbow; // RightForeArm in model (y-value in rightArm grid)
    public int leftKnee; // LeftLeg in model (y-value in leftLeg grid)
    public int rightKnee; // RightLeg in model (y-value in rightLeg grid)
    public int leftToe; // LeftToeBase in model (y-value in leftLeg grid)
    public int rightToe; // RightToeBase in model (y-value in rightLeg grid)

    // NOTE: Normal grid scale is 0.2, and height of the torso is 8 pixels.
    public Vector3Int headSize = new Vector3Int(); // Size in pixels
    public Vector3Int torsoSize = new Vector3Int(); // Size in pixels
    public Vector3Int leftArmSize = new Vector3Int(); // Size in pixels
    public Vector3Int rightArmSize = new Vector3Int(); // Size in pixels
    public Vector3Int leftHandSize = new Vector3Int(); // Size in pixels
    public Vector3Int rightHandSize = new Vector3Int(); // Size in pixels
    public Vector3Int leftThumbSize = new Vector3Int(); // Size in pixels
    public Vector3Int rightThumbSize = new Vector3Int(); // Size in pixels
    public Vector3Int leftIndexSize = new Vector3Int(); // Size in pixels
    public Vector3Int rightIndexSize = new Vector3Int(); // Size in pixels
    public Vector3Int leftMiddleSize = new Vector3Int(); // Size in pixels
    public Vector3Int rightMiddleSize = new Vector3Int(); // Size in pixels
    public Vector3Int leftRingSize = new Vector3Int(); // Size in pixels
    public Vector3Int rightRingSize = new Vector3Int(); // Size in pixels
    public Vector3Int leftPinkySize = new Vector3Int(); // Size in pixels
    public Vector3Int rightPinkySize = new Vector3Int(); // Size in pixels
    public Vector3Int leftLegSize = new Vector3Int(); // Size in pixels
    public Vector3Int rightLegSize = new Vector3Int(); // Size in pixels
    public Vector3Int leftFootSize = new Vector3Int(); // Size in pixels
    public Vector3Int rightFootSize = new Vector3Int(); // Size in pixels

    public bool displayFingers;
    public int frameRate;
}
