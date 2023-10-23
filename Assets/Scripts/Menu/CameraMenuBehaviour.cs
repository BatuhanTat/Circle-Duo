using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMenuBehaviour : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] RectTransform panelTransform;


    private float panelOffsetX;
    float offsetX = 0.0f;

    private void Start()
    {
        //panelOffsetX = canvas.GetComponent<RectTransform>().rect.width * (panelTransform.anchorMax.x - panelTransform.anchorMin.x);
        panelOffsetX = panelTransform.rect.size.x - panelTransform.position.x;
    }

    public void LevelsButton()
    {
        offsetX = (offsetX == panelOffsetX) ? 0.0f : panelOffsetX;
        Debug.Log("offsetX: " + offsetX + " panelOffsetX: " + panelOffsetX);
        //panelTransform.DOLocalMoveX(offsetX, 5.0f);
        panelTransform.DOMoveX(-offsetX, 1.0f);
    }
}
