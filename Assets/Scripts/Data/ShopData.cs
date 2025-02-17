using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopData
{
    public Inventory inventory;

    public ShopData(Ingredient[] ingredients, Seed[] seeds)
    {
        inventory = new Inventory(32);
        foreach (Ingredient ingredient in ingredients)
        {
            inventory.AddItem(ingredient);
        }
        foreach (Seed seed in seeds)
        {
            inventory.AddItem(seed);
        }
    }

    public string ToJson()
    {
        SaveData saveData = new SaveData();
        
        foreach (InventorySlot itemSlot in inventory.slots)
        {
            if (itemSlot.category != ItemCategory.Nothing)
            {
                saveData.items.Add(new ItemToSerialize(itemSlot.item.id, itemSlot.count));
            }
        }

        return JsonUtility.ToJson(saveData);
    }

    public void FromJson(string json, List<Item> items)
    {
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);
        if (saveData != null)
        {
            foreach (ItemToSerialize item in saveData.items)
            {
                for (int i = 0; i < item.count; i++)
                {
                    inventory.AddItem(items.Find(x => x.id == item.id));
                }
            }
        }
    }

    [System.Serializable]
    private class SaveData
    {
        public List<ItemToSerialize> items = new List<ItemToSerialize>();
    }
}

[System.Serializable]
public class ItemToSerialize
{
    public string id;
    public int count;

    public ItemToSerialize()
    {

    }

    public ItemToSerialize(string id, int count)
    {
        this.id = id;
        this.count = count;
    }
}
