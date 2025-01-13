using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BrewingState : MonoBehaviour
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

    private void Start()
    {
        //блокируем кнопку "Сварить", пока добавленные ингредиенты не будут соответствовать выбранному рецепту
        m_brewButton.GetComponent<Button>().interactable = false;

        //подписываемся на события, которые реагируют на добавление объектов в слоты котла 
        foreach (Transform slot in m_inventorySlots.transform)
        {
            slot.gameObject.GetComponentInChildren<ClickableItem>().onAddIngredient += OnAddIngredient;
        }

        //подписываемся на события, которые реагируют на добавление объектов в слоты инвентаря
        foreach (Transform slot in m_cauldronSlots.transform)
        {
            slot.gameObject.GetComponentInChildren<CauldronClickableItem>().onRemoveIngredient += OnRemoveIngredient;
        }

        //подписываемся на событие, которое реагирует на выбор зелья в книге рецептов
        m_potionBookState.onChoosePotion += OnChoosePotion;
    }

    private void OnEnable()
    {
        m_brewingUI?.SetActive(true);
        //заполнение ячеек
        FillSlots();
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
    
    //вызывается при добавлении объекта в котел
    private void OnAddIngredient(Ingredient ingredient)
    {
        m_cauldron.AddIngredient(ingredient);
        ElementsInfoChange(m_cauldron.aquaCount, m_cauldron.terraCount, m_cauldron.solarCount, m_cauldron.ignisCount,
                           m_cauldron.aerCount, m_cauldronInfoUI);
        BrewButtonOnOff();
        ClearButtonOnOff();
    }

    //вызывается при возвращении объекта в инвентарь
    private void OnRemoveIngredient(Ingredient ingredient)
    {
        m_cauldron.RemoveIngredient(ingredient);
        ElementsInfoChange(m_cauldron.aquaCount, m_cauldron.terraCount, m_cauldron.solarCount, m_cauldron.ignisCount,
                           m_cauldron.aerCount, m_cauldronInfoUI);
        BrewButtonOnOff();
        ClearButtonOnOff();
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

    /*public void SetItemsBack()
    {
        // Очищаем котел
        m_cauldron.ClearAll();
        ElementsInfoChange(m_cauldron.aquaCount, m_cauldron.terraCount, m_cauldron.solarCount, m_cauldron.ignisCount,
                           m_cauldron.aerCount, m_cauldronInfoUI);

        // Получаем все айтемы в брюинге
        DraggableItem[] itemsCauldron = m_cauldronSlots.GetComponentsInChildren<DraggableItem>();
        DraggableItem[] itemsInventory = m_inventorySlots.GetComponentsInChildren<DraggableItem>();

        // Все слоты инвенторя
        DraggableItemSlot[] transformsInventory = m_inventorySlots.GetComponentsInChildren<DraggableItemSlot>();

        // Заполняем слоты инвенторя айтемами оставшимися
        for (int i = 0; i < itemsInventory.Length; i++)
        {
            itemsInventory[i].transform.SetParent(transformsInventory[i].transform);
        }
        for (int i = itemsInventory.Length; i < itemsInventory.Length + itemsCauldron.Length; i++)
        {
            itemsCauldron[i - itemsInventory.Length].transform.SetParent(transformsInventory[i].transform);
        }

        BrewButtonOnOff();
        ClearButtonOnOff();
    }*/

    //метод, который висит на кнопке открытия книги с зельями
    public void OpenBook()
    {
        m_potionBookState.gameObject.SetActive(true);
        m_brewingUI.GetComponent<CanvasRenderer>().cullTransparentMesh = false;
    }

    //остановка стейта
    public void StopBrewing()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        m_brewingUI?.SetActive(false);
    }
    
    private void FillSlots()
    {
        // Вызываем айтемы из инвентаря
        ClickableItem[] items = m_inventorySlots.GetComponentsInChildren<ClickableItem>();
        List<InventorySlot> ingredients = GamePlayState.inventory.GetItemsByType(ItemCategory.Ingredient);

        // Меняет айтем на тот, что есть в инвентаре игрока
        for (int i = 0; i < Math.Min(8, ingredients.Count); i++)
        {
            items[i].item = (Ingredient)ingredients[i].item;
            Debug.Log(ingredients[i].item);
        }
    }

    public void Brew()
    {
        // Вызываем все айтемы из котла
        CauldronClickableItem[] items = m_cauldronSlots.GetComponentsInChildren<CauldronClickableItem>();
        
        for (int i = 0; i < items.Length; i++)
        {
            // Если айтем не нул, то мы его убираем из инвентаря, из котла и закидываем на его место сэмпловый
            if (items[i].item != null)
            {
                GamePlayState.inventory.RemoveItem(items[i].item);
                Ingredient ingredient = new Ingredient();
                
                m_cauldron.RemoveIngredient((Ingredient)items[i].item);
                items[i].item = m_itemSample;
            }
        }

        // Перекидывает айтемы назад в правое окно инвентаря
        //SetItemsBack();
        // Добавляет зелье готовое
        GamePlayState.inventory.AddItem(m_chosenPotion);
    }
}
