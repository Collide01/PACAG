using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBorder : MonoBehaviour
{
    [SerializeField] private DrawingManager drawingManager;

    public void ChangeColliderSize()
    {
        GetComponent<BoxCollider2D>().size = GetComponent<SpriteRenderer>().size;
    }

    private void OnMouseOver()
    {
        drawingManager.mouseInBorder = true;
    }

    private void OnMouseExit()
    {
        drawingManager.mouseInBorder = false;
    }
}
