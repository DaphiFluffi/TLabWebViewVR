using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GooglyEyesGames.TicTacToe
{
    public class KeyboardManager : MonoBehaviour
    {
        public static KeyboardManager instance;
        public Button shiftButton;
        public Button deleteButton;
        public Button spaceButton;
        private Image shiftButtonImage;

        public TMP_InputField inputField;

        private bool isShifted = false;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            spaceButton.onClick.AddListener(Space);
            deleteButton.onClick.AddListener(Delete);
            shiftButton.onClick.AddListener(Shifted);
            shiftButtonImage = shiftButton.gameObject.GetComponent<Image>();
        }

        private void Space()
        {
            inputField.text += " ";
        }
        private void Delete()
        {
            int length = inputField.text.Length - 1;
            inputField.text = inputField.text.Substring(0, length);
        }
        private void Shifted()
        {
            isShifted = !isShifted;

            if (isShifted)
            {
                shiftButtonImage.color = Color.yellow;
            }
            else
            {
                shiftButtonImage.color = Color.white;
            }
        }
    }
}

