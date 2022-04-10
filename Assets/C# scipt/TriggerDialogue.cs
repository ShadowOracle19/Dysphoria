using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public DialogueTrigger dialogue;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //gameObject.GetComponents<BoxCollider>().enabled = false;
            BoxCollider[] colliders = gameObject.GetComponents<BoxCollider>();
            foreach (BoxCollider item in colliders)
            {
                item.enabled = false;
            }
            dialogue.TriggerDialogue();

        }
    }
}
