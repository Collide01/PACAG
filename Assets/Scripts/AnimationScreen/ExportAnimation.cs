using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class ExportAnimation : MonoBehaviour
{
    public Tilemap tilemap;
    /*public int spritesheetRows;
    public int spritesheetColumns;*/

    // These are used to find the max size of the sprite and the coordinates of the pixels on the tilemap
    private int minX, minY, maxX, maxY;
    private int maxSpriteSizeX;
    private int maxSpriteSizeY;

    public Pixelation pixelation;

    public void BeginExport()
    {
        // Loops through all of the tile positions for every sprite to find the maximum possible size for each sprite.
        for (int i = 0; i < pixelation.cellPositions.Count; i++) // pixelation.cellPositions.Count represents the number of frames
        {
            // Loop through each cell to determine the max and min of the width and height of sprite
            for (int j = 0; j < pixelation.cellPositions[i].Count; j++)
            {
                if (pixelation.cellPositions[i][j].x < minX)
                {
                    minX = pixelation.cellPositions[i][j].x;
                }
                if (pixelation.cellPositions[i][j].x > maxX)
                {
                    maxX = pixelation.cellPositions[i][j].x;
                }
                if (pixelation.cellPositions[i][j].y < minY)
                {
                    minY = pixelation.cellPositions[i][j].y;
                }
                if (pixelation.cellPositions[i][j].y > maxY)
                {
                    maxY = pixelation.cellPositions[i][j].y;
                }
            }

            // Checks to see if this is the biggest sprite so far
            if (maxX - minX > maxSpriteSizeX)
            {
                maxSpriteSizeX = maxX - minX;
            }
            if (maxY - minY > maxSpriteSizeY)
            {
                maxSpriteSizeY = maxY - minY;
            }
        }

        // Once the maximum size is determined, create a new Texture2D that represents the spritesheet.
        Texture2D newImage = new Texture2D(maxSpriteSizeX * pixelation.animationFrames.Count, maxSpriteSizeY);

        // Assign transparency to the whole image
        Color[] invisible = new Color[newImage.width * newImage.height];
        for (int i = 0; i < invisible.Length; i++)
        {
            invisible[i] = new Color(0f, 0f, 0f, 0f);
        }
        newImage.SetPixels(0, 0, newImage.width, newImage.height, invisible);

        // Assign each block its respective pixels
        for (int i = 0; i < pixelation.cellPositions.Count; i++)
        {
            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    if (pixelation.cellPositions[i].Contains(new Vector3Int(x, y)))
                    {
                        int index = pixelation.cellPositions[i].IndexOf(new Vector3Int(x, y));
                        newImage.SetPixel((x - minX) + maxSpriteSizeX * (i + 1), y - minY, pixelation.cellColors[i][index]);
                    }
                }
            }
        }
        newImage.Apply();
        newImage.name = "[InsertNameHere]";

        // Allow the user to save the spritesheet anywhere
        var path = EditorUtility.SaveFilePanel(
            "Save spritesheet as PNG",
            "",
            newImage.name + ".png",
            "png"
            );

        if (path.Length != 0)
        {
            var pngData = newImage.EncodeToPNG();
            File.WriteAllBytes(path, pngData);
        }
    }
}
