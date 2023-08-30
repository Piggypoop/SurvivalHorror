using System.Collections;
using UnityEngine;

public class CombinedDoorController : MonoBehaviour
{
    public float doorOpenAngle = 90.0f;
    public float openSpeed = 2.0f;
    public float interactDistance = 5.0f;

    private bool isOpen = false;
    private Quaternion initialRotation;
    private Quaternion openRotation;

    void Start()
    {
        initialRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, doorOpenAngle, 0));
    }

    void Update()
    {
        // Cast a ray from the camera to the middle of the screen
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        // Check if the ray hits this door within the interaction distance
        if (Physics.Raycast(ray, out hit, interactDistance) && hit.transform == transform)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Toggle the door open/closed and start the coroutine to move it
                isOpen = !isOpen;
                StartCoroutine(MoveDoor(isOpen ? openRotation : initialRotation));
            }
        }
    }

    IEnumerator MoveDoor(Quaternion targetRotation)
    {
        float startTime = Time.time;

        while (Time.time - startTime <= 1 / openSpeed)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);
            yield return null;
        }

        // Snap to the target rotation
        transform.rotation = targetRotation;
    }
}
