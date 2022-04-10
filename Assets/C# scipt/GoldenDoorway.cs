using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class GoldenDoorway : MonoBehaviour
{
    Animator anim;
    DreamGameManager gameManager;
    public void Start()
    {
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<DreamGameManager>();
    }

    public void RejectDoor()
    {
        anim.SetBool("Closed", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        gameManager.Escapeism();

        if(gameManager._night == 3)
        {
            gameManager.CheckEnding();
            return;
        }

        SceneManager.LoadScene("Real World");
    }

    public void DestroyDoor()
    {
        Destroy(gameObject);
    }
}
