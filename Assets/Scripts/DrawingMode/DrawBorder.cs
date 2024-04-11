using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DrawBorder : MonoBehaviour
{
    [SerializeField] private DrawingManager drawingManager;

    // Corresponding tilemaps for the body part
    [SerializeField] private Tilemap frontGridTilemap;
    [SerializeField] private Tilemap backGridTilemap;
    [SerializeField] private Tilemap leftGridTilemap;
    [SerializeField] private Tilemap rightGridTilemap;
    [SerializeField] private Tilemap topGridTilemap;
    [SerializeField] private Tilemap bottomGridTilemap;

    public void ChangeColliderSize()
    {
        GetComponent<BoxCollider2D>().size = GetComponent<SpriteRenderer>().size;
        gameObject.transform.GetChild(0).gameObject.transform.localScale = GetComponent<SpriteRenderer>().size;

        // Also change the sorting order for the sprite renderer and sprite mask
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        SpriteMask spriteMask = gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteMask>();
        switch (gameObject.transform.position.z)
        {
            case 102.7f:
                spriteRenderer.sortingOrder = 0;
                spriteMask.backSortingOrder = 0;
                frontGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 0;
                backGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 0;
                leftGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 0;
                rightGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 0;
                topGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 0;
                bottomGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 0;
                break;
            case 102.8f:
                spriteRenderer.sortingOrder = 1;
                spriteMask.backSortingOrder = 1;
                frontGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 1;
                backGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 1;
                leftGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 1;
                rightGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 1;
                topGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 1;
                bottomGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 1;
                break;
            case 102.9f:
                spriteRenderer.sortingOrder = 2;
                spriteMask.backSortingOrder = 2;
                frontGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 2;
                backGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 2;
                leftGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 2;
                rightGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 2;
                topGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 2;
                bottomGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 2;
                break;
            case 103f:
                spriteRenderer.sortingOrder = 3;
                spriteMask.backSortingOrder = 3;
                frontGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 3;
                backGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 3;
                leftGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 3;
                rightGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 3;
                topGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 3;
                bottomGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 3;
                break;
            case 103.1f:
                spriteRenderer.sortingOrder = 4;
                spriteMask.backSortingOrder = 4;
                frontGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 4;
                backGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 4;
                leftGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 4;
                rightGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 4;
                topGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 4;
                bottomGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 4;
                break;
            case 103.2f:
                spriteRenderer.sortingOrder = 5;
                spriteMask.backSortingOrder = 5;
                frontGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 5;
                backGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 5;
                leftGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 5;
                rightGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 5;
                topGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 5;
                bottomGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 5;
                break;
            case 103.3f:
                spriteRenderer.sortingOrder = 6;
                spriteMask.backSortingOrder = 6;
                frontGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 6;
                backGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 6;
                leftGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 6;
                rightGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 6;
                topGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 6;
                bottomGridTilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = 6;
                break;
        }
    }

    private void OnMouseOver()
    {
        drawingManager.mouseInBorder = true;

        // Make the user interact with the corresponding tilemap
        switch (drawingManager.currentView)
        {
            case GridViews.Front:
                drawingManager.currentTilemap = frontGridTilemap;
                break;
            case GridViews.Back:
                drawingManager.currentTilemap = backGridTilemap;
                break;
            case GridViews.Left:
                drawingManager.currentTilemap = leftGridTilemap;
                break;
            case GridViews.Right:
                drawingManager.currentTilemap = rightGridTilemap;
                break;
            case GridViews.Top:
                drawingManager.currentTilemap = topGridTilemap;
                break;
            case GridViews.Bottom:
                drawingManager.currentTilemap = bottomGridTilemap;
                break;
        }
    }

    private void OnMouseExit()
    {
        drawingManager.mouseInBorder = false;
    }

    public void ToggleView()
    {
        frontGridTilemap.gameObject.SetActive(!frontGridTilemap.gameObject.activeSelf);
        backGridTilemap.gameObject.SetActive(!backGridTilemap.gameObject.activeSelf);
        leftGridTilemap.gameObject.SetActive(!leftGridTilemap.gameObject.activeSelf);
        rightGridTilemap.gameObject.SetActive(!rightGridTilemap.gameObject.activeSelf);
        topGridTilemap.gameObject.SetActive(!topGridTilemap.gameObject.activeSelf);
        bottomGridTilemap.gameObject.SetActive(!bottomGridTilemap.gameObject.activeSelf);
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
