using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorway : MonoBehaviour
{
    public GoldenDoorway doorway;
    public GameObject selfDoubt;
    public EnemyNavigation nav;
    public DreamGameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            doorway.RejectDoor();
            nav.activate = true;
            gameManager.StartTimer();
            Destroy(selfDoubt);
        }
    }
}
