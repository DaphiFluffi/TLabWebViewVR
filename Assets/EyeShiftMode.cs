using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EyeShiftMode : MonoBehaviour
{
    public Text debug;
    private bool shifted = false;

    public void OnShift()
    {
        Button[] allChars = this.GetComponentsInChildren<Button>();
        foreach (Button b in allChars)
        {
            if (b.name.Any(x => char.IsLetter(x)) && b.name.Length == 1)
            {
                string oldName = b.name;
                string newName = shifted ? oldName.ToLower() : oldName.ToUpper();

                b.name = newName;
                b.GetComponentInChildren<TextMeshProUGUI>().text = newName;

                string localNewName = newName;

                // Debugging: Check listener state
                debug.text = ($"Button {b.name} before clear: {b.onClick.GetPersistentEventCount()} listeners");

                // Update onClick listeners for each button
                b.onClick.RemoveAllListeners();
                debug.text = ($"Button {b.name} after clear: {b.onClick.GetPersistentEventCount()} listeners");

                b.onClick.AddListener(() =>
                {
                    debug.text = ($"Button {b.name} clicked, passing: {localNewName}");
                    LetterSelectSingleton.Instance.KeyPressed(localNewName);
                });

                debug.text = ($"Button {b.name} after add: {b.onClick.GetPersistentEventCount()} listeners");
            }
        }
        shifted = !shifted; // Toggle shift state
    }


}