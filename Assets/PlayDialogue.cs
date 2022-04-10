using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDialogue : MonoBehaviour
{
    public DialogueTrigger dialogue;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(C_dialogue());
    }

    IEnumerator C_dialogue()
    {
        yield return new WaitForSeconds(0.1f);
        dialogue.TriggerDialogue();
        yield return null;
    }
}
