using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryState : MonoBehaviour
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
    private int page;

    private void OnEnable()
    {
        inventoryUI.SetActive(true);
        FillInventoryUI();
        coins.text = $"Coins: {GamePlayState.inventory.coins}";
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
    private void FillInventoryUI()
    {
        // Скипает первый элемент массива, так как он туда закидывает еще трансформ бэкграунда магазина
        potionPanelSlots = potionsPanel.GetComponentsInChildren<UIInventoryItem>();
        List<InventorySlot> potions = GamePlayState.inventory.GetItemsByType(ItemCategory.Potion);

        // foreach (UIInventoryItem slot in potionPanelSlots)
        // {
        //     slot.InitialiseItem(sampleItem);
        // }

        // Если слот пустой, то в него кладем сэмпл, если нет, то зелье
        for (int i = 0; i < Math.Min(potionPanelSlots.Length, potions.Count); i++)
        {
            // Убираем все нулы чтобы не возникали ошибки при вызове картинки айтема
            if (potions[i].item == null)
            {
                potionPanelSlots[i].InitialiseItem(sampleItem);
            }
            else
            {
                potionPanelSlots[i].InitialiseItem(potions[i].item);
            }
        }

        ingredientPanelSlots = ingredientsPanel.GetComponentsInChildren<UIInventoryItem>();
        List<InventorySlot> ingredients = GamePlayState.inventory.GetItemsByType(ItemCategory.Ingredient);

        // foreach (UIInventoryItem slot in ingredientPanelSlots)
        // {
        //     slot.item = sampleItem;
        // }

        for (int i = 0; i < Math.Min(ingredientPanelSlots.Length, ingredients.Count); i++)
        {
            if (ingredients[i].item == null)
            {
                ingredientPanelSlots[i].item = sampleItem;
            }
            else
            {
                ingredientPanelSlots[i].item = ingredients[i].item;
            }
        }

        seedPanelSlots = seedsPanel.GetComponentsInChildren<UIInventoryItem>();
        List<InventorySlot> seeds = GamePlayState.inventory.GetItemsByType(ItemCategory.Seed);

        // foreach (UIInventoryItem slot in seedPanelSlots)
        // {
        //     slot.InitialiseItem(sampleItem);
        // }

        for (int i = 0; i < Math.Min(seedPanelSlots.Length, seeds.Count); i++)
        {
            if (seeds[i].item == null)
            {
                seedPanelSlots[i].InitialiseItem(sampleItem);
            }
            else
            {
                seedPanelSlots[i].InitialiseItem(seeds[i].item);
            }
        }
    }
}