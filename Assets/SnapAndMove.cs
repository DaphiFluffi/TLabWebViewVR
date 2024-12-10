using UnityEngine;

public class SnapAndMove : MonoBehaviour
{
    public Transform cubeKeyboard;
    public Transform drumstickHead;
    public Material highlightMaterial;
    public Material defaultMaterial;
    public Renderer keyboardRenderer;


    private bool isSnapped = false; 

    //private Vector3 offset; // Offset between the head and the keyboard when snapped

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
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
}
