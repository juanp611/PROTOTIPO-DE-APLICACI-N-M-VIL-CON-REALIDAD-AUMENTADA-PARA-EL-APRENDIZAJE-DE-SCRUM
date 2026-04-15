using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskStateController : MonoBehaviour
{
    public Button moveToInProgressButton;
    public Button moveToDoneButton;

    public GameObject inProgressColumn;
    public GameObject doneColumn;

    private void Start()
    {
        moveToInProgressButton.onClick.AddListener(() => MoveTask(inProgressColumn));
        moveToDoneButton.onClick.AddListener(() => MoveTask(doneColumn));
        
    }

    private void MoveTask(GameObject targetColumn)
    {
        transform.SetParent(targetColumn.transform);
        GetComponent<RectTransform>().anchoredPosition = Vector3.zero; 
        }
}
