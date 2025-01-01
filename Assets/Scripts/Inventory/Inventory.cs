using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<InventorySlot> m_slots;

    public IReadOnlyList<InventorySlot> slots => m_slots;

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
        int index = m_slots.FindIndex(x => x.item == item);
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
            if (item is Potion)
            {
                slot.category = ItemCategory.Potion;
            }
            else if (item is Ingredient)
            {
                slot.category = ItemCategory.Ingredient;
            }

            var slot = m_slots[indexSlot];
            slot.item = item;
            slot.count++;
        }
    }
}
