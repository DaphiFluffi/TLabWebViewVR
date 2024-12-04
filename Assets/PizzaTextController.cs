using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PizzaTextController : MonoBehaviour
{
    public Text debugText;
    //public OVRInput.Button mainButton = OVRInput.Button.PrimaryHandTrigger;

    private Transform lastHighlightedSlice = null;
    private Color oldColor  = Color.black;
    private Transform selectedSlice;
    private string selectedLetter;
    private string lastHighlightedLetter = null;
    private float valueToAdd = 0;

    void Update()
    {
        // Right joystick for slice selection
        Vector2 rightJoystickInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick); // Secondary = Right
        if (rightJoystickInput.magnitude > 0.15f) // Only if joystick is pushed far enough
        {
            float angle = Mathf.Atan2(rightJoystickInput.y, rightJoystickInput.x) * Mathf.Rad2Deg;
            if (angle < 0)
            {
                angle += 360; // Normalize angle to be in the range 0-360
            }
            angle += 270; // rotate coordinate system by 270 deg 
            angle %= 360;
            int sliceIndex = Mathf.FloorToInt(angle / (360f / 7)); // 0 to 6 
            debugText.text = "Joystick angle: " + angle + " sliceindex " + sliceIndex;

            // to clockwise
            sliceIndex = 6 - sliceIndex;
            selectedSlice = this.transform.Find((sliceIndex + 1).ToString()); // names of obj is 1 - 7 
            if (selectedSlice != lastHighlightedSlice)
            {
                HighlightLetter(lastHighlightedSlice, lastHighlightedLetter, Color.white); // clear previous letter highlight
                ClearHighlight(lastHighlightedSlice, oldColor); // Clear previous slice highlight
                HighlightSlice(selectedSlice);
                lastHighlightedSlice = selectedSlice; // Update last highlighted slice
            }
        }

        // Left joystick for letter selection
        Vector2 leftJoystickInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        if (leftJoystickInput.magnitude > 0.15f)
        {
            float letterAngle = Mathf.Atan2(leftJoystickInput.y, leftJoystickInput.x) * Mathf.Rad2Deg;
            if (letterAngle < 0)
            {
                letterAngle += 360;
            }
            //debugText.text = $"Raw Letter Angle: {letterAngle}";

            letterAngle += 45; // rotate coordinate system
            letterAngle %= 360;

            //debugText.text += $" Adjusted Letter Angle: {letterAngle}";

            // letter selection in four slices
            Button[] fourButtons = selectedSlice.GetComponentsInChildren<Button>();

            selectedLetter = fourButtons[0].name;

            selectedLetter = fourButtons[(int) (letterAngle / 90)].name; // 0/90 = index 0, 90/90 = index 1, 180/90 = index 2, 270/90 = index 3 
            /*if (letterAngle > 45 && letterAngle <= 135)
            {
                selectedLetter = fourButtons[1].name;
            }
            else if (letterAngle > 135 && letterAngle <= 225)
            {
                selectedLetter = fourButtons[3].name;
            }
            else if (letterAngle > 225 && letterAngle <= 315)
            {
                selectedLetter = fourButtons[2].name;
            }*/
            //debugText.text = "currentLetter " + selectedLetter;
            //debugText.text = "selectedLetter != lastHighlightedLetter" + (selectedLetter != lastHighlightedLetter) + " old " + lastHighlightedLetter + " new " + selectedLetter;
            // Highlight Letter red, unhighlight white
            if (selectedLetter != lastHighlightedLetter)
            {

                HighlightLetter(selectedSlice, lastHighlightedLetter, Color.white); // clear previous highlight
                HighlightLetter(selectedSlice, selectedLetter, Color.red); // highlight current letter
                lastHighlightedLetter = selectedLetter; // Update last highlighted slice
            }
        }

        // Trigger input to enter letter
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            EnterLetter(selectedSlice, selectedLetter);
        }


    }

    void HighlightSlice(Transform slice) 
    {

        if (slice != null)
        {
            this.oldColor = slice.GetComponent<Image>().color;
            Color lightRed = new Color(255, 127, 127); // light red 
            slice.GetComponent<Image>().color = Color.green;
        }
        else
        {
            Debug.Log("no slice found");
            debugText.text = "no slice found";

        }
    }

    void ClearHighlight(Transform slice, Color color)
    {
        if (slice != null)
        {
            if(color != Color.black)
            {
                slice.GetComponent<Image>().color = color;
            }
            
        }
    }
    void HighlightLetter(Transform slice, string letter, Color color)
    {
        if (slice == null)
        {
            debugText.text = "No slice selected";
            return;
        }

        if (letter == null)
        {
            debugText.text = "No letter selected";
            return;
        }

        Transform buttonToHighlight = slice.Find(letter); // Find the letter
        if (buttonToHighlight == null)
        {
            debugText.text = $"Letter '{letter}' not found in slice '{slice.name}'";
            return;
        }

        TextMeshProUGUI textComponent = buttonToHighlight.GetComponentInChildren<TextMeshProUGUI>();
        if (textComponent == null)
        {
            debugText.text = $"TextMeshProUGUI component not found in letter '{letter}'";
            return;
        }

        textComponent.color = color;
        debugText.text = $"Highlighted letter '{letter}' with color {color}";
    }


    void EnterLetter(Transform slice, string letter) {
        if (letter == "" || letter == null)
        {
            debugText.text = "no letter";
        }
        else
        {
            debugText.text = "enterLetter " + letter;
            LetterSelectSingleton.Instance.KeyPressed(letter);

        }
    }

    
}
