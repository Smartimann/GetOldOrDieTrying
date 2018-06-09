using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject ItemBeeingDragged;
    private Vector3 startPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        ItemBeeingDragged = gameObject;
        startPosition = transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ItemBeeingDragged = null;
        transform.position = startPosition;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
