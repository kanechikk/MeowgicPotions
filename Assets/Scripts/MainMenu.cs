using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject continueBtn;
    public GameObject settings;
    private GameManager m_gameManager;

    private void Start()
    {
        m_gameManager = FindAnyObjectByType<GameManager>();

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

        List<Ingredient> ingredients = new List<Ingredient>
        {
            Array.Find(m_gameManager.itemsDB.ingredients, x => x.itemName == "Bubble Fruit"),
            Array.Find(m_gameManager.itemsDB.ingredients, x => x.itemName == "Bubble Fruit"),

            Array.Find(m_gameManager.itemsDB.ingredients, x => x.itemName == "Earth Coral"),
            Array.Find(m_gameManager.itemsDB.ingredients, x => x.itemName == "Earth Coral"),

            Array.Find(m_gameManager.itemsDB.ingredients, x => x.itemName == "Sky Snakes"),
            Array.Find(m_gameManager.itemsDB.ingredients, x => x.itemName == "Sky Snakes"),
        };

        Potion potion = Array.Find(m_gameManager.itemsDB.potions, x => x.itemName == "Health");

        GameManager.instance.player.Reset(500, ingredients.ToArray(), potion);

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
