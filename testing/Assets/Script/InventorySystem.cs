using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static List<GameObject> panels;
    public List<GameObject> panels_;
    // Just for prototype
    public static List<GameObject> items = new List<GameObject>();

    void Start()
    {
        panels = panels_;
    }

    public static void AddItem(GameObject item, Sprite image)
    {
        items.Add(item);
        panels[items.Count - 1].GetComponent<InventoryItem>().Add(image, items.Count - 1);
    }

    public static void Use(int index)
    {
        Destroy(items[index]);
    }
}
