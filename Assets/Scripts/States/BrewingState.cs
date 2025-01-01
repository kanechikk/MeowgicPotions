using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BrewingState : MonoBehaviour
{
    private Ingredient[] m_allIngredients;
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

    private void OnEnable()
    {
        m_brewingUI.SetActive(true);
        //блокируем кнопку "Сварить", пока добавленные ингредиенты не будут соответствовать выбранному рецепту
        m_brewButton.GetComponent<Button>().interactable = false;
        //полуение всех существующих ингредиентов (зачем-то??)
        m_allIngredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");

        //подписываемся на события, которые реагируют на добавление объектов в слоты котла 
        foreach (Transform slot in m_cauldronSlots.transform)
        {
            slot.gameObject.GetComponent<DraggableItemSlot>().onAddIngredient += OnAddIngredient;
        }

        //подписываемся на события, которые реагируют на добавление объектов в слоты инвентаря
        foreach (Transform slot in m_inventorySlots.transform)
        {
            slot.gameObject.GetComponent<DraggableItemSlot>().onReturnFromCauldron += OnRemoveIngredient;
        }

        //подписываемся на событие, которое реагирует на выбор зелья в книге рецептов
        m_potionBookState.onChoosePotion += OnChoosePotion;
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
    private void OnAddIngredient(Ingredient item)
    {
        m_cauldron.AddIngredient(item);
        ElementsInfoChange(m_cauldron.aquaCount, m_cauldron.terraCount, m_cauldron.solarCount, m_cauldron.ignisCount,
                           m_cauldron.aerCount, m_cauldronInfoUI);
        BrewButtonOnOff();
    }

    //вызывается при перетаскивании объекта в инвентарь
    private void OnRemoveIngredient(Ingredient item)
    {
        m_cauldron.RemoveIngredient(item);
        ElementsInfoChange(m_cauldron.aquaCount, m_cauldron.terraCount, m_cauldron.solarCount, m_cauldron.ignisCount,
                           m_cauldron.aerCount, m_cauldronInfoUI);
        BrewButtonOnOff();
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

    //вызывается, если мы выбрали зелье в книге
    private void OnChoosePotion(Potion chosenPotion)
    {
        m_chosenPotion = chosenPotion;
        ElementsInfoChange(m_chosenPotion.elements["Aqua"], m_chosenPotion.elements["Terra"], m_chosenPotion.elements["Solar"],
                            m_chosenPotion.elements["Ignis"], m_chosenPotion.elements["Aer"], m_chosenPotionInfoUI);
        m_chosenPotionNameUI.text = m_chosenPotion.itemName;
    }

    //очищение котла, обнуление значений
    public void ClearCauldron()
    {
        m_cauldron.ClearAll();
        ElementsInfoChange(m_cauldron.aquaCount, m_cauldron.terraCount, m_cauldron.solarCount, m_cauldron.ignisCount,
                           m_cauldron.aerCount, m_cauldronInfoUI);
    }

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
}
