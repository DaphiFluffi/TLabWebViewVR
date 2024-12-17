using UnityEngine;

namespace Normal.UI {
    public class CubeKeyboard : MonoBehaviour {
        public delegate void CubeKeyPressedDelegate(CubeKeyboard keyboard, string keyPress);
        public event CubeKeyPressedDelegate keyPressed;

        [SerializeField]
        private GameObject  _letters;

        [SerializeField]
        private GameObject  _numbers;

        [SerializeField]
        private CubeKeyboardKey _layoutSwapKey;

        [SerializeField]
        private GameObject _shiftedLetters;

        private CubeKeyboardMallet[] _mallets;
        private CubeKeyboardKey[]    _keys;

        private bool _shift = false;
        public  bool  shift { get { return _shift; } set { SetShift(value); } }

        public enum Layout {
            Letters,
            Numbers
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
        public void _MalletStruckCubeKeyboardKey(CubeKeyboardMallet mallet, CubeKeyboardKey key) {
            // Did we hit the key for another keyboard?
            if (key._keyboard != this)
                return;

            // Trigger key press animation
            key.KeyPressed();

            // Fire key press event
            if (keyPressed != null) {
                string keyPress = key.GetCharacter();

                bool shouldFireKeyPressEvent = true;

                if (keyPress == "\\s")
                {
                    // Shift
                    shift = !shift;
                    shouldFireKeyPressEvent = false;
                }
                else if (keyPress == "\\l")
                {
                    // Layout swap
                    if (layout == Layout.Letters)
                        layout = Layout.Numbers;
                    else if (layout == Layout.Numbers)
                        layout = Layout.Letters;
                    
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
                    // Fire key press event first
                    if (shift && layout == Layout.Letters)
                    {
                        keyPressed?.Invoke(this, keyPress);
                        shift = false; // Only reset shift after event is fired
                    }
                    else
                    {
                        keyPressed?.Invoke(this, keyPress);
                    }
                }

                if (shouldFireKeyPressEvent)
                    keyPressed(this, keyPress);
            }
        }

        void SetShift(bool shift)
        {
            if (shift == _shift)
                return;

            _shift = shift;

            // Toggle visibility of letter sets
            if (_layout == Layout.Letters)
            {
                _letters.SetActive(!_shift);       // Regular letters when shift is off
                _shiftedLetters.SetActive(_shift); // Shifted letters when shift is on
            }

            // Apply shift state to individual keys
            foreach (CubeKeyboardKey key in _keys)
                key.shift = shift;
        }

        void SetLayout(Layout layout)
        {
            if (layout == _layout)
                return;

            shift = false; // Reset shift state when layout changes

            if (layout == Layout.Letters)
            {
                // Show letters layout
                _letters.SetActive(true);
                _shiftedLetters.SetActive(false); // Ensure shifted letters are hidden
                _numbers.SetActive(false);

                // Update layout swap key
                _layoutSwapKey.displayCharacter = "123";
                _layoutSwapKey.shiftDisplayCharacter = "123";
                _layoutSwapKey.RefreshDisplayCharacter();
            }
            else if (layout == Layout.Numbers)
            {
                // Show numbers layout
                _letters.SetActive(false);
                _shiftedLetters.SetActive(false); // Ensure shifted letters are hidden
                _numbers.SetActive(true);

                // Update layout swap key
                _layoutSwapKey.displayCharacter = "abc";
                _layoutSwapKey.shiftDisplayCharacter = "abc";
                _layoutSwapKey.RefreshDisplayCharacter();
            }

            _layout = layout;
        }

    }
}
