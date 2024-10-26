using UnityEngine;

public class MyKeyboardManager : MonoBehaviour
{
    public GameObject m_abc;
    public GameObject m_123;
    // public GameObject m_ABC;

    public void ChangeKeyboard()
    {
        if (m_abc.activeSelf == true)
        {
            m_abc.SetActive(false);
            m_123.SetActive(true);
        }
        else if (m_123.activeSelf == true)
        {
            m_abc.SetActive(true);
            m_123.SetActive(false);
        }
    }

    public void Shift()
    {

    }
}
