using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Memory : MonoBehaviour, IInteractable
{
    DreamGameManager gameManager;
    DialogueTrigger dialogue;
    // Start is called before the first frame update
    void Start()
    {
        
        gameManager = FindObjectOfType<DreamGameManager>();
        dialogue = GetComponent<DialogueTrigger>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string GetDescription()
    {
        return "Collect memory";
    }

    public void Interact()
    {
        gameManager.TrueEnding();
        dialogue.TriggerDialogue();
        Destroy(gameObject);
    }    
}
