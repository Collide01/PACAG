using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DrawSprite : MonoBehaviour
{
    [HideInInspector] public GameObject[] pixelLocations;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Gets the pixel objects and draws sprites in them in order based on their z-positions
        // This makes it so pixels in the back are drawn first so pixels in the front draw over it.
        pixelLocations = GameObject.FindGameObjectsWithTag("GridTransform");
        System.Array.Sort(pixelLocations, ZPositionComparison);
        foreach (GameObject pixel in pixelLocations)
        {

        }
    }

    private int ZPositionComparison(GameObject a, GameObject b)
    {
        //null check, I consider nulls to be less than non-null
        if (a == null) return (b == null) ? 0 : -1;
        if (b == null) return 1;

        var za = a.transform.position.z;
        var zb = b.transform.position.z;
        return za.CompareTo(zb); //here I use the default comparison of floats
    }
}
