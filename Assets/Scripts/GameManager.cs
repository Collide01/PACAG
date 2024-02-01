using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public States currentState;
    public GameObject uiStart;
    public GameObject uiDraw;
    public GameObject uiAnimate;
    public GameObject uiEdit;
    public GameObject uiSave;

    public GameObject drawGrids;
    public GameObject transparencyBackground;
    public GameObject mannequin;

    private DrawingManager drawingManager;

    // Start is called before the first frame update
    void Start()
    {
        drawingManager = drawGrids.GetComponent<DrawingManager>();
        currentState = States.Start;
        ChangeToStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToStart()
    {
        uiStart.SetActive(true);
        uiDraw.SetActive(false);
        uiAnimate.SetActive(false);
        uiEdit.SetActive(false);
        uiSave.SetActive(false);

        drawGrids.SetActive(false);
        transparencyBackground.SetActive(false);
        mannequin.SetActive(false);
    }

    public void ChangeToDraw()
    {
        uiStart.SetActive(false);
        uiDraw.SetActive(true);
        uiAnimate.SetActive(false);
        uiEdit.SetActive(false);
        uiSave.SetActive(false);

        drawGrids.SetActive(true);
        transparencyBackground.SetActive(true);
        mannequin.SetActive(false);

        drawingManager.Init();
    }

    public void ChangeToAnimate()
    {
        uiStart.SetActive(false);
        uiDraw.SetActive(false);
        uiAnimate.SetActive(true);
        uiEdit.SetActive(false);
        uiSave.SetActive(false);

        drawGrids.SetActive(false);
        transparencyBackground.SetActive(false);
        mannequin.SetActive(true);
    }

    public void ChangeToEdit()
    {
        uiStart.SetActive(false);
        uiDraw.SetActive(false);
        uiAnimate.SetActive(false);
        uiEdit.SetActive(true);
        uiSave.SetActive(false);

        drawGrids.SetActive(false);
        transparencyBackground.SetActive(false);
        mannequin.SetActive(false);
    }

    public void ChangeToSave()
    {
        uiStart.SetActive(false);
        uiDraw.SetActive(false);
        uiAnimate.SetActive(false);
        uiEdit.SetActive(false);
        uiSave.SetActive(true);

        drawGrids.SetActive(false);
        transparencyBackground.SetActive(false);
        mannequin.SetActive(false);
    }
}
