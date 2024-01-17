using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public States currentState;
    public GameObject UIStart;
    public GameObject UIDraw;
    public GameObject UIAnimate;
    public GameObject UIEdit;
    public GameObject UISave;

    // Start is called before the first frame update
    void Start()
    {
        currentState = States.Start;
        ChangeToStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToStart()
    {
        UIStart.SetActive(true);
        UIDraw.SetActive(false);
        UIAnimate.SetActive(false);
        UIEdit.SetActive(false);
        UISave.SetActive(false);
    }

    public void ChangeToDraw()
    {
        UIStart.SetActive(false);
        UIDraw.SetActive(true);
        UIAnimate.SetActive(false);
        UIEdit.SetActive(false);
        UISave.SetActive(false);
    }

    public void ChangeToAnimate()
    {
        UIStart.SetActive(false);
        UIDraw.SetActive(false);
        UIAnimate.SetActive(true);
        UIEdit.SetActive(false);
        UISave.SetActive(false);
    }

    public void ChangeToEdit()
    {
        UIStart.SetActive(false);
        UIDraw.SetActive(false);
        UIAnimate.SetActive(false);
        UIEdit.SetActive(true);
        UISave.SetActive(false);
    }

    public void ChangeToSave()
    {
        UIStart.SetActive(false);
        UIDraw.SetActive(false);
        UIAnimate.SetActive(false);
        UIEdit.SetActive(false);
        UISave.SetActive(true);
    }
}
