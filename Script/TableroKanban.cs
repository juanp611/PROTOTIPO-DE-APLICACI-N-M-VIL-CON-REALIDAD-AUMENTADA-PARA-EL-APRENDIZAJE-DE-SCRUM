using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TableroKanban : MonoBehaviour
{
public GameObject botonPrefab;  
    public Transform contenedorDeBotones;  
    public HUData huData;  
    
private void Start()
    {
        if (huData != null && huData.listaHUs != null)
        {
                        botonPrefab.SetActive(false);

            // Asegurarse de que el contenedor de botones tenga un layout adecuado (como un VerticalLayoutGroup)
            VerticalLayoutGroup layoutGroup = contenedorDeBotones.GetComponent<VerticalLayoutGroup>();
            if (layoutGroup == null)
            {
                // Si no tiene un VerticalLayoutGroup, podemos agregar uno automáticamente
                layoutGroup = contenedorDeBotones.gameObject.AddComponent<VerticalLayoutGroup>();
            }

            layoutGroup.spacing = 10f;  
            //layoutGroup.padding = new RectOffset(10, 10, 10, 10);  

            foreach (HU hu in huData.listaHUs)
            {
                GameObject nuevoBoton = Instantiate(botonPrefab, contenedorDeBotones);
                nuevoBoton.GetComponentInChildren<TextMeshProUGUI>().text = hu.titulo;  // Asignar el título de la HU al botón

                // Añadir el listener para mostrar la descripción de la HU
                nuevoBoton.GetComponent<Button>().onClick.AddListener(() => ShowdescriptionHU(hu.descripcion));
                nuevoBoton.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("huData o su lista de HUs es nula. Asegúrate de asignar el ScriptableObject.");
        }
    }

    private void ShowdescriptionHU(string descripcion)
    {
        Debug.Log("Descripción de HU: " + descripcion);
    }
}
