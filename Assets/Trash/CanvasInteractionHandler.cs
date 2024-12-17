using Oculus.Interaction;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

public class CanvasInteractionHandler : MonoBehaviour
{
    // Reference to your OVRCameraRig or OVRInputModule
    public OVRCameraRig cameraRig;
    public Text debugText;
    void Update()
    {
        // Check if there's a current pointer event
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            // Get the GameObject currently under the pointer
            GameObject pointerObject = EventSystem.current.currentSelectedGameObject;

            if (pointerObject != null)
            {
                // Get the PointableCanvas if the object is part of a UI
                PointableCanvas pointableCanvas = pointerObject.GetComponentInParent<PointableCanvas>();

                if (pointableCanvas != null)
                {
                    // Print or use the name of the PointableCanvas
                    debugText.text = ($"Interacting with PointableCanvas: {pointableCanvas.name}");
                }
            }
        }
    }
}
