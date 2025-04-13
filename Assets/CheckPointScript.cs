using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    private RespawnScript respawn;
    private Collider checkpointCollider;

    [SerializeField] private Material CheckPointOFF; // Material for inactive checkpoint
    [SerializeField] private Material CheckPointOn;  // Material for active checkpoint
    private Renderer checkpointRenderer;            // Renderer to change the material

    void Awake()
    {
        checkpointCollider = GetComponent<Collider>();
        checkpointRenderer = GetComponent<Renderer>();
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnScript>();
    }

    void Start()
    {
        // Set the initial material to CheckPointOFF
        if (checkpointRenderer != null && CheckPointOFF != null)
        {
            checkpointRenderer.material = CheckPointOFF;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Set this checkpoint as the active respawn point
            respawn.RespawnPoint = this.gameObject;

            // Disable the collider to prevent re-triggering
            checkpointCollider.enabled = false;

            // Update the material to CheckPointOn for the active checkpoint
            if (checkpointRenderer != null && CheckPointOn != null)
            {
                checkpointRenderer.material = CheckPointOn;
            }

            // Notify other checkpoints to switch to CheckPointOFF
            CheckPointScript[] allCheckpoints = FindObjectsByType<CheckPointScript>(FindObjectsSortMode.None);
            foreach (CheckPointScript checkpoint in allCheckpoints)
            {
                if (checkpoint != this) // Skip the current checkpoint
                {
                    checkpoint.SetInactive();
                }
            }
        }
    }

    // Method to set the checkpoint as inactive
    public void SetInactive()
    {
        if (checkpointRenderer != null && CheckPointOFF != null)
        {
            checkpointRenderer.material = CheckPointOFF;
        }

        // Re-enable the collider for future triggers
        checkpointCollider.enabled = true;
    }
}