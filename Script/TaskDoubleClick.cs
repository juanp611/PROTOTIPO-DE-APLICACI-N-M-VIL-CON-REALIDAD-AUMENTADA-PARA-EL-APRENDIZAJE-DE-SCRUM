using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TaskDoubleClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject detailPanel;   
    public Text detailText;          

    public GameObject todoPanel;     
    public GameObject inProgressPanel; 
    public GameObject donePanel;   
    private float clickTime = 0;
    private float clickDelay = 0.3f;

    private void Start()
    {
        if (detailPanel != null)
        {
            detailPanel.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Detectar doble clic
        if (Time.time - clickTime < clickDelay)
        {
            ShowTaskDetails(); 
        }
        clickTime = Time.time;
    }

    private void ShowTaskDetails()
    {
       if (detailPanel != null)
    {
                    detailPanel.SetActive(true);

        if (todoPanel != null) todoPanel.SetActive(false);
        if (inProgressPanel != null) inProgressPanel.SetActive(false);
        if (donePanel != null) donePanel.SetActive(false);


        }
    }

    public void CloseTaskDetails()
    {
        if (detailPanel != null)
        {
            if (todoPanel != null) todoPanel.SetActive(true);
            if (inProgressPanel != null) inProgressPanel.SetActive(true);
            if (donePanel != null) donePanel.SetActive(true);

            detailPanel.SetActive(false);
        }
    }
}