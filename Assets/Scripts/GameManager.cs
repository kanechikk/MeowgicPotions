using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindAnyObjectByType<GameManager>();
            }
            return m_instance;
        }
    }

    [SerializeField] private DayTimeManager m_dayTimeManager;
    [SerializeField] private PlantsManager m_plantsManager;

    public ItemsDB itemsDB { private set; get; }
    public ShopData shopData { private set; get; }
    public DayData dayData { private set; get; }
    public PlayerData player { private set; get; } = new PlayerData(1000);
    public GardenData garden { private set; get; }

    void Update()
    {
        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            player.inventory.AddItem(itemsDB.potions[0]);
        }
    }

    private void Awake()
    {
        Ingredient[] ingredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
        Potion[] potions = Resources.LoadAll<Potion>("ScriptableObjects/Potions");
        Seed[] seeds = Resources.LoadAll<Seed>("ScriptableObjects/Seeds");

        dayData = new DayData(m_dayTimeManager);
        garden = new GardenData(m_plantsManager.plants);

        if (m_instance == null)
        {
            m_instance = this;
        }

        if (m_instance != this)
        {
            Destroy(gameObject);
            return;
        }

        LoadItemsDB(ingredients, potions, seeds);
        LoadShop(ingredients, seeds);

        DontDestroyOnLoad(gameObject);

        LoadDayData();
        LoadPlayerData();
        LoadGardenData();
    }

    private void Start()
    {
        m_dayTimeManager.onDayChange += OnDayChange;
    }

    private void OnDayChange()
    {
        SavePlayerData();
        SaveDayData();
        SaveGardenData();
    }

    private void SaveGardenData()
    {
        DataProcess.SaveGarden(garden);
    }

    private void LoadGardenData()
    {
        List<Seed> seeds = new List<Seed>();
        seeds.AddRange(itemsDB.seeds);
        DataProcess.LoadGarden(garden, seeds);
    }

    private void LoadItemsDB(Ingredient[] ingredients, Potion[] potions, Seed[] seeds)
    {
        itemsDB = new ItemsDB(ingredients, potions, seeds);
    }

    private void LoadShop(Ingredient[] ingredients, Seed[] seeds)
    {
        shopData = new ShopData(ingredients, seeds);
    }

    public void SavePlayerData()
    {
        DataProcess.SavePlayer(player);
    }

    public void LoadPlayerData()
    {
        List<Item> items = new List<Item>();
        items.AddRange(itemsDB.ingredients);
        items.AddRange(itemsDB.potions);
        items.AddRange(itemsDB.seeds);
        DataProcess.LoadPlayer(player, items);
    }

    private void SaveDayData()
    {
        DataProcess.SaveDay(dayData);
    }

    private void LoadDayData()
    {
        DataProcess.LoadDay(dayData);
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        Debug.Log($"[GameManager]: OnApplicationPause({pauseStatus})");
    }

    private void OnApplicationFocus(bool focusStatus)
    {
        Debug.Log($"[GameManager]: OnApplicationFocus({focusStatus})");
    }

    private void OnApplicationQuit()
    {
        Debug.Log($"[GameManager]: OnApplicationQuit()");
    }
}
