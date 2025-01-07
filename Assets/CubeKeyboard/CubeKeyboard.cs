using UnityEngine;
using UnityEngine.UI;

namespace Normal.UI {
    public class CubeKeyboard : MonoBehaviour {
        public delegate void CubeKeyPressedDelegate(CubeKeyboard keyboard, string keyPress);
        public event CubeKeyPressedDelegate keyPressed;

        [SerializeField]
        private GameObject  _letters;

        [SerializeField]
        private GameObject  _numbers;

        public GameObject _shiftedLetters;
        public GameObject _symbols;
        public Text debugText;

        [SerializeField]
        private CubeKeyboardKey _layoutSwapKey;


        private CubeKeyboardMallet[] _mallets;
        private CubeKeyboardKey[]    _keys;

       // private bool _shift = false;
       // public  bool  shift { get { return _shift; } set { SetShift(value); } }
        private bool shifted = false;
        private bool letterLayout;
        public enum Layout {
            Letters,
            Numbers,
            Symbols
        };

        private Layout _layout = Layout.Letters;
        public  Layout  layout { get { return _layout; } set { SetLayout(value); } }

        void Awake() {
            _mallets = GetComponentsInChildren<CubeKeyboardMallet>(true);
            _keys    = GetComponentsInChildren<CubeKeyboardKey>(true);

            foreach (CubeKeyboardMallet mallet in _mallets)
                mallet._keyboard = this;

            foreach (CubeKeyboardKey key in _keys)
                key._keyboard = this;
        }

        // Internal
        public void _MalletStruckCubeKeyboardKey(CubeKeyboardMallet mallet, CubeKeyboardKey key)
        {
            // Did we hit the key for another keyboard?
            if (key._keyboard != this)
                return;

            // Trigger key press animation
            key.KeyPressed();

            // Fire key press event
            if (keyPressed != null)
            {
                string keyPress = key.GetCharacter();

                bool shouldFireKeyPressEvent = true;

                if (keyPress == "\\s")
                {

                    if (_letters.activeSelf || _shiftedLetters.activeSelf)
                    {
                        shifted = !shifted;

                        if (shifted)
                        {
                            _shiftedLetters.SetActive(true);
                            _letters.SetActive(false);
                            debugText.text = "Show Normal Letters";
                        }
                        else
                        {
                            _shiftedLetters.SetActive(false);
                            _letters.SetActive(true);
                            debugText.text = "Show Shifted Letters";
                        }

                        debugText.text += "Shift " + shifted;
                    }
                    shouldFireKeyPressEvent = false;
                }
                else if (keyPress == "\\l")
                {
                    // Layout swap
                    CycleLayout();
                    shouldFireKeyPressEvent = false;
                }
                else if (keyPress == "\\b")
                {
                    // Backspace
                    keyPress = "\b";
                }
                else if (keyPress == "\\n")
                {
                    // Enter
                    keyPress = "\n";
                }
                else if (keyPress == "\\t")
                {
                    // Tab
                    keyPress = "\t";
                }
                else if (keyPress == "upArrow")
                {
                    // Up Arrow
                    keyPress = "upArrow";
                }
                else if (keyPress == "downArrow")
                {
                    // Down Arrow
                    keyPress = "downArrow";
                }
                else if (keyPress == "leftArrow")
                {
                    // Left Arrow
                    keyPress = "leftArrow";
                }
                else if (keyPress == "rightArrow")
                {
                    // Right Arrow
                    keyPress = "rightArrow";
                }
                else
                {
                    // Turn off shift after typing a letter
                    /*if (shifted && layout == Layout.Letters)
                        debugText.text = "Turn off shift after typing a letter";
                    shifted = false;*/
                }

                if (shouldFireKeyPressEvent)
                    keyPressed(this, keyPress);
            }
        }

        void SetLayout(Layout layout) {
            if (layout == _layout)
                return;

            if (layout == Layout.Letters) {
                // Swap layouts
                _letters.SetActive(true);
                _numbers.SetActive(false);
                _symbols.SetActive(false);

                // Update layout swap key
                _layoutSwapKey.displayCharacter      = "123";
                _layoutSwapKey.shiftDisplayCharacter = "123";
                _layoutSwapKey.RefreshDisplayCharacter();
            } else if (layout == Layout.Numbers) {
                // Swap layouts
                _letters.SetActive(false);
                _numbers.SetActive(true);
                _symbols.SetActive(false);

                // Update layout swap key
                _layoutSwapKey.displayCharacter      = "{[]}";
                _layoutSwapKey.shiftDisplayCharacter = "{[]}";
                _layoutSwapKey.RefreshDisplayCharacter();
            } else if (layout == Layout.Symbols) {
                // Swap layouts
                _letters.SetActive(false);
                _numbers.SetActive(false);
                _symbols.SetActive(true);

                // Update layout swap key
                _layoutSwapKey.displayCharacter = "abc";
                _layoutSwapKey.shiftDisplayCharacter = "abc";
                _layoutSwapKey.RefreshDisplayCharacter();
            }

            _layout = layout;
        }

        void CycleLayout()
        {
            if (_layout == Layout.Letters)
            {
                // Reset the shifted state
                shifted = false;

                // Hide shifted letters and switch to numbers
                _shiftedLetters.SetActive(false);
                _letters.SetActive(false);
                SetLayout(Layout.Numbers);
            }
            else if (_layout == Layout.Numbers)
            {
                SetLayout(Layout.Symbols);
            }
            else if (_layout == Layout.Symbols)
            {
                // Reset the shifted state when cycling back to letters
                shifted = false;

                // Make sure normal letters are shown
                _shiftedLetters.SetActive(false);
                _letters.SetActive(true);
                SetLayout(Layout.Letters);
            }
        }
    }
}
