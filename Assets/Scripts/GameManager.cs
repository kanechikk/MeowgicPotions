using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static Inventory playerInventory;
    public static ObjectiveManager objectiveManager;
    // [SerializeField] private QuestInfo objectiveInfo;
    // [SerializeField] private Objective objective;
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
        // objective = new Objective(objectiveInfo.EventTrigger, objectiveInfo.StatusText, objectiveInfo.MaxValue);
        // objectiveManager = new ObjectiveManager();
    }

    private void OnEnable()
    {
        CreateWateringPot(m_wateringPotMaxValue);
        Debug.Log($"Watering Pot: {wateringPot.currentValue}");
    }

    private void CreateWateringPot(int maxValue)
    {
        // objectiveManager.AddObjective(objective);
        for (int i = 0 ; i < 6; i++)
        {
            playerInventory.AddItem(itemsDB.ingredients[i]);
            playerInventory.AddItem(itemsDB.seeds[i]);
        }
        wateringPot = new WateringPot(maxValue);
        for (int i = 0; i < 5; i++)
        {
            playerInventory.AddItem(itemsDB.potions[i]);
        }
        playerInventory.AddItem(itemsDB.seeds[0]);
    }
}
