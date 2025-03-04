using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown m_dropdown;
    [SerializeField] private GameMode m_gameMode;

    private void Start()
    {
        int index = 0;
        switch (Screen.width)
        {
            case 2560:
                index = 0;
                break;
            case 1920:
                index = 1;
                break;
            case 1280:
                index = 2;
                break;
        }
        m_dropdown.value = index;
    }

    public void SetRes()
    {
        switch (m_dropdown.value)
        {
            case 0:
                Screen.SetResolution(2560, 1440, true);
                break;
            case 1:
                Screen.SetResolution(1920, 1080, true);
                break;
            case 2:
                Screen.SetResolution(1280, 720, true);
                break;
        }
    }

    public void Close()
    {
        m_gameMode.Back();
    }

    public void CloseMain()
    {
        gameObject.SetActive(false);
    }
}
