using UnityEngine;

public class SnapAndMove : MonoBehaviour
{
    public Transform cubeKeyboard; // Parent transform of cube of cubes
    public Transform drumstickHead; // The head attached to the controller
    public float snapDistance = 0.1f; // Distance threshold for snapping
    public Material highlightMaterial;
    public Material defaultMaterial;
    public Renderer keyboardRenderer;


    private bool isSnapped = false; // Whether the keyboard is snapped to the drumstick

    //private Vector3 offset; // Offset between the head and the keyboard when snapped

    void Update()
    {
        if (isSnapped)
        {
            // Move and tilt the keyboard with the drumstick
            cubeKeyboard.position = drumstickHead.position;// + offset;
            cubeKeyboard.rotation = drumstickHead.rotation;
        }
        else
        {
            // Check snapping condition
            if (OVRInput.GetDown(OVRInput.Button.One)) // Replace with VR controller button check
            {
                Snap();
            }
        }

        // Unsnap when button is pressed
        if (isSnapped && OVRInput.GetDown(OVRInput.Button.Two)) // Replace with VR controller button check
        {
            Unsnap();
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
}
