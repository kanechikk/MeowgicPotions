using System;
using System.Collections.Generic;
using UnityEngine;

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

    public ItemsDB itemsDB { private set; get; }
    public ShopData shopData { private set; get; }
    public PlayerData player { private set; get; } = new PlayerData(0);

    private void Awake()
    {
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

        DontDestroyOnLoad(gameObject);

        LoadItemsDB(ingredients, potions, seeds);
        LoadShop(ingredients, seeds);

        LoadPlayerData();
        player.inventory.AddItem(potions[0]);
    }

    private void Start()
    {
        m_dayTimeManager.onDayChange += OnDayChange;
    }

    private void OnDayChange()
    {
        SavePlayerData();
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
