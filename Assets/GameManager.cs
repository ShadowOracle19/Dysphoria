using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float dysphoriaLevel = 0;
    float dysphoriaMax = 1;

    public Material[] colors;
    public DialogueTrigger beginning;

    Color lerpedColor;
    public Material player;

    //Tasks
    private Task[] taskList;
    public List<Task> tasks;
    public Transform panel;


    // Start is called before the first frame update
    void Start()
    {
        lerpedColor = colors[0].color;

        taskList = FindObjectsOfType<Task>();

        foreach (var task in taskList)
        {
            tasks.Add(task);
        }

        //beginning.TriggerDialogue();
        //gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        //if(tasks.Count <= 0)
        //{
        //    SceneManager.LoadScene("Dream World");
        //}

        //if(Input.GetButtonDown("Fire1"))
        //{
        //    dysphoriaLevel += 0.05f;

        //    lerpedColor = Color.Lerp(colors[0].color, colors[1].color, dysphoriaLevel);
        //}
        lerpedColor = Color.Lerp(colors[0].color, colors[1].color, dysphoriaLevel);
        player.color = lerpedColor;

        if (tasks.Count == 0)
        {
            Debug.Log("Tasks done");
        }
    }


}
