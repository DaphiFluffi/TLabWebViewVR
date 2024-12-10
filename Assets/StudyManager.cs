using UnityEngine;
using TMPro;

public class StudyObjectManager : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public string defaultActiveName;
    public GameObject[] studyObjects;

    void Start()
    {
        dropdown.options[dropdown.value].text = defaultActiveName;
        foreach (GameObject obj in studyObjects)
        {
            if (obj.name == defaultActiveName)
            {
                obj.SetActive(true);
            }
            else
            {
                obj.SetActive(false);
            }
        }
        dropdown.onValueChanged.AddListener(delegate { OnDropdownValueChanged(); });
}

void OnDropdownValueChanged()
    {
        string selectedName = dropdown.options[dropdown.value].text;

        // Enable the selected object and disable all others
        foreach (GameObject obj in studyObjects)
        {
            if (obj.name == selectedName)
            {
                obj.SetActive(true); 
            }
            else
            {
                obj.SetActive(false);
            }
        }
    }
}
