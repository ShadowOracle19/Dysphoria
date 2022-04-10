using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndEscape : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("EndE", true);
    }
    
}
