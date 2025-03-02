using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject continueBtn;
    public GameObject settings;

    private void Start()
    {
        if (File.Exists(DataProcess.pathFileForPlayer))
        {
            continueBtn.GetComponent<Button>().interactable = true;
        }
        else
        {
            continueBtn.GetComponent<Button>().interactable = false;
        }
    }

    public void OnContinueClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnNewGameClick()
    {
        File.Delete(DataProcess.pathFileForDayData);
        File.Delete(DataProcess.pathFileForGarden);
        File.Delete(DataProcess. pathFileForPlayer);
        File.Delete(DataProcess.pathFileForQuests);
        GameManager.instance.player.Reset(500);

        OnContinueClick();
    }

    public void OnQuitClick()
    {
        GameManager.instance.QuitGame();
    }

    public void OnSettingsClick()
    {
        settings.SetActive(true);
    }
}
