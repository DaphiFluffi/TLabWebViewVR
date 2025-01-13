using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace GooglyEyesGames.TicTacToe
{
    public class InputFieldToKeyboardCommunicator : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            KeyboardManager.instance.inputField = GetComponent<TMP_InputField>();
        }
    }
}

