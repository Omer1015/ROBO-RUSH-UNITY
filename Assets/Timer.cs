using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    private float timeElapsed;
    private float finalTime; // Variable to store the final time
    private bool isRunning = true; // Controls whether the timer is running

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            timeElapsed += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeElapsed / 60);
            int seconds = Mathf.FloorToInt(timeElapsed % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    // Method to stop the timer and store the final time
    public void StopTimer()
    {
        isRunning = false; // Stop the timer
        finalTime = timeElapsed; // Store the final time
        Debug.Log("Timer stopped. Final time: " + finalTime + " seconds.");
    }

    // Method to get the final time
    public float GetFinalTime()
    {
        Debug.Log("Final time: " + finalTime + " seconds.");
        return finalTime;
    }
}