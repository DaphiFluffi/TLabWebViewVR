using UnityEngine;
using UnityEngine.UI;

public class RightControllerRaycast : MonoBehaviour
{
    // Distance for the raycast (adjust as needed)
    public float rayDistance = 10.0f;

    // Reference to the LayerMask (set this to focus on specific layers if needed)
    public LayerMask targetLayer;

    public Text DebugText;

    void Update()
    {
        // Define the starting point (origin) and direction for the raycast
        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = transform.forward;

        // Create a RaycastHit variable to store hit information
        RaycastHit hit;

        // Cast the ray from the right controller’s position and check for hits
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, rayDistance, targetLayer))
        {
            // Check if the collider hit is a trigger
            if (hit.collider.isTrigger)
            {
                DebugText.text = "Hit a trigger collider: " + hit.collider.name;
                // Here, you can handle the hit, e.g., perform some action on the hit object
            }
        }

        // For debugging: visualize the ray in the scene view
        Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.red);
    }
}
