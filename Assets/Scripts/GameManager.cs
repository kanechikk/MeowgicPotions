using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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

    private DayTimeManager m_dayTimeManager;
    private PlantsManager m_plantsManager;

    public ItemsDB itemsDB { private set; get; }
    public ShopData shopData { private set; get; }
    public DayData dayData { private set; get; }
    public PlayerData player { private set; get; } = new PlayerData(0);
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
        SceneManager.sceneLoaded += GetManagers;

        Ingredient[] ingredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
        Potion[] potions = Resources.LoadAll<Potion>("ScriptableObjects/Potions");
        Seed[] seeds = Resources.LoadAll<Seed>("ScriptableObjects/Seeds");

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

        DontDestroyOnLoad(gameObject);
    }

    private void GetManagers(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name == "MainScene")
        {
            m_dayTimeManager = FindAnyObjectByType<DayTimeManager>();
            m_plantsManager = FindAnyObjectByType<PlantsManager>();
            m_dayTimeManager.onDayChange += OnDayChange;
            dayData = new DayData(m_dayTimeManager);
            garden = new GardenData(m_plantsManager);
            LoadDayData();
            LoadGardenData();
        }
    }

    private void OnDayChange(DayTime time)
    {
        ReloadShop(itemsDB.ingredients, itemsDB.seeds);
        SavePlayerData();
        SaveDayData();
        SaveGardenData();
    }

    private void SaveGardenData()
    {
        DataProcess.SaveGarden(garden);
    }

    public void LoadGardenData()
    {
        List<Seed> seeds = new List<Seed>();
        seeds.AddRange(itemsDB.seeds);
        DataProcess.LoadGarden(garden, seeds);
    }

    private void LoadItemsDB(Ingredient[] ingredients, Potion[] potions, Seed[] seeds)
    {
        itemsDB = new ItemsDB(ingredients, potions, seeds);
    }

    public void LoadShop()
    {
        shopData = new ShopData(itemsDB.ingredients, itemsDB.seeds);
    }

    private void ReloadShop(Ingredient[] ingredients, Seed[] seeds)
    {
        shopData.ReloadShop(ingredients, seeds);
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

    public void LoadDayData()
    {
        DataProcess.LoadDay(dayData);
    }
}
