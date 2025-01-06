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
        Debug.Log(potionPanelSlots.Length);
        List<InventorySlot> potions = GamePlayState.inventory.GetItemsByType(ItemCategory.Potion);

        for (int i = 0; i < Math.Min(potionPanelSlots.Length, potions.Count); i++)
        {
            UIInventoryItem itemUI = potionPanelSlots[i].GetComponentInChildren<UIInventoryItem>();
            itemUI.item = potions[i].item;
            Debug.Log(itemUI.item);
            Debug.Log("potion " + i);
        }

        /*ingredientPanelSlots = ingredientsPanel.GetComponentsInChildren<Transform>().Skip(1).ToArray();
        List<InventorySlot> ingredients = GamePlayState.inventory.GetItemsByType(ItemCategory.Ingredient);

        for (int i = 0; i < Math.Min(ingredientPanelSlots.Length, ingredients.Count); i++)
        {
            ingredientPanelSlots[i].GetComponentInChildren<UIInventoryItem>().item = ingredients[i].item;
            Debug.Log("ingredient " + i);
        }

        //seedPanelSlots = seedsPanel.GetComponentsInChildren<Transform>().Skip(1).ToArray();*/
    }
}