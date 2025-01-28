using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BrewingState : GameStateBehaviour
{
    [SerializeField] private Cauldron m_cauldron;
    private Potion m_chosenPotion;
    //UI элементы
    [SerializeField] private GameObject m_brewingUI;
    [SerializeField] private TextMeshProUGUI[] m_cauldronInfoUI;
    [SerializeField] private TextMeshProUGUI[] m_chosenPotionInfoUI;
    [SerializeField] private PotionBookState m_potionBookState;
    [SerializeField] private TextMeshProUGUI m_chosenPotionNameUI;
    [SerializeField] private GameObject m_cauldronSlots;
    [SerializeField] private GameObject m_inventorySlots;
    [SerializeField] private GameObject m_brewButton;
    [SerializeField] private GameObject m_clearButton;
    [SerializeField] private Item m_itemSample;
    [SerializeField] private GameObject m_clickableItemPrefab;
    [SerializeField] private GameObject m_cauldronClickableItemPrefab;
    private bool needToRefreshInventory = true;

    private void Start()
    {
        //блокируем кнопку "Сварить", пока добавленные ингредиенты не будут соответствовать выбранному рецепту
        m_brewButton.GetComponent<Button>().interactable = false;

        //подписываемся на событие, которое реагирует на выбор зелья в книге рецептов
        m_potionBookState.onChoosePotion += OnChoosePotion;

        GameManager.playerInventory.onInvChange += OnInventoryChange;
    }

    private void OnInventoryChange()
    {
        needToRefreshInventory = true;
    }

    private void OnEnable()
    {
        //m_brewingUI?.SetActive(true);
        //заполнение ячеек
        if (needToRefreshInventory)
        {
            FillSlots();
        }
    }

    //остановка стейта
    public void StopBrewing()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        //m_brewingUI?.SetActive(false);
        if (needToRefreshInventory)
        {
            Transform[] inventorySlots = m_inventorySlots.GetComponentsInChildren<Transform>().Skip(1).ToArray();
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                Destroy(inventorySlots[i].gameObject);
            }
        }
    }

    private void FillSlots()
    {
        // Вызываем айтемы из инвентаря
        List<InventorySlot> ingredients = GameManager.playerInventory.GetItemsByType(ItemCategory.Ingredient);

        // Меняет айтем на тот, что есть в инвентаре игрока
        foreach (InventorySlot ingredient in ingredients)
        {
            GameObject newItem = Instantiate(m_clickableItemPrefab, m_inventorySlots.transform);
            newItem.GetComponentInChildren<ClickableItem>().item = ingredient.item;
            newItem.GetComponentInChildren<ClickableItem>().onAddIngredient = OnAddIngredient;
        }
    }

    private void OnAddIngredient(Ingredient ingredient)
    {
        AddToCauldron(ingredient);

        BrewButtonOnOff();
        ClearButtonOnOff();
    }

    private void OnRemoveIngredient(Ingredient ingredient)
    {
        RemoveFromCaldron(ingredient);

        BrewButtonOnOff();
        ClearButtonOnOff();
    }

    private void AddToCauldron(Ingredient ingredient)
    {
        m_cauldron.AddIngredient(ingredient);
        ElementsInfoChange(m_cauldron.aquaCount, m_cauldron.terraCount, m_cauldron.solarCount, m_cauldron.ignisCount,
                           m_cauldron.aerCount, m_cauldronInfoUI);
        GameManager.playerInventory.RemoveItem(ingredient);

        GameObject newItemCauldron = Instantiate(m_cauldronClickableItemPrefab, m_cauldronSlots.transform);
        newItemCauldron.GetComponentInChildren<CauldronClickableItem>().InitialiseItem(ingredient);
        newItemCauldron.GetComponentInChildren<CauldronClickableItem>().onRemoveIngredient += OnRemoveIngredient;
    }

    private void RemoveFromCaldron(Ingredient ingredient)
    {
        m_cauldron.RemoveIngredient(ingredient);
        ElementsInfoChange(m_cauldron.aquaCount, m_cauldron.terraCount, m_cauldron.solarCount, m_cauldron.ignisCount,
                           m_cauldron.aerCount, m_cauldronInfoUI);
        GameManager.playerInventory.AddItem(ingredient);


        ClickableItem[] inventory = m_inventorySlots.GetComponentsInChildren<ClickableItem>();

        if (Array.Exists(inventory, x => x.item == ingredient))
        {
            Array.Find(inventory, x => x.item == ingredient).InitialiseItem(ingredient);
        }
        else
        {
            GameObject newItemCauldron = Instantiate(m_clickableItemPrefab, m_inventorySlots.transform);
            newItemCauldron.GetComponentInChildren<ClickableItem>().InitialiseItem(ingredient);
            newItemCauldron.GetComponentInChildren<ClickableItem>().onAddIngredient += OnAddIngredient;
        }
    }

    //проверка на соответствие рецепту
    //включение либо отключение кнопки "Сварить"
    //вызывается при каждом изменении в котле
    private void BrewButtonOnOff()
    {
        if (m_chosenPotion != null)
        {
            if (m_cauldron.RecipeCheck(m_chosenPotion))
            {
                m_brewButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                m_brewButton.GetComponent<Button>().interactable = false;
            }
        }
    }

    private void ClearButtonOnOff()
    {
        // Включаем кнопку очищения котла, только если там есть ингредиенты
        if (m_cauldron.addedIngredients.Count > 0)
        {
            m_clearButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            m_clearButton.GetComponent<Button>().interactable = false;
        }
    }

    //вызывается, если мы выбрали зелье в книге
    private void OnChoosePotion(Potion chosenPotion)
    {
        m_chosenPotion = chosenPotion;
        ElementsInfoChange(m_chosenPotion.elements["Aqua"], m_chosenPotion.elements["Terra"], m_chosenPotion.elements["Solar"],
                            m_chosenPotion.elements["Ignis"], m_chosenPotion.elements["Aer"], m_chosenPotionInfoUI);
        m_chosenPotionNameUI.text = m_chosenPotion.itemName;
    }

    //метод, который висит на кнопке открытия книги с зельями
    // public void OpenBook()
    // {
    //     m_potionBookState.gameObject.SetActive(true);
    //     m_brewingUI.GetComponent<CanvasRenderer>().cullTransparentMesh = false;
    // }

    public void Brew()
    {
        // Вызываем все айтемы из котла
        CauldronClickableItem[] items = m_cauldronSlots.GetComponentsInChildren<CauldronClickableItem>();
        
        for (int i = 0; i < items.Length; i++)
        {
            GameManager.playerInventory.RemoveItem(items[i].ingredient);
                
            m_cauldron.RemoveIngredient(items[i].ingredient);
            items[i].item = m_itemSample;
            items[i].Remove();
        }
        // Добавляет зелье готовое
        GameManager.playerInventory.AddItem(m_chosenPotion);

        BrewButtonOnOff();
        ClearButtonOnOff();
    }

    public void SetItemsBack()
    {
        // Получаем все айтемы в брюинге
        CauldronClickableItem[] itemsCauldron = m_cauldronSlots.GetComponentsInChildren<CauldronClickableItem>();

        // Заполняем слоты инвенторя айтемами оставшимися
        for (int i = 0; i < itemsCauldron.Length; i++)
        {
            RemoveFromCaldron(itemsCauldron[i].ingredient);
            itemsCauldron[i].Remove();
        }

        BrewButtonOnOff();
        ClearButtonOnOff();
    }

    //обновление значений элементов в UI
    //вызывается при каждом добавлении/удалении ингредиента
    public void ElementsInfoChange(int aqua, int terra, int solar, int ignis, int aer, TextMeshProUGUI[] elementsInfoUI)
    {
        foreach (var elementUI in elementsInfoUI)
        {
            switch (elementUI.name)
            {
                case "Aqua":
                    elementUI.text = $"Aqua: {aqua}";
                    break;
                case "Terra":
                    elementUI.text = $"Terra: {terra}";
                    break;
                case "Solar":
                    elementUI.text = $"Solar: {solar}";
                    break;
                case "Ignis":
                    elementUI.text = $"Ignis: {ignis}";
                    break;
                case "Aer":
                    elementUI.text = $"Aer: {aer}";
                    break;
            }
        }
    }
}
