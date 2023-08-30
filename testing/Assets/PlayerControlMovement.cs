using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to control movement speed
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()  // Using FixedUpdate for better physics behavior
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction based on input
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Convert movement direction to world space, aligned to the player's orientation
        movement = transform.TransformDirection(movement);
        movement *= moveSpeed;

        // Apply movement while preserving any existing y-axis velocity (e.g., from jumping or gravity)
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
}
