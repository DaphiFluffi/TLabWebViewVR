using Meta.XR.ImmersiveDebugger.UserInterface;
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

    private Collider currentCollider = null; // Tracks the collider the controller is interacting with
    private bool letterSelected = false;    // Tracks if the letter has already been selected

    void Update()
    {
        debugText.text = "is currentColliderNull ? " + (currentCollider == null);
        if (OVRInput.Get(button) && currentCollider != null && !letterSelected)
        {
            SelectLetter(currentCollider);
            letterSelected = true; // Mark letter as selected to prevent re-triggering
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Store the collider when entering
        debugText.text = "Entered collider: " + other.name;
        currentCollider = other;
        letterSelected = false; // Reset flag on entering a new collider
    }

    void OnTriggerStay(Collider other)
    {
        if (currentCollider == null && other != null)
        {
            debugText.text = "Staying inside collider: " + other.name;
            currentCollider = other;
            letterSelected = false; // Reset flag in case OnTriggerEnter was missed
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other == currentCollider)
        {
            debugText.text = "Exited collider: " + other.name;

            // Reset the material to default
            ChangeButtonColor(other, defaultMaterial);

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

        if (key != null)
        {
            if (key.IsMalletHeadInFrontOfKey(keyboardMallet))
            {
                _keyboard._MalletStruckKeyboardKey(keyboardMallet, key);
                ChangeButtonColor(other, highlightMaterial); // Change to red
                TriggerHapticPulse();
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
