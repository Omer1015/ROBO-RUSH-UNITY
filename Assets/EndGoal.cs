using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    public GameObject rankScreenPanel; // Reference to the Rank Screen panel
    public Timer timer; // Reference to the Timer script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the collider belongs to the player
        {
            // Show the Rank Screen panel
            if (rankScreenPanel != null)
            {
                rankScreenPanel.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Rank Screen panel is not assigned in the inspector.");
            }

            // Stop the timer
            if (timer != null)
            {
                timer.StopTimer();
            }
            else
            {
                Debug.LogWarning("Timer script is not assigned in the inspector.");
            }
        }
    }
}