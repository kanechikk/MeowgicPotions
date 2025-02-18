using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryState : GameStateBehaviour
{
    public GameObject inventoryUI;
    public GameObject potionsPanel;
    public GameObject ingredientsPanel;
    public GameObject seedsPanel;
    public SampleItem sampleItem;
    public TextMeshProUGUI coins;
    private UIInventoryItem[] potionPanelSlots;
    private UIInventoryItem[] ingredientPanelSlots;
    private UIInventoryItem[] seedPanelSlots;

    private void OnEnable()
    {
        inventoryUI.SetActive(true);
        FillPotions();
        FillIngredients();
        FillSeeds();
        coins.text = $"Coins: {GameManager.instance.player.inventory.coins}";
    }
    private void OnDisable()
    {
        if (inventoryUI)
        {
            inventoryUI.SetActive(false);
        }
    }
    public void CloseInventory()
    {
        gameObject.SetActive(false);
    }
    private void FillPotions()
    {
        potionPanelSlots = potionsPanel.GetComponentsInChildren<UIInventoryItem>();
        List<InventorySlot> potions = GameManager.instance.player.inventory.GetItemsByType(ItemCategory.Potion);

        foreach (UIInventoryItem slot in potionPanelSlots)
        {
            slot.InitialiseItem(sampleItem);
        }

        // Если слот пустой, то в него кладем сэмпл, если нет, то зелье
        for (int i = 0; i < Math.Min(potionPanelSlots.Length, potions.Count); i++)
        {
            potionPanelSlots[i].InitialiseItem(potions[i].item);
        }
    }
    private void FillIngredients()
    {
        ingredientPanelSlots = ingredientsPanel.GetComponentsInChildren<UIInventoryItem>();
        List<InventorySlot> ingredients = GameManager.instance.player.inventory.GetItemsByType(ItemCategory.Ingredient);

        foreach (UIInventoryItem slot in ingredientPanelSlots)
        {
            slot.InitialiseItem(sampleItem);
        }

        for (int i = 0; i < Math.Min(ingredientPanelSlots.Length, ingredients.Count); i++)
        {
            ingredientPanelSlots[i].InitialiseItem(ingredients[i].item);
        }
    }
    private void FillSeeds()
    {
        seedPanelSlots = seedsPanel.GetComponentsInChildren<UIInventoryItem>();
        List<InventorySlot> seeds = GameManager.instance.player.inventory.GetItemsByType(ItemCategory.Seed);

        foreach (UIInventoryItem slot in seedPanelSlots)
        {
            slot.InitialiseItem(sampleItem);
        }

        for (int i = 0; i < Math.Min(seedPanelSlots.Length, seeds.Count); i++)
        {
            seedPanelSlots[i].InitialiseItem(seeds[i].item);
        }
    }
}