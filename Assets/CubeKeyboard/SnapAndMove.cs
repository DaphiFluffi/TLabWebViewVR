using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Normal.UI;

public class SnapAndMove : MonoBehaviour
{
    public Transform cubeKeyboard;
    public Transform drumstickHead;
    public Material highlightMaterial;
    public Material defaultMaterial;
    public Renderer keyboardRenderer;
    public OVRInput.Controller controller = OVRInput.Controller.RTouch;
    public Text debugText;
    public CubeKeyboardDisplay cubeKeyboardDisplay;

    private TMP_InputField _inputField;


    private bool isSnapped = false;
    private bool isButtonHeld = false; // Tracks if the A button is held

    void Update()
    {
        bool isAButtonPressed = OVRInput.Get(OVRInput.Button.One, controller);

        if (isAButtonPressed && !isButtonHeld)
        {
            // A button has just been pressed
            isButtonHeld = true;
            Unsnap();

        }
        else if (!isAButtonPressed && isButtonHeld)
        {
            // A button has just been released
            isButtonHeld = false;
            Snap();
            // Write a space and clear the input field

            WriteSpaceAndClearInput();

        }

        /*if (OVRInput.GetDown(OVRInput.Button.One))
        {
            if (isSnapped)
            {
                Unsnap();
            }
            else
            {
                Snap();
            }
        }
        */
        if (isSnapped)
        {
            cubeKeyboard.position = drumstickHead.position;
            cubeKeyboard.rotation = drumstickHead.rotation;
        }
    }

    void Snap()
    {
        isSnapped = true;
        //offset = cubeKeyboard.position - drumstickHead.position; // Calculate the initial offset
        keyboardRenderer.material = highlightMaterial;
    }

    void Unsnap()
    {
        isSnapped = false;
        keyboardRenderer.material = defaultMaterial;
    }

    void WriteSpaceAndClearInput()
    {
        debugText.text = "write whitespace techincally";
        cubeKeyboardDisplay.PressSpaceAndClearTMPInputField();

    }
}
