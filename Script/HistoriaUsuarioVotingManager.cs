using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Para usar TextMeshPro
using UnityEngine.UI;

public class HistoriaUsuarioVotingManager : MonoBehaviour
{
    public GameObject botonPrefab;
    public Transform contenedorDeBotones;
    public HUData huData;
    public TMP_Text historiaTituloText;
    public TMP_Text historiaDescripcionText;
    public GameObject votarPanel;
    public Button[] pokerCards;

    private int historiaActualIndex = 0;
    private List<int> votos = new List<int>();

    private void Start()
    {
        if (huData != null && huData.listaHUs != null && huData.listaHUs.Count > 0)
        {
            MostrarHistoriaActual();
        }
        else
        {
            Debug.LogWarning("huData o su lista de HUs es nula. Asegúrate de asignar el ScriptableObject.");
        }
    }

    private void MostrarHistoriaActual()
    {
        if (historiaActualIndex < huData.listaHUs.Count)
        {
            // Mostrar el título y descripción de la historia actual
            HU historiaActual = huData.listaHUs[historiaActualIndex];
            historiaTituloText.text = historiaActual.titulo;
            historiaDescripcionText.text = historiaActual.descripcion;
            votarPanel.SetActive(true); // Mostrar panel de votación

            // Configurar los botones de votación para la historia actual
            ConfigurarBotonesDeVotacion();
        }
        else
        {
            // Si ya no hay más historias, ir a la escena "tableroKanban"
            SceneManager.LoadScene("tableroKanban");
        }
    }

    private void ConfigurarBotonesDeVotacion()
    {
        foreach (Button card in pokerCards)
        {
            card.onClick.RemoveAllListeners(); // Limpiar listeners previos
            card.onClick.AddListener(() => SeleccionarCarta(card));
        }
    }

    private void SeleccionarCarta(Button cardSeleccionada)
    {
        TextMeshProUGUI cardText = cardSeleccionada.GetComponentInChildren<TextMeshProUGUI>();
        
        if (cardText != null)
        {
            int voto = int.Parse(cardText.text); // Convertir valor de la carta a entero
            votos.Add(voto); // Registrar el voto
            Debug.Log("Voto registrado para historia: " + huData.listaHUs[historiaActualIndex].titulo + " con valor: " + voto);

            // Pasar a la siguiente historia
            historiaActualIndex++;
            MostrarHistoriaActual();
        }
        else
        {
            Debug.LogError("No se encontró el componente TextMeshProUGUI en la carta seleccionada.");
        }
    }
}