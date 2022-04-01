using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

enum EnemyStates
{
    Wander,
    Chase
}

public class EnemyNavigation : MonoBehaviour
{
    public Transform[] points;
    public Transform player;
    public float detectionRange = 10;
    private int destPoint = 0;
    private NavMeshAgent agent;

    public bool playerDetect;
    public float maxTimer = 5.0f;
    public float timer = 0.0f;

    [Header("Dialogue")]
    public DialogueTrigger chase_Dialogue;
    public DialogueTrigger wander_Dialogue;
    bool chaseDialogueIsPlaying = false;
    bool wanderDialogueIsPlaying = false;

    [Header("Effects")]
    public Volume volume;

    [SerializeField]
    EnemyStates m_currentState = EnemyStates.Wander;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //Disabling auto-braking allows for continuous movement
        agent.autoBraking = false;
        GotoNextPoint();

        timer = maxTimer;
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        switch (m_currentState)//enemy state machine
        {
            case EnemyStates.Wander:
                Wander();
                break;
            case EnemyStates.Chase:
                ChasePlayer();
                break;
            default:
                break;
        }

        // Choose the next destination point when the agent gets
        // close to the current one.
        

       Collider[] colliders = Physics.OverlapSphere(this.transform.position, detectionRange);
       foreach(var hitCollide in colliders)
       {
            if(hitCollide.gameObject.tag == "Player")
            {
                m_currentState = EnemyStates.Chase;
            }           
       }
    }

    private void FixedUpdate()
    {
        if(m_currentState == EnemyStates.Chase)
        {
            float dist = Vector3.Distance(this.transform.position, player.position);
            if(dist >= 20)
            {

                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    m_currentState = EnemyStates.Wander;
                    timer = maxTimer;

                }
            }
            else if(dist <= 2)
            {
                SceneManager.LoadScene("Real World");
            }
            else
            {
                timer = maxTimer;
            }

        }
    }

    void Wander()
    {
        Vignette tmp;
        volume.profile.TryGet<Vignette>(out tmp);
        tmp.intensity.Override(0.3f);
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();

        if (!wanderDialogueIsPlaying)
        {
            wander_Dialogue.TriggerDialogue();
            wanderDialogueIsPlaying = true;
            chaseDialogueIsPlaying = false;
        }
    }

    void ChasePlayer()
    {
        Vignette tmp;
        volume.profile.TryGet<Vignette>(out tmp);
        tmp.intensity.Override(0.5f);
        agent.destination = player.position;

        if (!chaseDialogueIsPlaying)
        {
            chase_Dialogue.TriggerDialogue();
            wanderDialogueIsPlaying = false;
            chaseDialogueIsPlaying = true;
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(this.transform.position, detectionRange);
    //}
}
