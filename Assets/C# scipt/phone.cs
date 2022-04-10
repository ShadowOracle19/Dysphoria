using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phone : MonoBehaviour, IInteractable
{
    //public static DialogueTrigger[] phoneCalls;
    public static List<DialogueTrigger> l_phoneCalls = new List<DialogueTrigger>();
    public AudioSource call;
    public static int _call = 3;
    public BoxCollider bed;
    bool phoneAnswered;
    bool ableToAnswer = false;

    // Start is called before the first frame update
    void Start()
    {

        phoneAnswered = false;
        DialogueTrigger[] calls = GetComponentsInChildren<DialogueTrigger>();
        foreach(DialogueTrigger messages in calls)
        {
            l_phoneCalls.Add(messages);
        }
        
    }

    public void PhoneCall()
    {       
        call.Play();
        ableToAnswer = true;
    }

    public void Interact()
    {
        if (!ableToAnswer) return;
        int random = Random.Range(0, _call);
        _call -= 1;
        call.Stop();
        l_phoneCalls[random].TriggerDialogue();
        l_phoneCalls.RemoveAt(random);
        bed.enabled = true;
    }

    public string GetDescription()
    {
        return "Check Phone";
    }
}
