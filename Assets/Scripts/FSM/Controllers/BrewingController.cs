using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class BrewingController : MonoBehaviour
{
    [SerializeField] private Cauldron m_cauldron;
    public Cauldron cauldron => m_cauldron;
    private Potion m_chosenPotion;
    [SerializeField] private PotionBookController m_potionBookController;
    [SerializeField] private GameMode m_gameMode;
    [SerializeField] private Item m_itemSample;
    [SerializeField] private UIWinLose m_uiWinLose;

    private void Start()
    {
        //подписываемся на событие, которое реагирует на выбор зелья в книге рецептов
        m_potionBookController.onChoosePotion += OnChoosePotion;
    }

    private void OnChoosePotion(Potion potion)
    {
        m_chosenPotion = potion;
    }

    public void OnAddIngredient(Ingredient ingredient)
    {
        GameManager.instance.audioManager.PlaySFX(GameManager.instance.audioManager.SFXAddingIngredients);

        m_cauldron.AddIngredient(ingredient);
        GameManager.instance.player.inventory.RemoveItem(ingredient);
    }

    public void OnRemoveIngredient(Ingredient ingredient)
    {
        m_cauldron.RemoveIngredient(ingredient);
        GameManager.instance.player.inventory.AddItem(ingredient);
    }

    public void Brew()
    {
        m_uiWinLose.potion = m_chosenPotion;
        m_uiWinLose.ingredients = m_cauldron.addedIngredients.ToArray();
        ClearCauldron();
        m_gameMode.GoToRhythmGame();
    }

    public void MakePotion()
    {
        // for (int i = 0; i < m_cauldron.addedIngredients.Count; i++)
        // {
        //     GameManager.instance.player.inventory.RemoveItem(m_cauldron.addedIngredients[i]);
        // }

        // Добавляет зелье готовое
        GameManager.instance.player.inventory.AddItem(m_chosenPotion);
    }

    public void ClearCauldron()
    {
        m_cauldron.ClearCauldron();
    }

    public void ItemsBackToInventory()
    {
        foreach (Ingredient item in m_cauldron.addedIngredients)
        {
            GameManager.instance.player.inventory.AddItem(item);
        }
    }

    public void GoToPotionBook()
    {
        m_gameMode.GoToPotionBook();
    }

    public bool RecipeCheck()
    {
        if (m_chosenPotion)
        {
            return m_cauldron.RecipeCheck(m_chosenPotion);
        }

        return false;
    }

    public void OpenPotionBook()
    {
        m_gameMode.Back();
    }
}
