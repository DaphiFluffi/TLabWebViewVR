using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChanger : MonoBehaviour
{
    public Button button;
    public Button leetButton;
    public Button googleButton;

    private Image leetButtonImage;
    private Image googleButtonImage;
    private bool isClicked = false;
    private Image buttonImage;

    void Start()
    {
        buttonImage = button.GetComponent<Image>();
        leetButtonImage = leetButton.GetComponent<Image>();
        googleButtonImage = googleButton.GetComponent<Image>();

        buttonImage.color = Color.white;
        leetButtonImage.color = Color.white;
        googleButtonImage.color = Color.white;

        button.onClick.AddListener(ToggleColor);
        leetButton.onClick.AddListener(() => HighlightButton(leetButton));
        googleButton.onClick.AddListener(() => HighlightButton(googleButton));
    }

    void ToggleColor()
    {
        isClicked = !isClicked;
        buttonImage.color = isClicked ? Color.red : Color.green;
    }

    void HighlightButton(Button clickedButton)
    {
        if (clickedButton == leetButton)
        {
            leetButtonImage.color = Color.green;
            googleButtonImage.color = Color.white;
        }
        else if (clickedButton == googleButton)
        {
            googleButtonImage.color = Color.green;
            leetButtonImage.color = Color.white;
        }
    }
}
