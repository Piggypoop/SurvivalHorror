using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drug : MonoBehaviour, Interactable
{
    public TextAsset textFile;
    public Sprite image;
    public bool eatable = false;

    private List<List<string>> text;
    private DialogSystem dialog;

    void Start()
    {
        dialog = GameObject.Find("UI").GetComponent<DialogSystem>();
        text = DialogSystem.GetTextFromFile(textFile);
    }

    public void Interact()
    {
        if (!eatable)
        {
            dialog.SendMesasge(text[0], gameObject);
        }
        else
        {
            dialog.SendMesasge(text[1], gameObject);
        }
    }

    public void Pickup()
    {
        if (eatable)
        {
            transform.position = new Vector3(0, -10, 0);
            InventorySystem.AddItem(gameObject, image);
        }
    }
}
