using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class ControllerSlowdownChecker : MonoBehaviour
{
    public OVRInput.Controller controller = OVRInput.Controller.RTouch; // Adjust for left or right controller
    public Text debugText;
    public Material highlightMaterial;
    public Material defaultMaterial;
    public Normal.UI.KeyboardMallet keyboardMallet;
    public Normal.UI.Keyboard _keyboard;
    public XRNode xRNode;
    public OVRInput.Button button = OVRInput.Button.PrimaryHandTrigger;
    // Change the material color based on velocity for feedback
    public Material material;
    public float alpha;


    private Collider currentCollider = null; // Tracks the collider the controller is interacting with
    private bool letterSelected = false;    // Tracks if the letter has already been selected
    private Vector3 lastPosition; // To store the previous frame's position

    void Start()
    { 
        lastPosition = keyboardMallet.transform.position;
        material = new Material(highlightMaterial);
        alpha = highlightMaterial.color.a;

}

void Update()
    {
        if (currentCollider != null)
        {
            // Because isKinemaic disables the ability to track velocity
            Vector3 currentPosition = keyboardMallet.transform.position;
            Vector3 velocity = (currentPosition - lastPosition) / Time.deltaTime;

            // Update last position for the next frame
            lastPosition = currentPosition;

            // Set the new color with the desired RGB and the alpha from the reference material
            if (velocity.magnitude < 0.01f && !letterSelected) // Only select if stationary and not already selected
            {
                material.color = new Color(Color.green.r, Color.green.g, Color.green.b, alpha);
                ChangeButtonColor(currentCollider, material); // Stationary
                SelectLetter(currentCollider);
            }
            else
            {
                ChangeButtonColor(currentCollider, defaultMaterial);

                //material.color = Color.black;
                //ChangeButtonColor(currentCollider, material); // Swipe
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Store the collider when entering
        debugText.text = "Entered collider: " + other.name;
        //ChangeButtonColor(other, highlightMaterial);

        currentCollider = other;
        letterSelected = false; // Reset flag on entering a new collider
    }

    void OnTriggerExit(Collider other)
    {
        if (other == currentCollider)
        {
            debugText.text = "Exited collider: " + other.name;

            // Reset the material to default
            //ChangeButtonColor(other, defaultMaterial);

            currentCollider = null;
            letterSelected = false; // Allow new selection
        }
    }

    void SelectLetter(Collider other)
    {
        if (_keyboard == null)
        {
            Debug.LogError("No keyboard attached to the mallet.");
            return;
        }

        Rigidbody keyRigidbody = other.attachedRigidbody;
        if (keyRigidbody == null)
            return;

        Normal.UI.KeyboardKey key = keyRigidbody.GetComponent<Normal.UI.KeyboardKey>();

        if (key != null && !letterSelected) // Check if the letter has not been selected
        {
            if (key.IsMalletHeadInFrontOfKey(keyboardMallet))
            {
                _keyboard._MalletStruckKeyboardKey(keyboardMallet, key);
                //ChangeButtonColor(other, highlightMaterial); // Change to red
                TriggerHapticPulse();

                letterSelected = true; // Mark as selected to avoid duplicate actions
            }
        }
    }


    void ChangeButtonColor(Collider buttonCollider, Material newMaterial)
    {
        Renderer renderer = buttonCollider.transform.parent.GetComponentInChildren<Renderer>();
        if (renderer != null)
        {
            renderer.material = newMaterial;
        }
    }

    void TriggerHapticPulse()
    {
        var device = InputDevices.GetDeviceAtXRNode(xRNode);
        if (device.TryGetHapticCapabilities(out var capabilities) && capabilities.supportsImpulse)
        {
            device.SendHapticImpulse(0, 0.5f, 0.1f); // Channel 0, 50% amplitude, 0.1s duration
        }
    }
}
