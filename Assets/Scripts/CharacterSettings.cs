using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSettings : MonoBehaviour
{
    // All of the user data about the character is held here
    public Dictionary<Vector3Int, Color> headGrid = new Dictionary<Vector3Int, Color>(); // HeadTop to Neck
    public Dictionary<Vector3Int, Color> torsoGrid = new Dictionary<Vector3Int, Color>(); // From Neck to Hips
    public Dictionary<Vector3Int, Color> leftArmGrid = new Dictionary<Vector3Int, Color>(); // From LeftArm to LeftHand
    public Dictionary<Vector3Int, Color> rightArmGrid = new Dictionary<Vector3Int, Color>(); // From RightArm to RightHand
    public Dictionary<Vector3Int, Color> leftHandGrid = new Dictionary<Vector3Int, Color>(); // From LeftHand to fingers
    public Dictionary<Vector3Int, Color> rightHandGrid = new Dictionary<Vector3Int, Color>(); // From RightHand to fingers
    public Dictionary<Vector3Int, Color> leftThumbGrid = new Dictionary<Vector3Int, Color>(); // Entirety of Left Thumb
    public Dictionary<Vector3Int, Color> rightThumbGrid = new Dictionary<Vector3Int, Color>(); // Entirety of Right Thumb
    public Dictionary<Vector3Int, Color> leftIndexGrid = new Dictionary<Vector3Int, Color>(); // Entirety of Left Index
    public Dictionary<Vector3Int, Color> rightIndexGrid = new Dictionary<Vector3Int, Color>(); // Entirety of Right Index
    public Dictionary<Vector3Int, Color> leftMiddleGrid = new Dictionary<Vector3Int, Color>(); // Entirety of Left Middle
    public Dictionary<Vector3Int, Color> rightMiddleGrid = new Dictionary<Vector3Int, Color>(); // Entirety of Right Middle
    public Dictionary<Vector3Int, Color> leftRingGrid = new Dictionary<Vector3Int, Color>(); // Entirety of Left Ring
    public Dictionary<Vector3Int, Color> rightRingGrid = new Dictionary<Vector3Int, Color>(); // Entirety of Right Ring
    public Dictionary<Vector3Int, Color> leftPinkyGrid = new Dictionary<Vector3Int, Color>(); // Entirety of Left Pinky
    public Dictionary<Vector3Int, Color> rightPinkyGrid = new Dictionary<Vector3Int, Color>(); // Entirety of Right Pinky
    public Dictionary<Vector3Int, Color> leftLegGrid = new Dictionary<Vector3Int, Color>(); // From LeftUpLeg to LeftFoot
    public Dictionary<Vector3Int, Color> rightLegGrid = new Dictionary<Vector3Int, Color>(); // From RightUpLeg to RightFoot
    public Dictionary<Vector3Int, Color> leftFootGrid = new Dictionary<Vector3Int, Color>(); // From LeftFoot to LeftToeEnd
    public Dictionary<Vector3Int, Color> rightFootGrid = new Dictionary<Vector3Int, Color>(); // From RightFoot to RightToeEnd
    
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

    public int frameRate;
}
