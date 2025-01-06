using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryState : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject potionsPanel;
    public GameObject ingredientsPanel;
    // public GameObject seedsPanel;
    private UIInventoryItem[] potionPanelSlots;
    private UIInventoryItem[] ingredientPanelSlots;
    //private Transform[] seedPanelSlots;
    private int page;

    private void OnEnable()
    {
        inventoryUI.SetActive(true);
        FillInventoryUI();
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

        for (int i = 0; i < Math.Min(potionPanelSlots.Length, potions.Count); i++)
        {
            potionPanelSlots[i].item = potions[i].item;
            Debug.Log("potion " + i);
        }

        ingredientPanelSlots = ingredientsPanel.GetComponentsInChildren<UIInventoryItem>();
        List<InventorySlot> ingredients = GamePlayState.inventory.GetItemsByType(ItemCategory.Ingredient);

        for (int i = 0; i < Math.Min(ingredientPanelSlots.Length, ingredients.Count); i++)
        {
            ingredientPanelSlots[i].item = ingredients[i].item;
            Debug.Log("ingredient " + i);
        }

        //seedPanelSlots = seedsPanel.GetComponentsInChildren<Transform>().Skip(1).ToArray();
    }
}