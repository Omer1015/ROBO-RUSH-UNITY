using UnityEngine;

public class Ranking : MonoBehaviour
{
    [SerializeField] private Timer timer; // Reference to the Timer script
    [SerializeField] private GameObject sRankPanel; // Reference to the S Rank panel
    [SerializeField] private GameObject aRankPanel; // Reference to the A Rank panel
    [SerializeField] private GameObject bRankPanel; // Reference to the B Rank panel
    [SerializeField] private GameObject cRankPanel; // Reference to the C Rank panel
    [SerializeField] private GameObject dRankPanel; // Reference to the D Rank panel

    // Start is called before the first frame update
    void Start()
    {
        if (timer != null)
        {
            // Retrieve the final time from the Timer script
            float finalTime = timer.GetFinalTime();

            // Determine the rank based on the final time
            if (finalTime <= 180) // 3 minutes or faster
            {
                ShowRankPanel(sRankPanel);
            }
            else if (finalTime <= 240) // 4 minutes or faster
            {
                ShowRankPanel(aRankPanel);
            }
            else if (finalTime <= 300) // 5 minutes or faster
            {
                ShowRankPanel(bRankPanel);
            }
            else if (finalTime <= 360) // 6 minutes or faster
            {
                ShowRankPanel(cRankPanel);
            }
            else // More than 6 minutes
            {
                ShowRankPanel(dRankPanel);
            }
        }
        else
        {
            Debug.LogWarning("Timer script is not assigned in the Ranking script.");
        }
    }

    // Method to show the appropriate rank panel
    private void ShowRankPanel(GameObject rankPanel)
    {
        // Hide all rank panels first
        sRankPanel.SetActive(false);
        aRankPanel.SetActive(false);
        bRankPanel.SetActive(false);
        cRankPanel.SetActive(false);
        dRankPanel.SetActive(false);

        // Show the specified rank panel
        if (rankPanel != null)
        {
            rankPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Rank panel is not assigned in the Ranking script.");
        }
    }
}