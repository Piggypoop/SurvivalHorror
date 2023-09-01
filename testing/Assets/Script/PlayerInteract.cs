using UnityEngine;

public class SimpleHighlight : MonoBehaviour, Interactable
{
    public Material highlightMaterial;
    private Material originalMaterial;
    private Renderer objectRenderer;
    public Camera camera;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;
    }

    private void Update()
    {
        if (camera == null)
        {
            Debug.LogWarning("Camera not set.");
            return;
        }
        
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
        {
            
            
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log("Hit the target object");
                objectRenderer.material = highlightMaterial;
            }
            else
            {
                objectRenderer.material = originalMaterial;
            }
        }
        else
        {
            Debug.Log("Didn't hit anything");
            objectRenderer.material = originalMaterial;
        }
    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }
}
