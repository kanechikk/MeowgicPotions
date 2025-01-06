using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingState : MonoBehaviour
{
    public GameObject shoppingUI;
    private Inventory shop;
    private Ingredient[] m_allIngredients;
    private Seed[] m_allSeeds;
    private bool ingredients_stocked;
    private bool seeds_stocked;
    public GameObject ingredientsPanel;
    public GameObject seedsPanel;
    public GameObject linePrefab;


    private void Awake()
    {
        shop = new Inventory(32);
    }
    private void OnEnable()
    {
        shoppingUI.SetActive(true);
        if (!ingredients_stocked || !seeds_stocked)
        {
            FillTheShop();
        }
    }
    private void OnDisable()
    {
        shoppingUI.SetActive(false);
    }
    private void FillTheShop()
    {
        // Заполнение массива ингредиентов из папки Resources
        m_allIngredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
        // Заполняем инвентарь магазина
        foreach (Ingredient ingredient in m_allIngredients)
        {
            shop.AddItem(ingredient);
            // Создание новой строчки в магазине
            GameObject newLine = Instantiate(linePrefab, ingredientsPanel.transform);
            // Передает спрайт
            newLine.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = ingredient.icon;
            // Заполнение текста строки
            newLine.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = $"{ingredient.itemName}: {ingredient.price}";
            newLine.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = ingredient.ElementsToString();
            // Добавляет метод покупки к кнопке
            newLine.transform.GetChild(3).gameObject.GetComponent<Button>().onClick.AddListener(BuyItem);
        }

        ingredients_stocked = true;

        m_allSeeds = Resources.LoadAll<Seed>("ScriptableObjects/Seeds");

        foreach (Seed seeds in m_allSeeds)
        {
            shop.AddItem(seeds);
            GameObject newLine = Instantiate(linePrefab, seedsPanel.transform);
            newLine.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = seeds.icon;
            newLine.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = $"{seeds.itemName}: {seeds.price}";
            newLine.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = $"Дней роста: {seeds.daysToGrow}";
            newLine.transform.GetChild(3).gameObject.GetComponent<Button>().onClick.AddListener(BuyItem);
        }

        seeds_stocked = true;
    }
    public void BuyItem()
    {
        //GamePlayState.inventory.AddItem();
    }
}
