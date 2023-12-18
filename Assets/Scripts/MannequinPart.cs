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
    public Color partColor;

    // Start is called before the first frame update
    void Start()
    {
        characterSettings = GameObject.FindGameObjectWithTag("CharacterSettings").GetComponent<CharacterSettings>();

        // Create the PixelGrid objects and set them as children of the object

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
}
