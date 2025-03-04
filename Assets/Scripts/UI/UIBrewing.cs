using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class UIBrewing : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_cauldronInfoUI;
    [SerializeField] private GameObject m_cauldronSlots;
    [SerializeField] private GameObject m_inventorySlots;
    [SerializeField] private Button m_brewButton;
    [SerializeField] private Button m_clearButton;
    [SerializeField] private GameObject m_clickableItemPrefab;
    //[SerializeField] private GameObject m_cauldronClickableItemPrefab;
    [SerializeField] private BrewingController m_brewingController;
    [SerializeField] private Cauldron m_cauldron;
    [SerializeField] private PotionBookController m_potionBookController;
    [SerializeField] private TextMeshProUGUI m_brewingPotionInfo;
    [SerializeField] private Image m_potionImage;
    [SerializeField] private TooltipUI m_toolTip;

    private void Start()
    {
        //блокируем кнопку "Сварить", пока добавленные ингредиенты не будут соответствовать выбранному рецепту
        m_brewButton.interactable = false;
        m_clearButton.interactable = false;

        m_potionBookController.onChoosePotion += OnChoosePotion;
    }

    private void OnChoosePotion(Potion potion)
    {
        m_brewingPotionInfo.text = potion.ToStringItem();
        m_potionImage.sprite = potion.icon;
        BrewButtonOnOff();
    }

    private void OnEnable()
    {
        DeleteSlots();
        FillSlots();
    }

    private void DeleteSlots()
    {
        Transform[] inventorySlots = m_inventorySlots.GetComponentsInChildren<Transform>().Skip(1).ToArray();
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            Destroy(inventorySlots[i].gameObject);
        }
    }

    private void FillSlots()
    {
        //Вызываем айтемы из инвентаря
        List<InventorySlot> ingredients = GameManager.instance.player.inventory.GetItemsByType(ItemCategory.Ingredient);

        // Меняет айтем на тот, что есть в инвентаре игрока
        foreach (InventorySlot ingredient in ingredients)
        {
            GameObject newItem = Instantiate(m_clickableItemPrefab, m_inventorySlots.transform);
            ClickableItem clickableItem = newItem.GetComponentInChildren<ClickableItem>();
            clickableItem.item = ingredient.item;
            clickableItem.onAddIngredient += m_brewingController.OnAddIngredient;
            clickableItem.onAddIngredient += OnAddIngredient;
        }
    }

    private void OnAddIngredient(Ingredient ingredient)
    {
        AddToCauldron(ingredient);

        m_toolTip.HideTooltip();

        BrewButtonOnOff();
        ClearButtonOnOff();
    }

    private void OnRemoveIngredient(Ingredient ingredient)
    {
        RemoveFromCauldron(ingredient);

        m_toolTip.HideTooltip();

        BrewButtonOnOff();
        ClearButtonOnOff();
    }

    private void AddToCauldron(Ingredient ingredient)
    {
        ElementsInfoChange();

        GameObject newItemCauldron = Instantiate(m_clickableItemPrefab, m_cauldronSlots.transform);

        Image frame = newItemCauldron.GetComponent<Image>();
        frame.color = new Color(frame.color.r, frame.color.g, frame.color.b, 0f);

        ClickableItem clickableItem = newItemCauldron.GetComponentInChildren<ClickableItem>();
        clickableItem.InitialiseItem(ingredient);

        clickableItem.onRemoveIngredient += m_brewingController.OnRemoveIngredient;
        clickableItem.onRemoveIngredient += OnRemoveIngredient;
        clickableItem.isInCauldron = true;
        clickableItem.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void RemoveFromCauldron(Ingredient ingredient)
    {
        ClickableItem[] inventory = m_inventorySlots.GetComponentsInChildren<ClickableItem>();

        ClickableItem item = Array.Find(inventory, x => x.item == ingredient);

        if (item)
        {
            item.InitialiseItem(ingredient);
        }
        else
        {
            GameObject newItemCauldron = Instantiate(m_clickableItemPrefab, m_inventorySlots.transform);
            ClickableItem clickableItem = newItemCauldron.GetComponentInChildren<ClickableItem>();
            clickableItem.InitialiseItem(ingredient);
            clickableItem.onAddIngredient += m_brewingController.OnAddIngredient;
            clickableItem.onAddIngredient += OnAddIngredient;
        }

        ElementsInfoChange();
    }

    //проверка на соответствие рецепту
    //включение либо отключение кнопки "Сварить"
    //вызывается при каждом изменении в котле
    private void BrewButtonOnOff()
    {
        if (m_brewingController.RecipeCheck())
        {
            m_brewButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            m_brewButton.GetComponent<Button>().interactable = false;
        }

    }

    private void ClearButtonOnOff()
    {
        // Включаем кнопку очищения котла, только если там есть ингредиенты
        if (m_brewingController.cauldron.addedIngredients.Count > 0)
        {
            m_clearButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            m_clearButton.GetComponent<Button>().interactable = false;
        }
    }

    public void BrewUI()
    {
        m_brewButton.enabled = false;
        m_clearButton.enabled = false;
    }

    public void SetItemsBack()
    {
        // Получаем все айтемы в брюинге
        ClickableItem[] itemsCauldron = m_cauldronSlots.GetComponentsInChildren<ClickableItem>();

        // Заполняем слоты инвентаря айтемами оставшимися
        for (int i = 0; i < itemsCauldron.Length; i++)
        {
            RemoveFromCauldron((Ingredient)itemsCauldron[i].item);

            itemsCauldron[i].Remove();
        }


        m_cauldronInfoUI.text = "Cauldron is empty!";

        m_brewButton.GetComponent<Button>().interactable = false;
        m_clearButton.GetComponent<Button>().interactable = false;
    }

    public void ElementsInfoChange()
    {
        string inf = m_cauldron.GetInfo();
        if (inf == "")
        {
            m_cauldronInfoUI.text = "Cauldron is empty!";
        }
        else
        {
            m_cauldronInfoUI.text = m_cauldron.GetInfo();
        }
    }
}

