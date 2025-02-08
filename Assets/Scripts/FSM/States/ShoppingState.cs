using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingState : GameStateBehaviour
{
    public Inventory shop;
    private Ingredient[] m_allIngredients;
    private Seed[] m_allSeeds;
    private bool ingredients_stocked;
    private bool seeds_stocked;
    public GameObject ingredientsPanel;
    public GameObject seedsPanel;
    public GameObject potionsPanel;
    public GameObject linePrefab;
    public TextMeshProUGUI coins;
    private bool needToRefreshInventory = true;


    private void Awake()
    {
        shop = new Inventory(32);
    }
    private void Start()
    {
        GameManager.playerInventory.onInvChange += OnInventoryChange;
    }

    private void OnInventoryChange()
    {
        needToRefreshInventory = true;
    }

    private void OnEnable()
    {
        //shoppingUI.SetActive(true);
        if (!ingredients_stocked || !seeds_stocked)
        {
            FillTheShop();
        }
        if (needToRefreshInventory)
        {
            FillSellList();
            needToRefreshInventory = false;
        }
        coins.text = $"Coins: {GameManager.playerInventory.coins}";
    }
    private void OnDisable()
    {
        if (needToRefreshInventory)
        {
            Transform[] sellLists = potionsPanel.GetComponentsInChildren<Transform>().Skip(1).ToArray();
            for (int i = 0; i < sellLists.Length; i++)
            {
                Destroy(sellLists[i].gameObject);
            }
        }
        //shoppingUI.SetActive(false);
    }
    // public void CloseShop()
    // {
    //     gameObject.SetActive(false);
    // }
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

    private void FillSellList()
    {
        List<InventorySlot> potions = GameManager.playerInventory.GetItemsByType(ItemCategory.Potion);
        
        for (int i = 0; i < potions.Count; i++)
        {
            GameObject newLine = Instantiate(linePrefab, potionsPanel.transform);
            Potion potion = (Potion)potions[i].item;

            newLine.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = potion.icon;
            newLine.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = $"{potion.name}: {potion.price}";
            newLine.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = potion.ElementsToString();
            newLine.transform.GetChild(3).gameObject.GetComponent<ShopListUI>().potionToSell = potion;

            newLine.transform.GetChild(3).gameObject.GetComponent<ShopListUI>().index = GameManager.playerInventory.slots.FindIndex(x => x == potions[i]);
            newLine.transform.GetChild(3).gameObject.GetComponent<ShopListUI>().countText = newLine.transform.GetChild(4).gameObject;

            newLine.transform.GetChild(3).gameObject.GetComponent<Button>().onClick.AddListener(newLine.transform.GetChild(3).gameObject.GetComponent<ShopListUI>().SellItem);
            newLine.transform.GetChild(3).gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Sell";
            newLine.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = $"Count: {potions[i].count}";
        }
    }
}
