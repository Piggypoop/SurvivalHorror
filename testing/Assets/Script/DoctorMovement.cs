using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveAndRotate : MonoBehaviour, Interactable
{
    public Vector3 targetPosition;
    public float speed = 1.0f;
    public float rotationSpeed = 360.0f; // Degrees per second
    private bool hasReachedTarget = false;


    public GameOverUIMenu gameOverUI;

    public TextAsset textFile;

    private List<List<string>> text;
    private DialogSystem dialog;

    // Drug
    private Drug drug;
    private int stage = 0;
    private int count = 0;

    private void Start()
    {
        StartCoroutine(active());
        dialog = GameObject.Find("UI").GetComponent<DialogSystem>();
        text = DialogSystem.GetTextFromFile(textFile);
        drug = GameObject.Find("Drug").GetComponent<Drug>();
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

    public void Interact()
    {
        if (stage == 0)
        {
            dialog.SendMesasge(text[0], gameObject);
            drug.eatable = true;
            stage = 1;
        }
        
        else
        {
            if (drug == null)
            {
                dialog.SendMesasge(text[3], gameObject);

            }
            else if (count < 3)
            {
                dialog.SendMesasge(text[1], gameObject);
                count += 1;
            }
            else
            {
                dialog.SendMesasge(text[2], gameObject);
                GameObject.Find("GameOverMenu").GetComponent<GameOverUIMenu>().EnableGameOverMenu();
            }
        }
        
    }
}
