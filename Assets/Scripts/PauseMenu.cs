using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameMode m_gameMode;

    public void OnResumeClick()
    {
        m_gameMode.Back();
    }

    public void OnSettingsClick()
    {
        m_gameMode.GoToSettings();
    }

    public void OnBackClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
