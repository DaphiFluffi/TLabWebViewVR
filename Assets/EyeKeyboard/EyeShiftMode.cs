using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EyeShiftMode : MonoBehaviour
{
    private bool shifted = false;
    public GameObject _shiftedLetters;
    public GameObject _normalLetters;

    void Start()
    {
        _shiftedLetters.SetActive(false);
        _normalLetters.SetActive(true);
    }

    public void OnShift()
    {
        if (!shifted)
        {
            _shiftedLetters.SetActive(true);
            _normalLetters.SetActive(false);
        }
        else
        {
            _shiftedLetters.SetActive(false);
            _normalLetters.SetActive(true);
        }
        shifted = !shifted;
    }
}