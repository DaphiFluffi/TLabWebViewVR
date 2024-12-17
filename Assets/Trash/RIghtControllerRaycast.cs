using UnityEngine;
using UnityEngine.UI;

public class RightControllerRaycast : MonoBehaviour
{
    public Camera vrCamera; // Assign the VR Camera (e.g., CenterEyeAnchor)
    public LayerMask interactableLayer; // Layer for canvases and interactable objects
    public Text debugText; // Text object for debugging output

    void Update()
    {
        // Check if the trigger button is pressed
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) // Meta Quest trigger button
        {
            Ray ray = new Ray(vrCamera.transform.position, vrCamera.transform.forward);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactableLayer))
            {
                // Update the debug text with the clicked object's name
                debugText.text = "Canvas clicked: " + hit.collider.gameObject.name;
            }
            else
            {
                // Optional: Clear debug text if nothing is clicked
                debugText.text = "No canvas clicked.";
            }
        }
    }
}
