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
    public PlayerData player { private set; get; } = new PlayerData();
    public ShopData shopData { private set; get; } = new ShopData();


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

        LoadPlayerData();
        LoadShopData();
    }

    private void LoadItemsDB()
    {
        Ingredient[] ingredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
        Potion[] potions = Resources.LoadAll<Potion>("ScriptableObjects/Potions");
        Seed[] seeds = Resources.LoadAll<Seed>("ScriptableObjects/Seeds");

        itemsDB = new ItemsDB(ingredients, potions, seeds);
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
        ShopDataProcess.LoadShop(shopData);
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

        SavePlayerData();
        SaveShopData();
    }
}
