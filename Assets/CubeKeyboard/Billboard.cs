using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        // Find the CenterEyeAnchor at runtime if not explicitly set
        if (target == null)
        {
            var centerEye = GameObject.Find("CenterEyeAnchor");
            if (centerEye != null)
                target = centerEye.transform;
        }
    }

    void Update()
    {
        if (target != null)
        {
            // Make the text face the camera
            transform.LookAt(target.position);

            // Optional: Reverse the object's facing direction
            transform.Rotate(0, 180, 0);
        }
    }
}
