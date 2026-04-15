using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HULoader : MonoBehaviour
{
    public GameObject botonPrefab; 
    public Transform contenedorDeBotones; 
    public HUData huData; 
    public TMP_Text descripcionText;
    private int currentHUIndex = 0;  
    private float clickTime = 0.3f;  
    private float lastClickTime = 0f;  

    private void Start()
    {
        if (huData != null && huData.listaHUs != null && huData.listaHUs.Count > 0)
        {
            ShowCurrentHU();  // Muestra la primera historia de usuario
        }
        else
        {
            Debug.LogWarning("huData o su lista de HUs es nula o vacía.");
        }
    }

    private void ShowCurrentHU()
    {
        if (currentHUIndex < huData.listaHUs.Count)
        {
            GameObject nuevoBoton = Instantiate(botonPrefab, contenedorDeBotones);
            nuevoBoton.GetComponentInChildren<TextMeshProUGUI>().text = huData.listaHUs[currentHUIndex].titulo;
            nuevoBoton.GetComponent<Button>().onClick.AddListener(() => OnClickHU(nuevoBoton, huData.listaHUs[currentHUIndex].descripcion));
        }
        else
        {
            Debug.Log("Todas las historias de usuario han sido votadas.");
        }
    }

    private void OnClickHU(GameObject botonVotado, string descripcionHU)
    {
        if (Time.time - lastClickTime < clickTime)
        {
            ShowdescriptionHU(descripcionHU); 
            botonVotado.SetActive(false);

            currentHUIndex++;

            ShowCurrentHU();
        }
        else
        {
            lastClickTime = Time.time;
            descripcionText.text = "La descripción es: " + descripcionHU;
        }
    }

    private void ShowdescriptionHU(string descripcion)
    {
        descripcionText.text = descripcion; 
        Debug.Log("Descripción de la historia de usuario: " + descripcion); 
    }
}
