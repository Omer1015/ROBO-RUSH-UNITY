using UnityEngine;

public class showcursor : MonoBehaviour
{
    [SerializeField] private GameObject rankScreenPanel; // Reference to the Rank Screen panel

    void Update()
    {
        // Check if the rank screen panel is active
        if (rankScreenPanel != null && rankScreenPanel.activeSelf)
        {
            Cursor.visible = true; // Make the cursor visible
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        }
        else
        {
            Cursor.visible = false; // Hide the cursor
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        }
    }
}