using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject itemBarPanel;  // Reference to the item bar UI Panel
    public static bool isInteracting = false; 

    // Start is called before the first frame update
    void Start()
    {
        // Make sure the item bar panel is active at the start
        itemBarPanel.SetActive(true);

        // Initialize mouse cursor to be locked and not visible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the 'E' key is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Toggle mouse cursor state
            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                isInteracting = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                isInteracting = true;
            }
        }
    }
}
