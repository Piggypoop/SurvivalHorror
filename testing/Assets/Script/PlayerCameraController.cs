using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float sensitivityX = 2.0f;
    public float sensitivityY = 2.0f;
    private float rotationX = 0.0f;

    public float interactDistance = 2.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (DialogSystem.ON || GameController.isInteracting)
        {
            return;
        }
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

        // Rotate the player around the Y-axis (yaw)
        playerTransform.Rotate(Vector3.up * mouseX);

        // Calculate the vertical rotation for the camera (pitch)
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90, 90);

        // Apply the rotations to the camera
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        // Make sure the player model faces the same direction as the camera
        playerTransform.rotation = Quaternion.Euler(0, transform.root.eulerAngles.y, 0);

        // Detect interactable object
        rayDetect();
    }

    // Ray detect
    private void rayDetect()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
            // CompareTag to check if this item is Interactive item
            if (Physics.Raycast(ray, out hit, interactDistance) && hit.transform.CompareTag("Interactive item"))
            {
                // Interact with Interactive item
                hit.transform.GetComponent<Interactable>().Interact();
            }
        }
    }

}
