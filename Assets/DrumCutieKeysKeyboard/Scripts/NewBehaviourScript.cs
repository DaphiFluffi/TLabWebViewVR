using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;

    public void Debug()
    {
        textMeshProUGUI.text = "Worked";
    }
}
