using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlantingState : GameStateBehaviour
{
    [SerializeField] private GameObject m_clickableItemPrefab;
    [SerializeField] private GameObject m_inventorySlots;

    private Seed m_currentSeed;
    private bool m_needToRefreshInventory;

    public event Action<Seed> onPlantSeed;

    private void OnEnable()
    {
        FillSlots();
        WalkingState.inventory.onInvChange += OnInventoryChange;
    }

    private void OnInventoryChange()
    {
        FillSlots();
    }

    private void FillSlots()
    {
        // Вызываем айтемы из инвентаря
        List<InventorySlot> seeds = WalkingState.inventory.GetItemsByType(ItemCategory.Seed);

        // Меняет айтем на тот, что есть в инвентаре игрока
        foreach (InventorySlot seed in seeds)
        {
            GameObject newItem = Instantiate(m_clickableItemPrefab, m_inventorySlots.transform);
            newItem.GetComponentInChildren<ClickableItem>().item = seed.item;
            newItem.GetComponentInChildren<ClickableItem>().onAddItem += OnAddItem;
        }
    }

    private void OnAddItem(Item seed)
    {
        m_currentSeed = (Seed)seed;
        Debug.Log("Seed chosen");
    }

    public void Plant()
    {
        WalkingState.inventory.RemoveItem(m_currentSeed);
        onPlantSeed?.Invoke(m_currentSeed);
        Debug.Log($"{m_currentSeed.itemName} planted");
    }

    private void OnDisable()
    {
        Transform[] inventorySlots = m_inventorySlots.GetComponentsInChildren<Transform>().Skip(1).ToArray();
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            Destroy(inventorySlots[i].gameObject);
        }
    }
}
