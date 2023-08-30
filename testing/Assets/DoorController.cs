using System.Collections;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float doorOpenAngle = 90.0f; // The angle by which the door should rotate when opened.
    public float openSpeed = 10.0f;// speed at which the door opens.
    private bool doorOpen = false;
    private bool doorMoving = false;
    private Quaternion initialRotation;
    private Quaternion finalRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
        finalRotation = initialRotation * Quaternion.Euler(0, doorOpenAngle, 0);
    }

    private void Update()
    {
        // Input trigger the door.
        if (Input.GetKeyDown(KeyCode.E) && !doorMoving)
        {
            if (doorOpen)
                StartCoroutine(MoveDoor(initialRotation));
            else
                StartCoroutine(MoveDoor(finalRotation));
        }
    }

    IEnumerator MoveDoor(Quaternion targetRotation)
    {
        doorMoving = true;
        float startTime = Time.time;
        Quaternion startRotation = transform.rotation;

        while (Time.time < startTime + (Mathf.Abs(doorOpenAngle) / openSpeed))
        {
            float angleCovered = (Time.time - startTime) * openSpeed;
            float fractionOfJourney = angleCovered / Mathf.Abs(doorOpenAngle);
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, fractionOfJourney);
            yield return null;
        }

        // Ensure the door is at the final rotation angle when it's done moving.
        transform.rotation = targetRotation;

        doorOpen = !doorOpen;
        doorMoving = false;
    }
}