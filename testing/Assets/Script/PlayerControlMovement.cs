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
    private float initialY;
    private void Start()
    {
        cc = GetComponent<CharacterController>();
        initialY = transform.position.y;
    }

    private void FixedUpdate()  // Using FixedUpdate for better physics behavior
    {
        if (DialogSystem.ON || GameController.isInteracting)
        {
            return;
        }
        // Get input from the player
        float horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        float verticalMove = Input.GetAxis("Vertical") * moveSpeed;

        // Calculate movement direction based on input
        dir = transform.forward * verticalMove + transform.right * horizontalMove;
        cc.Move(dir * Time.deltaTime);
        cc.transform.position = new Vector3(cc.transform.position.x, initialY, cc.transform.position.z);
    }
}
