using UnityEngine;

public class SimpleHighlight : MonoBehaviour
{
    public Material highlightMaterial;
    private GameObject highlightObject;
    public Camera camera;
    public bool ishighlight = false;

    private void Start()
    {
        // Create the highlight object as a slightly scaled version of the original object
        highlightObject = Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
        highlightObject.transform.localScale *= 2f;
        highlightObject.GetComponent<Renderer>().material = highlightMaterial;

        // Disable it by default
        highlightObject.SetActive(false);
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
                ishighlight = true;
            }
            else
            {
                ishighlight = false;
            }
        }
        else
        {
            ishighlight = false;
        }

        highlightObject.SetActive(ishighlight);
    }
}
