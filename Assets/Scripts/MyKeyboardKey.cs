using System.Collections;
using System.Collections.Generic;
using TLab.Android.WebView;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class MyKeyboardKey : MonoBehaviour
{
    public string m_key_name;
    private WebViewInputField m_webview_component;
    private string m_key_upper_case;

    void Start()
    {
        Button button = GetComponent<Button>();

        if (m_key_name == null)
        {
            Debug.Log("has no key name");
        }
        m_key_upper_case = m_key_name.ToUpper();
        m_webview_component = FindAnyObjectByType<WebViewInputField>();
        button.onClick.RemoveAllListeners();

        // Add a listener to the button's onClick event
        button.onClick.AddListener(OnKey);
    }

    void OnKey()
    {
        m_webview_component.OnKeyPressed(m_key_name);
    }

}
