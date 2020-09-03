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

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        startposition = GetComponentInParent<RectTransform>();
        parentPosition = new Vector2(startposition.anchoredPosition.x, startposition.anchoredPosition.y);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("IBeginDragHandler");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("IDragHandler");
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("IEndDragHandler");
       // rectTransform.anchoredPosition = startposition.anchoredPosition;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");

    }

    public void OnDrop(PointerEventData eventData)
    {
        //RectTransform delta = new RectTransform();
        //delta.anchoredPosition = rectTransform.anchoredPosition - startposition.anchoredPosition;
        //rectTransform.anchoredPosition += delta.anchoredPosition;
        rectTransform.anchoredPosition = parentPosition;
        Debug.Log("onDrop" + rectTransform.anchoredPosition);
    }
}
