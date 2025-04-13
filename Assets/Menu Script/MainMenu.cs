using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{   
    public void MainMenuLoad()
    {
        SceneManager.LoadSceneAsync("Main-Menu");
    }
    public void PlayTestLevel()
    {
        SceneManager.LoadSceneAsync("Test-Level");
    }

    public void PlayLevel1()
    {
        SceneManager.LoadSceneAsync("Level-1");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
