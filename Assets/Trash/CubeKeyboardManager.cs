using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeKeyboardManager : MonoBehaviour
{
    public Transform head;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = head.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
