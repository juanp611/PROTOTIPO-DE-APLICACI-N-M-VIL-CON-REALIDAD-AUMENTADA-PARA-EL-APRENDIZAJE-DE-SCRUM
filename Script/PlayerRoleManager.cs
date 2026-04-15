using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerRoleManager : MonoBehaviour
{
    public TMP_InputField playerNameInput; 
    public Button joinButton; 
    public GameObject roleAssignedPanel; 
    public TextMeshProUGUI messageText; 
    public GameObject caseDisplayPanel; 
    public GameObject panelIngreso; 

    private const int maxPlayers = 5; 
    private List<string> playerNames = new List<string>();

    private void Start()
    {
        if (joinButton != null)
        {
            joinButton.onClick.AddListener(OnJoinButtonClicked);
        }

        if (caseDisplayPanel != null)
        {
            caseDisplayPanel.SetActive(false);
        }

        if (panelIngreso != null)
        {
            panelIngreso.SetActive(true);
        }
    }

    private void OnJoinButtonClicked()
    {
        if (playerNameInput == null || messageText == null || roleAssignedPanel == null || panelIngreso == null)
        {
            Debug.LogError("Algunos componentes de UI no están asignados en el Inspector.");
            return; 
        }

        string playerName = playerNameInput.text;
        if (string.IsNullOrEmpty(playerName))
        {
            messageText.text = "Por favor, ingrese un nombre.";
            roleAssignedPanel.SetActive(true);
            return;
        }

        if (playerNames.Count >= maxPlayers)
        {
            messageText.text = "El equipo está completo. No se pueden unir más jugadores.";
            roleAssignedPanel.SetActive(true);
            return;
        }

        playerNames.Add(playerName);
        messageText.text = $"{playerName} ha sido asignado como Scrum master del equipo.";
        roleAssignedPanel.SetActive(true);

        Debug.Log($"{playerName} ha sido asignado como Scrum master del equipo.");

        if (panelIngreso != null)
        {
            panelIngreso.SetActive(false);
        }

        StartCoroutine(HideRoleAssignedPanel());
    }

    private IEnumerator HideRoleAssignedPanel()
    {
        yield return new WaitForSeconds(3f);

        if (roleAssignedPanel != null)
        {
            roleAssignedPanel.SetActive(false);
        }

        if (caseDisplayPanel != null)
        {
            caseDisplayPanel.SetActive(true);
        }
    }
}