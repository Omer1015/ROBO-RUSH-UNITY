using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuTab; // Reference to the Pause Menu canvas
    private bool isPaused = false; // Tracks whether the game is paused

    void Update()
    {
        // Check if the "Enter" key is pressed
        if (Input.GetKeyDown(KeyCode.Return)) // "Return" is the Enter key
        {
            if (isPaused)
            {
                Resume(); // Resume the game if it's currently paused
            }
            else
            {
                Pause(); // Pause the game if it's currently running
            }
        }
    }

    public void Pause()
    {
        if (PauseMenuTab != null)
        {
            PauseMenuTab.SetActive(true); // Show the Pause Menu canvas
            Time.timeScale = 0; // Freeze the game
            isPaused = true; // Set the paused state to true

            // Make the cursor visible and unlock it
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Debug.LogWarning("PauseMenuTab is not assigned in the inspector.");
        }
    }

    public void Resume()
    {
        if (PauseMenuTab != null)
        {
            PauseMenuTab.SetActive(false); // Hide the Pause Menu canvas
            Time.timeScale = 1; // Resume the game
            isPaused = false; // Set the paused state to false

            // Hide the cursor and lock it
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Debug.LogWarning("PauseMenuTab is not assigned in the inspector.");
        }
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1; // Resume time before loading the main menu
        SceneManager.LoadScene("Main-Menu");
    }

    public void Restart()
    {
        Time.timeScale = 1; // Resume time before restarting the level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}