using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BrewingState : MonoBehaviour
{
    private Ingredient[] m_allIngredients;
    private Potion[] m_allPotions;
    [SerializeField] private Cauldron m_cauldron;
    [SerializeField] private GameObject m_brewingUI;
    [SerializeField] private TextMeshProUGUI[] m_cauldronInfoUI;
    [SerializeField] private TextMeshProUGUI[] m_chosenPotionInfoUI;
    [SerializeField] private PotionBookState m_potionBookState;
    [SerializeField] private TextMeshProUGUI m_chosenPotionNameUI;
    [SerializeField] private GameObject m_cauldronSlots;
    [SerializeField] private GameObject m_inventorySlots;
    private Potion m_chosenPotion;
    //свойства, доступные только для чтения
    public Potion[] allPotions => this.m_allPotions;
    private GameObject m_brewButton;

    private void OnEnable()
    {
        m_brewingUI.SetActive(true);
        m_allIngredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
        m_allPotions = Resources.LoadAll<Potion>("ScriptableObjects/Potions");

        foreach (Transform slot in m_cauldronSlots.transform)
        {
            slot.gameObject.GetComponent<CauldronSlot>().onAddIngredient += OnAddIngredient;
        }

        foreach (Transform slot in m_inventorySlots.transform)
        {
            slot.gameObject.GetComponent<InventorySlot>().onReturnFromCauldron += OnRemoveIngredient;
        }

        m_potionBookState.onChoosePotion += OnChoosePotion;

        m_brewButton = m_brewingUI.transform.Find("BrewClearButtons").Find("BrewButton").gameObject;
        m_brewButton.GetComponent<Button>().interactable = false;
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

    private void OnAddIngredient(Ingredient item)
    {
        m_cauldron.AddIngredient(item);
        ElementsInfoChange(m_cauldron.aquaCount, m_cauldron.terraCount, m_cauldron.solarCount, m_cauldron.ignisCount,
                           m_cauldron.aerCount, m_cauldronInfoUI);
        BrewButtonOnOff();
    }

    private void OnRemoveIngredient(Ingredient item)
    {
        m_cauldron.RemoveIngredient(item);
        ElementsInfoChange(m_cauldron.aquaCount, m_cauldron.terraCount, m_cauldron.solarCount, m_cauldron.ignisCount,
                           m_cauldron.aerCount, m_cauldronInfoUI);
        BrewButtonOnOff();
    }

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

    private void OnChoosePotion(Potion chosenPotion)
    {
        m_chosenPotion = chosenPotion;
        ElementsInfoChange(m_chosenPotion.elements["aqua"], m_chosenPotion.elements["terra"], m_chosenPotion.elements["solar"],
                            m_chosenPotion.elements["ignis"], m_chosenPotion.elements["aer"], m_chosenPotionInfoUI);
        m_chosenPotionNameUI.text = m_chosenPotion.itemName;
    }

    //очищение котла, обнуление значений
    public void ClearCauldron()
    {
        m_cauldron.ClearAll();
        ElementsInfoChange(m_cauldron.aquaCount, m_cauldron.terraCount, m_cauldron.solarCount, m_cauldron.ignisCount,
                           m_cauldron.aerCount, m_cauldronInfoUI);
    }

    public void OpenBook()
    {
        m_potionBookState.gameObject.SetActive(true);
        m_brewingUI.GetComponent<CanvasRenderer>().cullTransparentMesh = false;
    }

    public void StopBrewing()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        m_brewingUI.SetActive(false);
    }
}
