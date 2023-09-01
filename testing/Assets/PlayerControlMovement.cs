using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController cc;
    public float moveSpeed = 5f;
    public float gravity = -9.81f;
    private Vector3 velocity;  // Velocity vector to store gravity

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Check if the character is grounded
        if (cc.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // Small downward force to keep the player grounded
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Get input from the player
        float horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        float verticalMove = Input.GetAxis("Vertical") * moveSpeed;

        // Calculate movement direction based on input
        Vector3 dir = transform.forward * verticalMove + transform.right * horizontalMove;

        // Apply the movement and gravity
        cc.Move(dir * Time.deltaTime + velocity * Time.deltaTime);
    }
}
