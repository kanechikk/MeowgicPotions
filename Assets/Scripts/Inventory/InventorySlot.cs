using UnityEngine;

public class InventorySlot
{
    public Item item;
    public int count;
    public ItemCategory category;

    public InventorySlot()
    {
        category = ItemCategory.Nothing;
    }
}
