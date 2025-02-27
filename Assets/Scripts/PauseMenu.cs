using GLTF.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject m_settings;
    [SerializeField] GameMode m_gameMode;

    public void OnResumeClick()
    {
        m_gameMode.Back();
    }

    public void OnSettingsClick()
    {
        m_settings.SetActive(true);
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
