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
    private Transform[] potionPanelSlots;
    private Transform[] ingredientPanelSlots;
    //private Transform[] seedPanelSlots;
    private int page;
    private int ingredientFilledSlots;
    private int potionFilledSlots;

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
        potionPanelSlots = potionsPanel.GetComponentsInChildren<Transform>().Skip(1).ToArray();
        List<InventorySlot> potions = GamePlayState.inventory.GetItemsByType(ItemCategory.Potion);
        Debug.Log(potions.Count);

        for (int i = 0; i < Math.Min(20, potions.Count); i++)
        {
            potionPanelSlots[i].GetComponentInChildren<UIInventoryItem>().item = potions[i].item;
        }

        ingredientPanelSlots = ingredientsPanel.GetComponentsInChildren<Transform>().Skip(1).ToArray();
        List<InventorySlot> ingredients = GamePlayState.inventory.GetItemsByType(ItemCategory.Ingredient);
        Debug.Log(ingredients.Count);

        for (int i = 0; i < Math.Min(20, ingredients.Count); i++)
        {
            ingredientPanelSlots[i].GetComponentInChildren<UIInventoryItem>().item = ingredients[i].item;
        }

        //seedPanelSlots = seedsPanel.GetComponentsInChildren<Transform>().Skip(1).ToArray();
    }
}