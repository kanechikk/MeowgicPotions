using System;
using System.Linq;
using UnityEngine;

public class ShoppingState : MonoBehaviour
{
    private Inventory shop;
    private Ingredient[] m_allIngredients;
    [SerializeField] private GameObject[] m_IngredientPrefabs;
    //private Seed[] m_allSeeds;
    private bool ingredients_stocked;
    private bool seeds_stocked;
    public GameObject ingredientsPanel;
    public SlotsFilling slotsFilling;
    public GameObject linePrefab;
    private int page;
    

    private void Awake()
    {
        shop = new Inventory(64);
    }
    private void OnEnable()
    {
        if (ingredients_stocked || seeds_stocked)
        {
            FillTheShop();
        }
    }
    private void FillTheShop()
    {
        if (!ingredients_stocked)
        {
            // Заполнение массива ингредиентов из папки Resources
            m_allIngredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
            int ingsCount = 0;
            // Заполняем инвентарь магазина
            foreach (Ingredient ingredient in m_allIngredients)
            {
                shop.AddItem(ingredient);
                ingsCount++;
            }

            for (int i = 0; i < ingsCount; i++)
            {
                GameObject newLine = Instantiate(linePrefab, ingredientsPanel.transform);
            }

            ingredients_stocked = true;
        }
        if (!seeds_stocked)
        {
            // m_allSeeds = Resources.LoadAll<Seed>("ScriptableObjects/Seeds");

            // seeds_stocked = true;
        }
    }
    private void FillOnePage(GameObject page)
    {

    }
}
