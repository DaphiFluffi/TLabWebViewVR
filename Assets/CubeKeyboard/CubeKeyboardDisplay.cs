using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TLab.Android.WebView;
//using InGameCodeEditor;

namespace Normal.UI {
    public class CubeKeyboardDisplay : MonoBehaviour {

        [SerializeField]
        private TMP_InputField _inputField;

        [SerializeField]
        private CubeKeyboard _keyboard;
        public  CubeKeyboard  keyboard { get { return _keyboard; } set { SetCubeKeyboard(value); } }
        public WebViewInputField m_webview_component;

        void Awake() {
            StartObservingCubeKeyboard(_keyboard);
            //codeEditor = GameObject.FindObjectOfType<CodeEditor>();
        }

        private void Start()
        {
            m_webview_component = FindAnyObjectByType<WebViewInputField>();
        }

        void OnDestroy() {
            StopObservingCubeKeyboard(_keyboard);
        }

        public void ChangeWebview(WebViewInputField webview_component)
        {
            m_webview_component = webview_component;
        }

        void SetCubeKeyboard(CubeKeyboard keyboard) {
            if (keyboard == _keyboard)
                return;

            StopObservingCubeKeyboard(_keyboard);
            StartObservingCubeKeyboard(keyboard);

            _keyboard = keyboard;
        }

        void StartObservingCubeKeyboard(CubeKeyboard keyboard) {
            if (keyboard == null)
                return;

            keyboard.keyPressed += KeyPressed;
        }

        void StopObservingCubeKeyboard(CubeKeyboard keyboard) {
            if (keyboard == null)
                return;

            keyboard.keyPressed -= KeyPressed;
        }

        void KeyPressed(CubeKeyboard keyboard, string keyPress) {
            //string text = _text.text;
            // todo uncomment for cube keyboard
            _inputField.Select(); // Select the input field
            _inputField.ActivateInputField(); // Activate the input field

            string text = _inputField.text;

            if (keyPress == "\b") {
                // Backspace
                if (text.Length > 0) { 
                    text = text.Remove(text.Length - 1); 
                }
                m_webview_component.OnBackSpacePressed();
            }
            else if (keyPress == "\n"){
                // Enter
                text += "\n"; // Append a new line to the input field text
                _inputField.caretPosition = _inputField.text.Length; // Move the caret to the end
                m_webview_component.OnEnterPressed();
            }
            else if (keyPress == "\t")
            {
                // Tab = 4 spaces
                for(int i = 0; i < 4; i++)
                {
                    m_webview_component.OnKeyPressed(" ");
                }
            }
            else if(keyPress == "upArrow")
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
            else {
                // Regular key press
                text += keyPress;
                _inputField.caretPosition = _inputField.text.Length; // Move the caret to the end
                m_webview_component.OnKeyPressed(keyPress);
            }

            _inputField.text = text;
        }
    }
}
