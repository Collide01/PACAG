using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MannequinPart : MonoBehaviour
{
    public GridLayout pixelGrid;
    public Tilemap pixelTilemap;
    public Pixelation pixelation;

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

    // Start is called before the first frame update
    void Start()
    {
        Vector3Int cellPosition = pixelGrid.WorldToCell(transform.position);
        pixelation.SetTileColor(Color.blue, cellPosition, pixelTilemap);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
