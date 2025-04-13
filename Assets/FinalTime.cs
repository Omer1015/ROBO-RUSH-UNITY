using UnityEngine;
using TMPro;

public class FinalTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalTimeText; // Reference to the TextMeshProUGUI component
    [SerializeField] private Timer timer; // Reference to the Timer script

    // Start is called before the first frame update
    void Start()
    {
        if (timer != null)
        {
            // Retrieve the final time from the Timer script
            float finalTime = timer.GetFinalTime();

            // Convert the final time to minutes and seconds
            int minutes = Mathf.FloorToInt(finalTime / 60);
            int seconds = Mathf.FloorToInt(finalTime % 60);

            // Display the final time in the TextMeshProUGUI component
            finalTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            Debug.LogWarning("Timer script is not assigned in the FinalTime script.");
        }
    }
}