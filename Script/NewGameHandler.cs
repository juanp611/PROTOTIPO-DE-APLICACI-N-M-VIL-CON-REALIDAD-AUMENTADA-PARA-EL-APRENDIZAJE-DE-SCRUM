using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Si usas TextMeshPro

public class NewGameHandler : MonoBehaviour
{
    public GameObject startMessage;
    public GameObject mainMenu;
    public GameObject continueButton;

    public void OnNewGameSelected()
    {
        
        if (mainMenu != null)
        {
            mainMenu.SetActive(false);  
        }
        if (startMessage != null)
        {
            startMessage.SetActive(true);  
        }
       if (continueButton != null)
        {
            continueButton.SetActive(true);  
        }
    
    }
    public void OnContinueSelected()
    {
        if (startMessage != null)
        {
            startMessage.SetActive(false);  
        }

        if (continueButton != null)
        {
            continueButton.SetActive(false);  
        }
    } 
    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(5); 
        startMessage.SetActive(false); 
    }
}

