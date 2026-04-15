using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject ToDoColumn;   
    public GameObject inProgressColumn; 
    public GameObject doneColumn;   
    public GameObject taskPrefab;   

    public void AddTaskToColumn(string taskTitle, GameObject column)
    {
        GameObject newTask = Instantiate(taskPrefab, column.transform);
        newTask.GetComponentInChildren<Text>().text = taskTitle;
    }

}
