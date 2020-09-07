using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler,IEndDragHandler,IDragHandler,IDropHandler  
{
    private RectTransform rectTransform;
    private RectTransform startposition;
    private Vector2 parentPosition;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        startposition = GetComponentInParent<RectTransform>();
        parentPosition = new Vector2(startposition.anchoredPosition.x, startposition.anchoredPosition.y);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("IBeginDragHandler");
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("IDragHandler");
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("IEndDragHandler");
        canvasGroup.blocksRaycasts = true;

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");

    }

    public void OnDrop(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = parentPosition;
        Debug.Log("onDrop" + rectTransform.anchoredPosition);
    }
}
