using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TLab.Android.WebView;
//using InGameCodeEditor;

namespace Normal.UI {
    public class KeyboardDisplay : MonoBehaviour {
        //[SerializeField]
        //private Text _text;
        /*[SerializeField]
        private TextMeshProUGUI _textMeshPro;

        [SerializeField]
        private TextMeshProUGUI _backup;*/

        [SerializeField]
        private TMP_InputField _inputField;
        //public CodeEditor codeEditor;
        [SerializeField]
        private Keyboard _keyboard;
        public  Keyboard  keyboard { get { return _keyboard; } set { SetKeyboard(value); } }
        private WebViewInputField m_webview_component;
        void Awake() {
            StartObservingKeyboard(_keyboard);
            //codeEditor = GameObject.FindObjectOfType<CodeEditor>();
        }

        private void Start()
        {
            m_webview_component = FindAnyObjectByType<WebViewInputField>();
        }

        void OnDestroy() {
            StopObservingKeyboard(_keyboard);
        }

        void SetKeyboard(Keyboard keyboard) {
            if (keyboard == _keyboard)
                return;

            StopObservingKeyboard(_keyboard);
            StartObservingKeyboard(keyboard);

            _keyboard = keyboard;
        }

        void StartObservingKeyboard(Keyboard keyboard) {
            if (keyboard == null)
                return;

            keyboard.keyPressed += KeyPressed;
        }

        void StopObservingKeyboard(Keyboard keyboard) {
            if (keyboard == null)
                return;

            keyboard.keyPressed -= KeyPressed;
        }

        void KeyPressed(Keyboard keyboard, string keyPress) {
            //string text = _text.text;
            //_inputField.Select(); // Select the input field
            //_inputField.ActivateInputField(); // Activate the input field

            //string text = _inputField.text;

            if (keyPress == "\b") {
                // Backspace
                //if (text.Length > 0)
                //text = text.Remove(text.Length - 1);
                m_webview_component.OnBackSpacePressed();
            }
            else if (keyPress == "\n"){
                // Enter
                //text += "\n"; // Append a new line to the input field text
                //_inputField.caretPosition = _inputField.text.Length; // Move the caret to the end
                m_webview_component.OnEnterPressed();
            }
            else if (keyPress == "\t")
            {
                // Tab
                m_webview_component.OnKeyPressed("    ");
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
                //text += keyPress
                //_inputField.caretPosition = _inputField.text.Length; // Move the caret to the end
                m_webview_component.OnKeyPressed(keyPress);
            }

            //_inputField.text = text;
            //codeEditor.Refresh(true);
            //_text.text = text;
        }
    }
}
