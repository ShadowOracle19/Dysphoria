using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DreamGameManager : MonoBehaviour
{
    public static int escapeismEnding;
    public static int dysphoriaEnding;
    public static int trueEnding;
    public static int night;
    public int escape;
    public int dysphoria;
    public int trueEnd;
    public int _night;

    public TrueEnding portal;
    public Timer timer;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }
    private void Update()
    {
        
    }

    public void Escapeism()
    {
        escapeismEnding += 1;
        escape = escapeismEnding;
        night += 1;
        _night = night;

    }

    public void Dysphoria()
    {
        dysphoriaEnding += 1;
        dysphoria = dysphoriaEnding;
        night += 1;
        _night = night;
    }

    public void TrueEnding()
    {
        trueEnding += 1;
        trueEnd = trueEnding;
        CheckEnding();
    }

    public void EndNight()
    {
        night += 1;
        _night = night;
    }

    public void CheckEnding()
    {
        if((escapeismEnding == 3) && (trueEnding == 0) && (dysphoriaEnding == 0))//escapism end
        {
            SceneManager.LoadScene("EscapeismEnding");
        }
        else if((escapeismEnding == 0) && (trueEnding == 0) && (dysphoriaEnding == 3))//dysphoria ending
        {

        }
        else if((escapeismEnding < 3) && (trueEnding == 4) && (dysphoriaEnding < 3))//true ending
        {
            portal.gameObject.SetActive(true);
        }
        else if((escapeismEnding < 3) && (trueEnding < 4) && (dysphoriaEnding < 3))//neutral ending
        {

        }
        else
        {
            return;
        }
    }

    public void StartTimer()
    {
        timer.gameObject.SetActive(true);
        timer.timerIsRunning = true;
    }

}
