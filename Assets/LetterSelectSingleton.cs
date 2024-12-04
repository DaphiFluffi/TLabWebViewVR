using System.Collections;
using TLab.Android.WebView;
using UnityEngine;

public class LetterSelectSingleton : MonoBehaviour
{

    public static LetterSelectSingleton Instance { get; private set; } // Singleton
    public WebViewInputField m_webview_component;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // can be used to switch input field windows
    public void SetActiveInputField(WebViewInputField webViewInputField)
    {
        m_webview_component = webViewInputField;
    }

    public void KeyPressed(string keyPress)
    {
        if (keyPress == "delete")
        {
            // Backspace
            m_webview_component.OnBackSpacePressed();
        }
        else if (keyPress == "space")
        {
            // Space
            m_webview_component.OnKeyPressed(" ");
        }
        else if (keyPress == "enter")
        {
            // Enter
            m_webview_component.OnEnterPressed();
        }
        else if (keyPress == "tab")
        {
            // Tab = 4 spaces
            for (int i = 0; i < 4; i++)
            {
                m_webview_component.OnKeyPressed(" ");
            }
        }
        else if (keyPress == "upArrow")
        {
            // UpArrow
            m_webview_component.OnUpArrowPressed();
        }
        else if (keyPress == "downArrow")
        {
            // DownArrow
            m_webview_component.OnDownArrowPressed();
        }
        else if (keyPress == "leftArrow")
        {
            // LeftArrow
            m_webview_component.OnLeftArrowPressed();
        }
        else if (keyPress == "rightArrow")
        {
            // RightArrow
            m_webview_component.OnRightArrowPressed();
        }
        else
        {

            m_webview_component.OnKeyPressed(keyPress);
        }
    }
}