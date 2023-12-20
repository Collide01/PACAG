using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSettings : MonoBehaviour
{
    // All of the user data about the character is held here
    public Dictionary<Vector3Int, Color> torsoGrid = new Dictionary<Vector3Int, Color>(); // From Neck to Hips
    public Dictionary<Vector3Int, Color> leftArmGrid = new Dictionary<Vector3Int, Color>(); // From LeftArm to LeftHand
    public Dictionary<Vector3Int, Color> rightArmGrid = new Dictionary<Vector3Int, Color>(); // From RightArm to RightHand
    public Dictionary<Vector3Int, Color> leftLegGrid = new Dictionary<Vector3Int, Color>(); // From LeftUpLeg to LeftFoot
    public Dictionary<Vector3Int, Color> rightLegGrid = new Dictionary<Vector3Int, Color>(); // From RightUpLeg to RightFoot
    public Dictionary<Vector3Int, Color> leftFootGrid = new Dictionary<Vector3Int, Color>(); // From LeftFoot to LeftToeEnd
    public Dictionary<Vector3Int, Color> rightFootGrid = new Dictionary<Vector3Int, Color>(); // From RightFoot to RightToeEnd
    public Dictionary<Vector3Int, Color> headGrid = new Dictionary<Vector3Int, Color>(); // HeadTop to Neck
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
    public Vector3Int torsoSize = new Vector3Int(); // Size in pixels
    public Vector3Int leftArmSize = new Vector3Int(); // Size in pixels
    public Vector3Int rightArmSize = new Vector3Int(); // Size in pixels
    public Vector3Int leftLegSize = new Vector3Int(); // Size in pixels
    public Vector3Int rightLegSize = new Vector3Int(); // Size in pixels
    public Vector3Int leftFootSize = new Vector3Int(); // Size in pixels
    public Vector3Int rightFootSize = new Vector3Int(); // Size in pixels
    public Vector3Int headSize = new Vector3Int(); // Size in pixels

    public int frameRate;
}
