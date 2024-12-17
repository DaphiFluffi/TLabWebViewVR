using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR;

public class DwellSelection : MonoBehaviour
{
    public float dwellTime = 0.2f; // Time in seconds to dwell before selecting
    public LayerMask targetLayer; // Layer to specify selectable objects
    public Color defaultColor = Color.blue; // Default color
    public Color dwellColor = Color.red; // Color during dwell selection
    public float vibrationDuration = 0.05f; // Duration of vibration on confirm
    public float vibrationStrength = 0.5f; // Strength of vibration (0 to 1)
    public Text debugText;
    public XRNode xRNode;

    private RaycastHit hit;
    private float dwellTimer = 0f;
    private GameObject currentTarget = null; // Object being looked at

    void Update()
    {
        // Define the ray
        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = transform.forward;

        // Check if the ray hits an object
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, Mathf.Infinity, targetLayer))
        {
            GameObject hitObject = hit.collider.gameObject;

            // If we're hovering over the same object
            if (currentTarget == hitObject)
            {
                dwellTimer += Time.deltaTime;

                // If dwell time is reached
                if (dwellTimer >= dwellTime)
                {
                    HighlightObject(hitObject, dwellColor);

                    // Trigger haptic feedback
                    TriggerHapticPulse();

                    // Check for input to confirm selection
                    if (hitObject.tag == "CubeSpecial") { 
                        debugText.text = ("Special Char: " + hitObject.name);
                        PerformAction(hitObject);
                    }
                    else
                    {
                        if( OVRInput.GetDown(OVRInput.Button.One)) // 'One' corresponds to the A or X button
                        { 
                            debugText.text = ("Normal Char: " + hitObject.name);
                            // Perform some action (if needed)
                            PerformAction(hitObject);
                        }
                    }
                }
            }
            else
            {
                // Switch target
                ResetCurrentTarget();
                currentTarget = hitObject;
                dwellTimer = 0f;
            }
        }
        else
        {
            // Reset if no object is hit
            ResetCurrentTarget();
        }

        // Debug ray
        Debug.DrawRay(rayOrigin, rayDirection * 10, Color.red);
    }

    // Reset the currently selected target
    private void ResetCurrentTarget()
    {
        if (currentTarget != null)
        {
            HighlightObject(currentTarget, defaultColor);
        }
        currentTarget = null;
        dwellTimer = 0f;
    }

    // Change the color of the object
    private void HighlightObject(GameObject obj, Color color)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }

    // Perform some action on the selected object (e.g., print a message)
    private void PerformAction(GameObject obj)
    {
        debugText.text = obj.GetComponentInChildren<TextMeshProUGUI>().text + " is my current letter";

    }

    void TriggerHapticPulse()
    {
        var device = InputDevices.GetDeviceAtXRNode(xRNode);
        HapticCapabilities capabilities;
        if (device.TryGetHapticCapabilities(out capabilities))
        {
            if (capabilities.supportsImpulse)
            {
                uint channel = 0;
                float amplitude = 0.5f;
                float duration = 0.05f;
                device.SendHapticImpulse(channel, amplitude, duration);
            }
        }
    }
}
