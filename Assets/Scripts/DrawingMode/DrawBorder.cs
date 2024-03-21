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
