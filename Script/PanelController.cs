using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject toDoPanel;       
    public GameObject inProgressPanel; 
    public GameObject detailPanel;     

    public void ShowDetailPanel()
    {
        toDoPanel.SetActive(false);          
        inProgressPanel.SetActive(false);     
        detailPanel.SetActive(true);         
    }

    public void CloseDetailPanel()
    {
        detailPanel.SetActive(false);         
        toDoPanel.SetActive(true);            
        inProgressPanel.SetActive(true);     
    }
}
