using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBed : MonoBehaviour, IInteractable
{
    public Animator anim;
    public string GetDescription()
    {
        return "Go to sleep";
    }

    public void Interact()
    {
        anim.SetBool("Sleep", true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene()
    {

    }
}
