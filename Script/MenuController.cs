using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject scrumPanel;  
    public GameObject casePanel;   
    public GameObject continueButton;  


    public void OnContinueButtonClick()
    {
        scrumPanel.SetActive(false);
        continueButton.SetActive(false);
        casePanel.SetActive(true);

    }
}

