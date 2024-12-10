using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeSwitchLayout : MonoBehaviour
{

    public GameObject _abc;
    public GameObject _123;

    void Start()
    {
        _abc.SetActive(true);
        _123.SetActive(false);
    }


    public void OnSwitch()
    {
        bool isAbcActive = _abc.activeInHierarchy;

        _abc.SetActive(!isAbcActive);
        _123.SetActive(isAbcActive);
    }
}
