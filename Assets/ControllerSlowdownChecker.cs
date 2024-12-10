using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using System.IO;

public class ControllerSlowdownChecker : MonoBehaviour
{
    public OVRInput.Controller controller = OVRInput.Controller.RTouch; // Adjust for left or right controller
    public Text debugText;
    public Material highlightMaterial;
    public Material defaultMaterial;
    public Normal.UI.CubeKeyboardMallet keyboardMallet;
    public Normal.UI.CubeKeyboard _keyboard;
    public XRNode xRNode;
    public OVRInput.Button button = OVRInput.Button.PrimaryHandTrigger;
    // Change the material color based on velocity for feedback
    //public Slider slider;
    public float sensitivity = 0.16f;

    private Material material;
    private Collider currentCollider = null; // Tracks the collider the controller is interacting with
    private bool letterSelected = false;    // Tracks if the letter has already been selected
    private Vector3 lastPosition; // To store the previous frame's position
    private StreamWriter file;
    private float alpha;


    void Start()
    {

        lastPosition = keyboardMallet.transform.position;
        material = new Material(highlightMaterial);
        alpha = highlightMaterial.color.a;

       
        /*if (slider == null)
        {
            slider = GetComponent<Slider>();
        } 

        slider.onValueChanged.AddListener(OnSliderValueChanged);

        */
        string fname = System.DateTime.Now.ToString("HH-mm-ss") + ".csv";
        string path = Path.Combine(Application.persistentDataPath, fname);
        file = new StreamWriter(path);
        /*filePath = Path.Combine("/mnt/sdcard/", "velocity_log.txt");
        writer = new StreamWriter(filePath, false);
        writer.WriteLine("Time,VelocityMagnitude");*/
    }

    void OnDestroy()
    {
        // Close the file when the script is destroyed
        file.Close();
    }

   /* void OnSliderValueChanged(float value)
    {
        sensitivity = value;
    }*/

    void Update()
    {


        //debugText.text = slider.value.ToString("0.000");
        Vector3 currentPosition = keyboardMallet.transform.position;
        Vector3 velocity = (currentPosition - lastPosition) / Time.deltaTime;
        debugText.text += "\n velocity: " + velocity.magnitude.ToString();

        float time = Time.time;
        float velocityMagnitude = velocity.magnitude;


        if (currentCollider != null)
        {
            lastPosition = currentPosition;

            if (velocity.magnitude < sensitivity && !letterSelected)
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

        file.WriteLine($"{time},{velocityMagnitude},{letterSelected}");

    }

    void OnTriggerEnter(Collider other)
    {
        // Store the collider when entering
        //  debugText.text = "Entered collider: " + other.name;
        //ChangeButtonColor(other, highlightMaterial);

        currentCollider = other;
        letterSelected = false; // Reset flag on entering a new collider
    }

    void OnTriggerExit(Collider other)
    {
        if (other == currentCollider)
        {
            // debugText.text = "Exited collider: " + other.name;

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

        Normal.UI.CubeKeyboardKey key = keyRigidbody.GetComponent<Normal.UI.CubeKeyboardKey>();

        if (key != null && !letterSelected)
        {
            if (key.IsMalletHeadInFrontOfCubeKey(keyboardMallet))
            {
                _keyboard._MalletStruckCubeKeyboardKey(keyboardMallet, key);
                //ChangeButtonColor(other, highlightMaterial); // Change to red
                TriggerHapticPulse();

                letterSelected = true;
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
