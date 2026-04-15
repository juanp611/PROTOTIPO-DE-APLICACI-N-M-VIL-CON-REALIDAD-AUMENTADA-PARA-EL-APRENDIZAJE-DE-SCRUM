using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropTask : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        
         canvas = GetComponentInParent<Canvas>();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; 
        canvasGroup.blocksRaycasts = false; 
    }

    public void OnDrag(PointerEventData eventData)
    {
              if (canvas != null)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

    }
        


    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f; 
        canvasGroup.blocksRaycasts = true; 

 if (eventData.pointerEnter != null && eventData.pointerEnter.transform is RectTransform)
        {
            rectTransform.SetParent(eventData.pointerEnter.transform, false);
        }
        else
        {
            Debug.LogWarning("La tarjeta no fue soltada sobre un panel válido.");
        }
    }
}
