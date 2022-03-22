using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;

    public AudioSource femaleInner;

    public GameObject textPanel;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        textPanel.SetActive(true);
        foreach (string sentence in dialogue.senstences)
        {
            sentences.Enqueue(sentence);
        }
        dialogueText.color = dialogue.textColor;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            femaleInner.Play();
            dialogueText.text += letter;

            femaleInner.pitch = Random.Range(1f, 1.5f);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        EndDialogue();
        yield return null;
    }

    void EndDialogue()
    {
        textPanel.SetActive(false);
    }
}
