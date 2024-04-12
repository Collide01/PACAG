using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibilityButton : MonoBehaviour
{
    public Sprite visibleIcon;
    public Sprite invisibleIcon;

    public void ChangeIcon()
    {
        if (gameObject.GetComponent<Image>().sprite == invisibleIcon)
        {
            gameObject.GetComponent<Image>().sprite = visibleIcon;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = invisibleIcon;
        }
    }
}
