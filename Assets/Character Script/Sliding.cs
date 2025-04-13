using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform playerObj;
    private Rigidbody rb;
    private PlayerMovement pm;

    [Header("Sliding")]
    public float maxSlideTime;
    public float slideForce;
    private float slideTimer;

    public float slideYScale;
    private float startYScale;

    [Header("Input")]
    public KeyCode slideKey = KeyCode.LeftControl;
    private float horizontalInput;
    private float verticalInput;

    private CapsuleCollider capsuleCollider;
    private float originalHeight;
    private Vector3 originalCenter;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();

        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();

        // Cache the CapsuleCollider and its original properties
        capsuleCollider = GetComponent<CapsuleCollider>();
        originalHeight = capsuleCollider.height;
        originalCenter = capsuleCollider.center;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(slideKey) && (horizontalInput != 0 || verticalInput != 0))
            StartSlide();

        if (Input.GetKeyUp(slideKey) && pm.sliding)
            StopSlide();
    }

    private void FixedUpdate()
    {
        if (pm.sliding)
            SlidingMovement();
    }

    private void StartSlide()
    {
    pm.sliding = true;

    // Adjust the CapsuleCollider for sliding
    capsuleCollider.height = originalHeight * 0.5f; // Reduce height by 50%
    capsuleCollider.center = new Vector3(capsuleCollider.center.x, capsuleCollider.center.y - (originalHeight * 0.25f), capsuleCollider.center.z); // Adjust center
    rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);

    slideTimer = maxSlideTime;
    }

    private void SlidingMovement()
{
    Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

    // Sliding normal
    if (!pm.OnSlope() || rb.linearVelocity.y > -0.1f)
    {
        rb.AddForce(inputDirection.normalized * slideForce, ForceMode.Force);
    }
    // Sliding on a slope
    else
    {
        rb.AddForce(pm.GetSlopeMoveDirection(inputDirection) * slideForce, ForceMode.Force);
    }

    slideTimer -= Time.deltaTime;
    if (slideTimer <= 0)
        StopSlide();
    }   

        private void StopSlide()
    {
        pm.sliding = false;

        // Reset the CapsuleCollider to its original size
        capsuleCollider.height = originalHeight;
        capsuleCollider.center = originalCenter;
    }
}
