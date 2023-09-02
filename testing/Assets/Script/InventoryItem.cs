using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{

    public int index;
    public bool isEmpty;

    public void Add(Sprite image)
    {
        gameObject.GetComponent<Image>().sprite = image;
    }
    public void Use()
    {
        gameObject.GetComponent<Image>().sprite = null;
    }
}
