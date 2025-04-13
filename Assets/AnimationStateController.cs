using System.Collections.Generic;
using UnityEngine;
using static PlayerMovement;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    public PlayerMovement playerMovement;
    public WallRunningAdvanced wallRunning; // Reference to the WallRunning script

    [System.Obsolete]
    void Start()
    {
        animator = GetComponent<Animator>();

        // Dynamically find the PlayerMovement component on the same GameObject
        playerMovement = GetComponent<PlayerMovement>();

        // Dynamically find the WallRunning component on the same GameObject
        wallRunning = GetComponent<WallRunningAdvanced>();

        // If not found, try to find it in the scene (e.g., on a parent or child GameObject)
        if (playerMovement == null)
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
        }

        if (wallRunning == null)
        {
            wallRunning = FindObjectOfType<WallRunningAdvanced>();
        }

        // Log a warning if PlayerMovement or WallRunning is not found
        if (playerMovement == null)
        {
            Debug.LogWarning("PlayerMovement component not found in the scene.");
        }

        if (wallRunning == null)
        {
            Debug.LogWarning("WallRunning component not found in the scene.");
        }
    }

    void Update()
{
    if (playerMovement != null)
    {
        // Update animation parameters based on the player's state
        animator.SetBool("isJumping", playerMovement.CurrentState == MovementState.air);
        animator.SetBool("isSprinting", playerMovement.CurrentState == MovementState.sprinting);
        animator.SetBool("isSliding", playerMovement.CurrentState == MovementState.sliding);
        animator.SetBool("isWallrunning", playerMovement.CurrentState == MovementState.wallrunning);

        // Handle wallrunning left and right
        if (wallRunning != null)
        {
            animator.SetBool("wallRunningLeft", wallRunning.wallLeft);
            animator.SetBool("wallRunningRight", wallRunning.wallRight);

            // Ensure isJumping is false when wallrunning left or right
            if (wallRunning.wallLeft || wallRunning.wallRight)
            {
                animator.SetBool("isJumping", false);
            }
            else
            {
                animator.SetBool("isJumping", playerMovement.CurrentState == MovementState.air);
            }
        }
        else
        {
            // Ensure isJumping is false when wallrunning
            if (playerMovement.CurrentState == MovementState.wallrunning)
            {
                animator.SetBool("isJumping", false);
            }
            else
            {
                animator.SetBool("isJumping", playerMovement.CurrentState == MovementState.air);
            }
        }

        // Handle idle and walking animations
        bool isGrounded = playerMovement.grounded; // Assuming grounded is a public property in PlayerMovement
        bool isMoving = playerMovement.horizontalInput != 0 || playerMovement.verticalInput != 0;

        if (isGrounded && !isMoving)
        {
            // Player is idle
            animator.SetBool("isWalking", false); // Ensure walking is disabled
            animator.SetBool("isCrouching", false); // Ensure crouching movement is disabled
            if (playerMovement.CurrentState == MovementState.crouching)
            {
                animator.SetBool("isCrouchingIdle", true);
                animator.SetBool("isIdle", false);
            }
            else
            {
                animator.SetBool("isIdle", true);
                animator.SetBool("isCrouchingIdle", false);
            }
        }
        else
        {
            // Player is moving
            animator.SetBool("isIdle", false);
            animator.SetBool("isCrouchingIdle", false);

            if (playerMovement.CurrentState == MovementState.crouching)
            {
                animator.SetBool("isCrouching", true); // Enable crouching movement
                animator.SetBool("isWalking", false); // Ensure walking is disabled
            }
            else
            {
                animator.SetBool("isCrouching", false); // Disable crouching movement
                animator.SetBool("isWalking", playerMovement.CurrentState == MovementState.walking);
            }
        }
    }
}
}