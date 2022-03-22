using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Task : MonoBehaviour
{
    public string taskName;
    public float taskLength;
    public bool taskFinished;
    public bool taskText = false;
    public TextMeshProUGUI textPrefab, _text;
    GameManager gameManager;

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
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            taskText = true;
            if(taskText)
            {
                gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                gameManager.tasks.Remove(this);
                _text.fontStyle = FontStyles.Strikethrough;
                Destroy(gameObject);
            }
                       
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
