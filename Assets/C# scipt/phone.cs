using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phone : MonoBehaviour
{
    public DialogueTrigger[] phoneCalls;
    // Start is called before the first frame update
    void Start()
    {
        phoneCalls = GetComponentsInChildren<DialogueTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PhoneCall()
    {
        Debug.Log("Phone is ringing");
    }
}
