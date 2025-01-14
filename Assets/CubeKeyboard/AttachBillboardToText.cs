using UnityEngine.UI;
using UnityEngine;

public class AttachBillboardToText : MonoBehaviour
{
    void Start()
    {
        Text[] textObjects = this.GetComponentsInChildren<Text>();

        foreach (Text text in textObjects)
        {
            if (text.gameObject.GetComponent<Billboard>() == null) { 
                text.gameObject.AddComponent<Billboard>();
            }
        }
    }

}
