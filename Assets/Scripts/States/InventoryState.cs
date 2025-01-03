using System;
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

        for (int i = 0; i < 2; i++)
        {
            if (GamePlayState.inventory.slots[i].category == ItemCategory.Potion)
            {
                potionPanelSlots[0].GetComponent<Image>().sprite = GamePlayState.inventory.slots[1].item.icon;
            }
            else
            {
                //i--;
            }
        }

        ingredientPanelSlots = ingredientsPanel.GetComponentsInChildren<Transform>().Skip(1).ToArray();

        for (int i = 0; i < 2; i++)
        {
            if (GamePlayState.inventory.slots[i].category == ItemCategory.Ingredient)
            {
                ingredientPanelSlots[0].GetComponent<Image>().sprite = GamePlayState.inventory.slots[0].item.icon;
            }
            else
            {
                //i--;
            }
        }

        //seedPanelSlots = seedsPanel.GetComponentsInChildren<Transform>().Skip(1).ToArray();
    }
}