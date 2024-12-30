using System;
using System.Linq;
using UnityEngine;

public class ShoppingState : MonoBehaviour
{
    private Inventory shop;
    private Ingredient[] m_allIngredients;
    [SerializeField] private GameObject[] m_IngredientPrefabs;
    //private Potion[] m_allPotions;
    //private Seed[] m_allSeeds;
    //private bool potions_stocked;
    private bool ingredients_stocked;
    private bool seeds_stocked;
    //public GameObject potionsPanel;
    //private Transform[] potionPanelSlots;
    public GameObject ingredientsPanel;
    private Transform[] ingredientPanelSlots;
    public SlotsFilling slotsFilling;
    private int page;
    

    private void Awake()
    {
        shop = new Inventory(64);
    }
    private void OnEnable()
    {
        if (!ingredients_stocked)
        {
            m_allIngredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
            foreach (Ingredient ingredient in m_allIngredients)
            {
                shop.AddItem(ingredient);
            }
            ingredientPanelSlots = ingredientsPanel.GetComponentsInChildren<Transform>().Skip(1).ToArray(); // Скипает первый элемент массива, так как он туда закидывает еще трансформ бэкграунда магазина

            for (int i = 0; i < Math.Min(ingredientPanelSlots.Length, m_IngredientPrefabs.Length); i++)
            {
                slotsFilling.FillSlot(m_IngredientPrefabs[i], ingredientPanelSlots[i].transform);
                Debug.Log(ingredientPanelSlots[i].name);
                Debug.Log(i);
            }

            ingredients_stocked = true;
        }
        /*if (!ingredients_stocked)
        {
            m_allPotion = Resources.LoadAll<Potion>("ScriptableObjects/Potions");
            foreach (Potion potion in m_allPotion)
            {
                shop.AddItem(potion);
            }
            ingredientPanelSlots = ingredientsPanel.GetComponentsInChildren<Transform>();

            foreach (Transform slot in ingredientPanelSlots)
            {

            }

            ingredients_stocked = true;
        }*/
        if (!seeds_stocked)
        {
            // m_allSeeds = Resources.LoadAll<Seed>("ScriptableObjects/Seeds");

            // seeds_stocked = true;
        }
    }
}
