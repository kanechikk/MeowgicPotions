using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static Inventory playerInventory;
    public static ItemsDB itemsDB;
    public WateringPot wateringPot;
    [SerializeField] private int m_wateringPotMaxValue;

    private void Awake()
    {
        Ingredient[] m_ingredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
        Potion[] m_potions = Resources.LoadAll<Potion>("ScriptableObjects/Potions");
        Seed[] m_seeds = Resources.LoadAll<Seed>("ScriptableObjects/Seeds");
        itemsDB = new ItemsDB(m_ingredients, m_potions, m_seeds);

        playerInventory = new Inventory(32);

        CreateWateringPot(m_wateringPotMaxValue);
        // objective = new Objective(objectiveInfo.EventTrigger, objectiveInfo.StatusText, objectiveInfo.MaxValue);
        // objectiveManager = new ObjectiveManager();
    }

    private void OnEnable()
    {
        CreateWateringPot(m_wateringPotMaxValue);
    }

    private void CreateWateringPot(int maxValue)
    {
        for (int i = 0 ; i < 6; i++)
        {
            playerInventory.AddItem(itemsDB.ingredients[i]);
            playerInventory.AddItem(itemsDB.seeds[i]);
        }
        playerInventory.AddCoins(1000);
        wateringPot = new WateringPot(maxValue);
        for (int i = 0; i < 4; i++)
        {
            playerInventory.AddItem(itemsDB.potions[i]);
        }
        playerInventory.AddItem(itemsDB.seeds[0]);
    }
}
