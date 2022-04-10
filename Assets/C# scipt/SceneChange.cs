using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public void ChangeToRealWorld()
    {
        SceneManager.LoadScene("Real World");
    }

    public void ChangeToDreamWorld()
    {
        SceneManager.LoadScene("Dream World");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("IntroCutscene");
    }
}
