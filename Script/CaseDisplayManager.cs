using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CaseDisplayManager : MonoBehaviour
{
    public GameObject caseText; 
    public TMP_Text instructionText; 
    public Button continueButton; 
    public TMP_InputField titleInputField; 
    public TMP_InputField descriptionInputField; 
    public TMP_InputField valueInputField; 
    public Button createUserStoryButton;
    public Button FinishButton;
    public HUData huData;

    private List<UserStory> userStories = new List<UserStory>(); // Lista para almacenar las historias de usuario

    private void Start()
    {
        continueButton.onClick.AddListener(OnContinueButtonClicked);
        titleInputField.gameObject.SetActive(false); 
        descriptionInputField.gameObject.SetActive(false);
        valueInputField.gameObject.SetActive(false);
        createUserStoryButton.gameObject.SetActive(false);
        FinishButton.gameObject.SetActive(false);
    }

    private void OnContinueButtonClicked()
    {
        caseText.SetActive(false);
        
        continueButton.gameObject.SetActive(false);

        ShowInstructions();
        
        ShowUserStoryInputs();
    }

    private void ShowInstructions()
    {
        instructionText.text = "Instrucciones para crear una historia de usuario:\n" +
                               "1. Escribe un título.\n" +
                               "2. Añade una descripción.\n" +
                               "3. Establece el valor (prioridad o esfuerzo).\n" +
                               "4. Haz clic en 'Crear Historia de Usuario'.";
    }

    private void ShowUserStoryInputs()
    {
        titleInputField.gameObject.SetActive(true);
        descriptionInputField.gameObject.SetActive(true);
        valueInputField.gameObject.SetActive(true);
        createUserStoryButton.gameObject.SetActive(true);
        FinishButton.gameObject.SetActive(true);
    }

    public void CreateUserStory()
    {
        string title = titleInputField.text;
        string description = descriptionInputField.text;
        string value = valueInputField.text;

      if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(description))
        {
            UserStory newStory = new UserStory(title, description, valueInputField.text);
            huData.listaHUs.Add(new HU(title, description)); // Agregar la HU al ScriptableObject

            Debug.Log("Nueva historia de usuario creada: " + title + ", " + description);

        ClearInputFields();
    }
    }

    private void ClearInputFields()
    {
        titleInputField.text = "";
        descriptionInputField.text = "";
        valueInputField.text = "";
    }
}

// Clase para representar una historia de usuario
[System.Serializable]
public class UserStory
{
    public string Title;
    public string Description;
    public string Value;

    public UserStory(string title, string description, string value)
    {
        Title = title;
        Description = description;
        Value = value;
    }
}
    

