using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{

    public int index;
    public bool isEmpty;

    public void Add(Sprite image, int index)
    {
        this.index = index;
        gameObject.GetComponent<Image>().sprite = image;
    }
    public void Use()
    {
        if (index < InventorySystem.items.Count)
        {
            gameObject.GetComponent<Image>().sprite = null;
            InventorySystem.Use(index);
        }
    }
}
