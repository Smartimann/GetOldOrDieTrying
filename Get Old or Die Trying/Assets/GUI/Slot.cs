using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public GameObject item => transform.childCount > 0 ? transform.GetChild(0).gameObject : null;

    public void OnDrop(PointerEventData eventData)
    {
        if (item == null)
        {
            InventoryItem.ItemBeeingDragged.transform.SetParent(transform);
        }
    }
}
