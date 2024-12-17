using System;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class PizzaChangeKeyboard : MonoBehaviour
{
    public GameObject lowerCase;
    public GameObject upperCase;
    public GameObject numpad;
    public GameObject controls;
    public GameObject menu;
    public Text debugText;
    
    private int sliceIndex = 0;
    private Transform selectedSlice;
    private GameObject currentlyActiveKeyboard;
    private Color oldColor = Color.black;
    private Transform lastHighlightedSlice = null;
    private int currentKeyboardIndex = 0; // 0 = lowercase, 1 = uppercase, 2 = numpad, 3= controls
    private GameObject[] keyboards;
    private bool menuActive = false;

    private void Start()
    {
        keyboards = new GameObject[] { lowerCase, upperCase, numpad, controls };
        menuActive = true;
        menu.SetActive(menuActive);
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two)) { 
            menuActive = !menuActive; 
            menu.SetActive(menuActive); 
            if (!menuActive) { 
                for (int i = 0; i < keyboards.Length; i++) { 
                    keyboards[i].SetActive(false); 
                } 
            } 
        }
        // Right joystick for slice selection
        Vector2 rightJoystickInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick); // Secondary = Right
        if (rightJoystickInput.magnitude > 0.15f) // Only if joystick is pushed far enough
        {
            float angle = Mathf.Atan2(rightJoystickInput.y, rightJoystickInput.x) * Mathf.Rad2Deg;
            debugText.text = "Raw Angle " + angle;
            if (angle < 0)
            {
                angle += 360; // Normalize angle to be in the range 0-360
            }
            angle += 270; // rotate coordinate system by 270 deg 
            angle %= 360;
            debugText.text += "Changed Angle " + angle;

            sliceIndex = Mathf.FloorToInt(angle / (360f / 4)); // 0 to 3 

            // to clockwise
            sliceIndex = 3 - sliceIndex;
            selectedSlice = menu.transform.Find((sliceIndex + 1).ToString()); // names of obj is 1 - 4 
            debugText.text += "selectedSlice " + selectedSlice;

            if (selectedSlice != lastHighlightedSlice)
            {
                ClearHighlight(lastHighlightedSlice, oldColor); // Clear previous slice highlight
                HighlightSlice(selectedSlice);
                lastHighlightedSlice = selectedSlice; // Update last highlighted slice
                
            } 
        }
        if (OVRInput.GetDown(OVRInput.Button.One) && menu.activeInHierarchy)
        {
            ActivateKeyboard(sliceIndex);
        }
    }

    void HighlightSlice(Transform slice)
    {

        if (slice != null)
        {
            this.oldColor = slice.GetComponent<Image>().color;
            Color lightRed = new Color(255, 127, 127); // light red 
            slice.GetComponent<Image>().color = Color.magenta;
        }
        else
        {
            Debug.Log("no slice found");

        }
    }

    void ClearHighlight(Transform slice, Color color)
    {
        if (slice != null)
        {
            if (color != Color.black)
            {
                slice.GetComponent<Image>().color = color;
            }

        }
    }
    private void ActivateKeyboard(int index)
    {
       
        // enable selected keyboard in hierarchy
        for (int i = 0; i < keyboards.Length; i++)
        {
            keyboards[i].SetActive(i == index);
        }
        currentlyActiveKeyboard = keyboards[index];

        menuActive = false;
        // hide menu
        menu.SetActive(menuActive);
    }

}
