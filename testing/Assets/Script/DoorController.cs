using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedDoorController : MonoBehaviour, Interactable
{
    public float doorOpenAngle = 90.0f;
    public float openSpeed = 2.0f;
    public float interactDistance = 5.0f;

    private DialogSystem dialog;
    public TextAsset textFile;
    private List<List<string>> text;

    private bool isOpen = false;
    private bool isMoving = false;
    // Player can not open the door with out key
    private bool locked = true;
    private Quaternion initialRotation;
    private Quaternion openRotation;

    void Start()
    {
        initialRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, doorOpenAngle, 0));
        text = DialogSystem.GetTextFromFile(textFile);
        dialog = GameObject.Find("UI").GetComponent<DialogSystem>();
    }

    // Interact interface
    public void Interact()
    {
        if (locked && !isOpen)
        {
            dialog.SendMesasge(text[0], gameObject);
        }   
    }

    // Dcotor call this function
    public void OpenDoor()
    {
        if (!isMoving)
        {
            isOpen = !isOpen;
            isMoving = true;
            StartCoroutine(MoveDoor(isOpen ? openRotation : initialRotation));
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
        isMoving = false;
    }

}
