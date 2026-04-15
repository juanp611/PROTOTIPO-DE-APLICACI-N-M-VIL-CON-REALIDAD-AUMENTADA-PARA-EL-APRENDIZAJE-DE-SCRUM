using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;
using Photon.Pun;

public class HUManager : MonoBehaviourPunCallbacks
{
    public GameObject botonPrefab; 
    public Transform contenedorDeBotones; 
    public TMP_InputField inputTitulo; 
    public TMP_InputField inputDescripcion; 
    public HUData huData; 


    public List<HU> listaHUs = new List<HU>();

public void CreateHU()
    {
        string titulo = inputTitulo.text;
        string descripcion = inputDescripcion.text;

        if (!string.IsNullOrEmpty(titulo) && !string.IsNullOrEmpty(descripcion))
        {
            HU nuevaHU = new HU(titulo, descripcion);
            listaHUs.Add(nuevaHU);

            // Desactiva el prefab original si es necesario
            botonPrefab.SetActive(false);  // Esto ocultará el prefab original en la escena

            // Crea el nuevo botón con los datos de la HU
            GameObject nuevoBoton = Instantiate(botonPrefab, contenedorDeBotones);
            nuevoBoton.SetActive(true);  // Hacemos visible el nuevo botón

            nuevoBoton.GetComponentInChildren<TextMeshProUGUI>().text = nuevaHU.titulo; // Cambiado a TextMeshProUGUI

            nuevoBoton.GetComponent<Button>().onClick.AddListener(() => ShowdescriptionHU(nuevaHU.descripcion));
        }
    }

    private void ShowdescriptionHU(string descripcion)
    {
        Debug.Log("Descripción de HU: " + descripcion);
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
