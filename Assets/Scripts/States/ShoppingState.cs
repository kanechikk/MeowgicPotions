using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingState : MonoBehaviour
{
    public GameObject shoppingUI;
    public static Inventory shop;
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
    public void CloseShop()
    {
        gameObject.SetActive(false);
    }
    private void FillTheShop()
    {
        // Заполнение массива ингредиентов из папки Resources
        m_allIngredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");

        // Заполняем инвентарь магазина
        for (int i = 0; i < m_allIngredients.Length; i++)
        {
            int index = shop.AddItem(m_allIngredients[i]);
            shop.AddItem(m_allIngredients[i]);
            // Создание новой строчки в магазине
            GameObject newLine = Instantiate(linePrefab, ingredientsPanel.transform);
            // Передает спрайт
            newLine.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = m_allIngredients[i].icon;
            // Заполнение текста строки
            newLine.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = $"{m_allIngredients[i].itemName}: {m_allIngredients[i].price}";
            newLine.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = m_allIngredients[i].ElementsToString();

            // Привязывает айтем к строке
            newLine.transform.GetChild(3).gameObject.GetComponent<ShopListUI>().shop = shop;
            newLine.transform.GetChild(3).gameObject.GetComponent<ShopListUI>().index = index;
            newLine.transform.GetChild(3).gameObject.GetComponent<ShopListUI>().countText = newLine.transform.GetChild(4).gameObject;
            // Добавляет метод покупки к кнопке
            newLine.transform.GetChild(3).gameObject.GetComponent<Button>().onClick.AddListener(newLine.transform.GetChild(3).gameObject.GetComponent<ShopListUI>().BuyItem);
            // Вывод количества объектов
            newLine.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = $"Count: {shop.slots[index].count}";
        }

        ingredients_stocked = true;

        m_allSeeds = Resources.LoadAll<Seed>("ScriptableObjects/Seeds");

        for (int i = 0; i < m_allSeeds.Length; i++)
        {
            int index = shop.AddItem(m_allSeeds[i]);
            shop.AddItem(m_allSeeds[i]);

            GameObject newLine = Instantiate(linePrefab, seedsPanel.transform);
            newLine.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = m_allSeeds[i].icon;
            newLine.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = $"{m_allSeeds[i].itemName}: {m_allSeeds[i].price}";
            newLine.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = $"Дней роста: {m_allSeeds[i].daysToGrow}";

            newLine.transform.GetChild(3).gameObject.GetComponent<ShopListUI>().shop = shop;
            newLine.transform.GetChild(3).gameObject.GetComponent<ShopListUI>().index = index;
            newLine.transform.GetChild(3).gameObject.GetComponent<ShopListUI>().countText = newLine.transform.GetChild(4).gameObject;
            newLine.transform.GetChild(3).gameObject.GetComponent<Button>().onClick.AddListener(newLine.transform.GetChild(3).gameObject.GetComponent<ShopListUI>().BuyItem);
            newLine.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = $"Count: {shop.slots[index].count}";
        }

        seeds_stocked = true;
    }
}
