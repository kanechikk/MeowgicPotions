using System;
using System.Collections.Generic;
using System.Diagnostics;

[System.Serializable]
public class Inventory
{
    private List<InventorySlot> m_slots;

    private int m_coins = 0;

    public int coins => m_coins;

    public List<InventorySlot> slots => m_slots;

    public event Action<Item> onInvChange;

    public Inventory(int slotSize)
    {
        m_slots = new List<InventorySlot>(slotSize);
        for (int i = 0; i < slotSize; ++i)
        {
            m_slots.Add(new InventorySlot());
        }
    }

    public int AddItem(Item item)
    {
        int index = m_slots.FindIndex(x => x.item == item);

        onInvChange?.Invoke(item);

        if (index >= 0)
        {
            StackItem(index);
            // Индекс слота с айтемом
            
            return index;
        }
        else
        {
            index = m_slots.FindIndex(x => x.item == null);
            if (index >= 0)
            {
                SetItem(index, item);
            }
            else
            {
                m_slots.Add(new InventorySlot());
                SetItem(m_slots.Count - 1, item);
            }
            // Индекс слота с новым айтемом
            
            return index;
        }
    }

    public void AddCoins(int value)
    {
        m_coins += value;
    }

    public void RemoveItem(Item item)
    {
        var slot = m_slots.Find(x => x.item == item);
        if (slot != null)
        {
            if (--slot.count == 0)
            {
                slot.item = null;
                slot.category = ItemCategory.Nothing;
            }
            onInvChange?.Invoke(item);
        }
    }

    private void SetItem(int indexSlot, Item item)
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
            else if (item is Seed)
            {
                slot.category = ItemCategory.Seed;
            }
            else if (item is SampleItem)
            {
                slot.category = ItemCategory.Nothing;
            }
            
            slot.item = item;
            slot.count++;
        }
    }

    private void StackItem(int indexSlot)
    {
        m_slots[indexSlot].count++;
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

    public int GetSlotIndex(Item item)
    {
        for (int i = 0; i < m_slots.Count; i++)
        {
            if (m_slots[i].item)
            {
                if (m_slots[i].item.id == item.id)
                {
                    return i;
                }
            }
        }
        return -1;
    }
}
