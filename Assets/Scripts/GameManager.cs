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

    public ItemsDB itemsDB { private set; get; }
    public PlayerData player { private set; get; } = new PlayerData(100);
    public ShopData shopData { private set; get; }


    private void Awake()
    {
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

        LoadItemsDB();

        //LoadPlayerData();
        LoadShopData();
        player.inventory.AddCoins(1000);
    }

    private void LoadItemsDB()
    {
        Ingredient[] ingredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
        Potion[] potions = Resources.LoadAll<Potion>("ScriptableObjects/Potions");
        Seed[] seeds = Resources.LoadAll<Seed>("ScriptableObjects/Seeds");

        itemsDB = new ItemsDB(ingredients, potions, seeds);
        shopData = new ShopData(ingredients, seeds);
    }

    public void SavePlayerData()
    {
        PlayerDataProcess.SavePlayer(player);
    }

    public void LoadPlayerData()
    {
        PlayerDataProcess.LoadPlayer(player);
    }

    public void SaveShopData()
    {
        ShopDataProcess.SaveShop(shopData);
    }

    public void LoadShopData()
    {
        List<Item> items = new List<Item>();
        items.AddRange(itemsDB.ingredients);
        items.AddRange(itemsDB.seeds);
        ShopDataProcess.LoadShop(shopData, items);
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

        //SavePlayerData();
        SaveShopData();
        Debug.Log(Application.persistentDataPath);
    }
}
