using UnityEngine;

public class KeyDwellSelector : MonoBehaviour
{
    public Transform controllerTransform; // Reference to the controller's transform
    public float dwellThreshold = 0.01f; // Velocity threshold to consider "dwelling"
    public float dwellTime = 0.5f; // Time in seconds to dwell on a key before selecting it

    private float dwellTimer = 0.0f; // Timer to track dwell duration
    private bool isDwelling = false; // Whether we're dwelling on a key
    private Transform currentKey = null; // The key we're currently dwelling on

    void Update()
    {
        Vector3 controllerVelocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);

        // Check if velocity is below threshold
        if (controllerVelocity.magnitude < dwellThreshold)
        {
            isDwelling = true;
            dwellTimer += Time.deltaTime;
        }
        else
        {
            ResetDwell(); // Reset dwell if the controller is moving too fast
        }

        // Check if dwell time is reached and a key is selected
        if (isDwelling && dwellTimer >= dwellTime && currentKey != null)
        {
            SelectKey(currentKey);
            ResetDwell(); // Reset dwell timer after selection
        }
    }

    private void ResetDwell()
    {
        dwellTimer = 0.0f;
        isDwelling = false;
        currentKey = null;
    }

    private void SelectKey(Transform key)
    {
        // Trigger key selection logic
        Debug.Log("Key selected: " + key.name);
        // Add your code here to add the letter to the input buffer
    }
}
