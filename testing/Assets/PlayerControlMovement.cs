using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController cc;
    public float moveSpeed;
    public float jumpSpeed;
    private Vector3 dir;
    private float horizontalMove, verticalMove;
    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void FixedUpdate()  // Using FixedUpdate for better physics behavior
    {
        // Get input from the player
        float horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        float verticalMove = Input.GetAxis("Vertical") * moveSpeed;

        // Calculate movement direction based on input
        dir = transform.forward * verticalMove + transform.right * horizontalMove;
        cc.Move(dir * Time.deltaTime);

    }
}
