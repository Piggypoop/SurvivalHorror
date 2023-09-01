using UnityEngine;

public class MoveAndRotate : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed = 1.0f;
    public float rotationSpeed = 360.0f; // Degrees per second
    private bool hasReachedTarget = false;

    void Update()
    {
        // Move towards the target position
        if (!hasReachedTarget)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // Check if the position of the model is approximately equal to the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                hasReachedTarget = true;
            }
        }
        else
        {
            // Rotate 90 degrees around the Y axis
            float rotationStep = rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), rotationStep);
        }
    }
}
