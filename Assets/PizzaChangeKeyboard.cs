using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//[ExecuteInEditMode]
public class PizzaChangeKeyboard : MonoBehaviour
{
    public GameObject lowerCase;
    public GameObject upperCase; // not upper case yet
    public GameObject numpad;

    private GameObject currentlyActiveKeyboard;
    private int currentKeyboardIndex = 0; // 0 = lowercase, 1 = uppercase, 2 = numpad
    private GameObject[] keyboards; // Array to manage keyboards

    private void Start()
    {
        keyboards = new GameObject[] { lowerCase, upperCase, numpad };

        ActivateKeyboard(currentKeyboardIndex);

        // on Execute in Edit MOde
        // set to upper case
        /*Button[] allLowerCaseButtons = upperCase.GetComponentsInChildren<Button>();
        foreach (Button button in allLowerCaseButtons)
        {
            string oldButtonLetter = button.name;
            if (oldButtonLetter != "space" && oldButtonLetter != "delete") 
            { 
                string upperCaseLetter = oldButtonLetter.ToUpper();
                button.name = upperCaseLetter;
                button.GetComponentInChildren<TextMeshProUGUI>().text = upperCaseLetter;
            }
        }*/
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            currentKeyboardIndex = (currentKeyboardIndex + 1) % keyboards.Length; // modulo indices 0 -> 1 -> 2 -> 0
            ActivateKeyboard(currentKeyboardIndex);
        }
    }

    private void ActivateKeyboard(int index)
    {
        for (int i = 0; i < keyboards.Length; i++)
        {
            keyboards[i].SetActive(i == index);
        }
        currentlyActiveKeyboard = keyboards[index];
    }

}
