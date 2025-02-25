using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlantsManager : MonoBehaviour
{
    [SerializeField] private DayTimeManager m_dayTimeManager;
    [SerializeField] private Plant[] m_plants;
    public Plant[] plants => m_plants;

    [SerializeField] private GameObject m_clickableItemPrefab;
    [SerializeField] private GameObject m_inventorySlots;
    private Seed m_currentSeed;
    public event Action<Seed> onPlantSeed;

    private void Awake()
    {
        GameManager.instance.player.inventory.onInvChange += OnInventoryChange;
    }

    private void Start()
    {
        foreach (Plant plant in m_plants)
        {
            plant.SubscribeOnDayTimeManager(m_dayTimeManager);
        }
    }

    private void OnInventoryChange(Item item)
    {
        DeleteAll();
        FillSlots();
    }

    private void FillSlots()
    {
        List<InventorySlot> seeds = GameManager.instance.player.inventory.GetItemsByType(ItemCategory.Seed);

        foreach (InventorySlot seed in seeds)
        {
            Debug.Log(seed.item);

            GameObject newItem = Instantiate(m_clickableItemPrefab, m_inventorySlots.transform);
            ClickableItem clickableItem = newItem.GetComponent<ClickableItem>();
            clickableItem.item = seed.item;
            clickableItem.onAddItem += OnAddItem;

            Debug.Log("new irem");
        }
    }

    private void OnAddItem(Item seed)
    {
        m_currentSeed = (Seed)seed;
        Debug.Log($"{m_currentSeed.itemName} chosen");
    }

    public void Plant()
    {
        GameManager.instance.player.inventory.RemoveItem(m_currentSeed);
        onPlantSeed?.Invoke(m_currentSeed);
    }

    private void DeleteAll()
    {
        Transform[] inventorySlots = m_inventorySlots.GetComponentsInChildren<Transform>().Skip(1).ToArray();
        if (inventorySlots.Length > 0)
        {
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                Destroy(inventorySlots[i].gameObject);
            }
        }
    }


}
