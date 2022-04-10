using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Task : MonoBehaviour, IInteractable
{
    public string taskName;
    public float taskLength;
    public bool taskFinished;
    public bool taskText = false;
    public TextMeshProUGUI textPrefab, _text;
    GameManager gameManager;

    public string GetDescription()
    {
        return taskName;
    }

    public void Interact()
    {
        taskFinished = true;
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        _text = Instantiate(textPrefab, gameManager.panel);

    }

    private void Update()
    {
        
        _text.text = "-" + taskName;


        if(taskFinished)
        {         
            taskText = true;
            if(taskText)
            {
                gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                gameManager.tasks.Remove(this);
                _text.fontStyle = FontStyles.Strikethrough;
                Destroy(gameObject);
            }
                       
        }
    }
}
