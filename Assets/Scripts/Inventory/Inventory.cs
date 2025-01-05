using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.Search;
using UnityEngine;

public class Inventory
{
    private List<InventorySlot> m_slots;

    public IReadOnlyList<InventorySlot> slots => m_slots;

    private Item coins;

    public Inventory(int slotSize)
    {
        m_slots = new List<InventorySlot>(slotSize);
        for (int i = 0; i < slotSize; ++i)
        {
            m_slots.Add(new InventorySlot());
        }
    }

    public void AddItem(Item item)
    {
        int index = m_slots.FindIndex(x => x.item == null);
        if (index >= 0)
        {
            SetItem(index, item);
        }
    }

    public void RemoveItem(Item item)
    {
        var slot = m_slots.Find(x => x.item == item);
        if (slot != null)
        {
            if (--slot.count == 0)
            {
                slot.item = null;
            }
        }
    }

    public void SetItem(int indexSlot, Item item)
    {
        if (m_slots.Count > 0 && indexSlot < m_slots.Count)
        {
            var slot = m_slots[indexSlot];

            if (item is Potion)
            {
                slot.category = ItemCategory.Potion;
            }
            else if (item is Ingredient)
            {
                slot.category = ItemCategory.Ingredient;
            }
            
            slot.item = item;
            slot.count++;
        }
    }

    public List<InventorySlot> GetItemsByType(ItemCategory itemCategory)
    {
        List<InventorySlot> items = new List<InventorySlot>();
        foreach (InventorySlot inventorySlot in m_slots)
        {
            if (inventorySlot.category == itemCategory)
            {
                items.Add(inventorySlot);
            }
        }
        return items;
    }
    
    public void AddCoins(int value)
    {
        m_slots[0].item = coins;
        m_slots[0].count = value;
    }
}
