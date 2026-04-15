using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using Photon.Pun; 
using System.Linq;
using UnityEngine.SceneManagement;

public class PlanningPoker : MonoBehaviourPunCallbacks
{
    public Button[] pokerCards; 
    public TMP_Text timerText;   
    public TMP_Text resultText;  
    public float votingTime = 10f; 
    public HUData huData;            

    private float timeRemaining;
    private int historiaActualIndex = 0;  
    private bool votingInProgress = true;

    private void Start()
    {
        if (huData != null && huData.listaHUs != null && huData.listaHUs.Count > 0)
        {
            InicializarVotacion();
        }
        else
        {
            Debug.LogWarning("No hay historias de usuario disponibles en huData.");
        }
    }

    private void Update()
    {
        if (votingInProgress && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();
        }
        else if (timeRemaining <= 0 && votingInProgress)
        {
            StartCoroutine(MostrarResultadoYContinuar());

        }
    }

    private void InicializarVotacion()
    {
        timeRemaining = votingTime;
        votingInProgress = true;
        resultText.text = "";  
        ConfigurarBotonesDeVotacion();
    }

    private void ConfigurarBotonesDeVotacion()
    {
        foreach (Button card in pokerCards)
        {
            card.onClick.RemoveAllListeners();
            card.onClick.AddListener(() => SelectCard(card));
        }
    }

    private void SelectCard(Button selectedCard)
    {
        if (selectedCard != null && votingInProgress)
        {
            TextMeshProUGUI cardText = selectedCard.GetComponentInChildren<TextMeshProUGUI>();

            if (cardText != null && int.TryParse(cardText.text, out int cardVote))
            {
                resultText.text = "El resultado de la votación es: " + cardVote +"";
                Debug.Log("Voto registrado para la historia #" + (historiaActualIndex + 1) + ": " + cardVote);
                StartCoroutine(MostrarResultadoYContinuar()); 
            }
            else
            {
                Debug.LogError("El valor de la carta no es un número válido.");
            }
        }
    }

    private IEnumerator MostrarResultadoYContinuar()
    {
        votingInProgress = false;
        yield return new WaitForSeconds(3);  

        historiaActualIndex++;

        if (historiaActualIndex < huData.listaHUs.Count)
        {
            InicializarVotacion();  
        }
        else
        {
            SceneManager.LoadScene("tableroKanban");  
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}