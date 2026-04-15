using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Si usas TextMeshPro para el texto

public class TogglePanel : MonoBehaviour
{
    public GameObject panelToToggle;       // Panel que se activará/desactivará
    public Button buttonToHide;            // Botón que se ocultará
    public TextMeshProUGUI textToHide;     // Texto que se ocultará (usa Text si no estás usando TextMeshPro)

    private void Start()
    {
        if (panelToToggle != null)
        {
            panelToToggle.SetActive(false); // Asegurarse de que el panel esté desactivado al inicio
        }

        if (buttonToHide != null)
        {
            buttonToHide.gameObject.SetActive(true); // Asegurarse de que el botón esté activo al inicio
        }

        if (textToHide != null)
        {
            textToHide.gameObject.SetActive(true); // Asegurarse de que el texto esté activo al inicio
        }
    }

    public void TogglePanelVisibility()
    {
        if (panelToToggle != null)
        {
            // Cambia el estado del panel entre activo e inactivo
            bool isPanelActive = !panelToToggle.activeSelf;
            panelToToggle.SetActive(isPanelActive);

            // Ocultar el botón y el texto cuando el panel está activo
            if (buttonToHide != null)
            {
                buttonToHide.gameObject.SetActive(!isPanelActive);
            }

            if (textToHide != null)
            {
                textToHide.gameObject.SetActive(!isPanelActive);
            }
        }
        else
        {
            Debug.LogError("No se ha asignado un panel en el inspector.");
        }
    }
}

