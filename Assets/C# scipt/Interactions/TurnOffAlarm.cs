using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffAlarm : MonoBehaviour, IInteractable
{
    public AudioSource alarm;

    

    public string GetDescription()
    {
        return "Turn off alarm";
    }

    public void Interact()
    {
        alarm.enabled = false;
        Destroy(this);
    }

    
}
