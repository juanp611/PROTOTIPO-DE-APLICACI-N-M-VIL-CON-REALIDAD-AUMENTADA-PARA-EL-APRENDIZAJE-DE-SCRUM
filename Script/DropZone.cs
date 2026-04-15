using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform droppedTask = eventData.pointerDrag.GetComponent<RectTransform>();
        droppedTask.SetParent(transform); // Mover la tarjeta al nuevo padre (la nueva columna)
        droppedTask.anchoredPosition = Vector3.zero; // Posicionarla correctamente en la columna
    }
}