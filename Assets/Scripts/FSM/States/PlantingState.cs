using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlantingState : GameStateBehaviour
{
    // [SerializeField] private GameObject m_clickableItemPrefab;
    // [SerializeField] private GameObject m_inventorySlots;
    // private Seed m_currentSeed;
    // public event Action<Seed> onPlantSeed;
    // private bool needToRefreshInventory;

    // private void Awake()
    // {
    //     GameManager.instance.player.inventory.onInvChange += OnInventoryChange;
    // }

    // private void OnInventoryChange(Item item)
    // {
    //     DeleteAll();
    //     FillSlots();
    //     Debug.Log("Владик сосиска");
    // }

    // private void FillSlots()
    // {
    //     List<InventorySlot> seeds = GameManager.instance.player.inventory.GetItemsByType(ItemCategory.Seed);

    //     foreach (InventorySlot seed in seeds)
    //     {
    //         GameObject newItem = Instantiate(m_clickableItemPrefab, m_inventorySlots.transform);
    //         ClickableItem clickableItem = newItem.GetComponent<ClickableItem>();
    //         clickableItem.item = seed.item;
    //         clickableItem.onAddItem += OnAddItem;
    //     }

    //     needToRefreshInventory = false;
    // }

    // private void OnAddItem(Item seed)
    // {
    //     m_currentSeed = (Seed)seed;
    //     Debug.Log($"{m_currentSeed.itemName} chosen");
    // }

    // public void Plant()
    // {
    //     GameManager.instance.player.inventory.RemoveItem(m_currentSeed);
    //     onPlantSeed?.Invoke(m_currentSeed);
    // }

    // private void DeleteAll()
    // {
    //     Transform[] inventorySlots = m_inventorySlots.GetComponentsInChildren<Transform>().Skip(1).ToArray();
    //     for (int i = 0; i < inventorySlots.Length; i++)
    //     {
    //         Destroy(inventorySlots[i].gameObject);
    //     }
    // }

}
