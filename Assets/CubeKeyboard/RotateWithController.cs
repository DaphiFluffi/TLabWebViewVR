using UnityEngine;

public class RotateWithController : MonoBehaviour
{
    // Reference to the Right Hand Anchor (Controller)
    public Transform rightHandAnchor;

    // Variables to manage tilt rotation
    public bool rotationLocked = false; // Toggle to enable or disable tilt-based rotation
    private Vector3 initialTiltOffset; // Used to maintain relative rotation

    [Range(1f, 10f)] // Adjustable sensitivity in Inspector
    public float sensitivity = 5f; // Higher values make the tilt more sensitive

    void Start()
    {
        if (rightHandAnchor == null)
        {
            Debug.LogError("Assign rightHandAnchor in Inspector!");
        }
        else
        {
            // Initialize with no offset
            initialTiltOffset = Vector3.zero;
        }
    }

    void Update()
    {
        // Toggle rotation lock when "B" button is pressed
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            rotationLocked = !rotationLocked;

            // Capture the current tilt offset if rotation gets locked
            if (rotationLocked)
            {
                initialTiltOffset = ExtractTilt(rightHandAnchor.rotation.eulerAngles);
            }
        }

        // Update cube rotation based on tilt
        if (rotationLocked && rightHandAnchor != null)
        {
            Vector3 currentTilt = ExtractTilt(rightHandAnchor.rotation.eulerAngles);
            Vector3 tiltRotation = (currentTilt - initialTiltOffset) * sensitivity;

            // Apply tilt to the cube
            transform.rotation = Quaternion.Euler(tiltRotation.x, tiltRotation.y, 0); // Only X (pitch) and Y (yaw) affect the rotation
        }
    }

    // Extract tilt angles (pitch and yaw) from the controller's rotation
    private Vector3 ExtractTilt(Vector3 eulerRotation)
    {
        // Assuming:
        // - X-axis corresponds to "pitch" (tilting up and down)
        // - Y-axis corresponds to "yaw" (turning left and right)
        // - Z-axis rotation (roll) is ignored for simplicity

        return new Vector3(eulerRotation.x, eulerRotation.y, 0);
    }
}
