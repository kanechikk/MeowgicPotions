using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlantingState : GameStateBehaviour
{
    [SerializeField] private GameObject m_clickableItemPrefab;
    [SerializeField] private GameObject m_inventorySlots;

    private Seed m_currentSeed;
    public event Action<Seed> onPlantSeed;

    private void OnEnable()
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
    }

    public void Plant()
    {
        onPlantSeed?.Invoke(m_currentSeed);
    }
}
