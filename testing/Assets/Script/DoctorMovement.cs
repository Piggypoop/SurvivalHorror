using System.Collections;
using UnityEngine;

public class MoveAndRotate : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed = 1.0f;
    public float rotationSpeed = 360.0f; // Degrees per second
    private bool hasReachedTarget = false;

    private void Start()
    {
        StartCoroutine(active());
    }

    IEnumerator active()
    {
        // Move to door
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            yield return null;
        }

        // Rotate 90 degrees around the Y axis
        float traget = 90.0f;
        while (traget > 0.1f)
        {
            float rotationStep = rotationSpeed * Time.deltaTime;
            traget -= rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), rotationStep);
            yield return null;
        }

        GameObject.Find("P_Door_01_").GetComponent<CombinedDoorController>().OpenDoor();
    }
}
