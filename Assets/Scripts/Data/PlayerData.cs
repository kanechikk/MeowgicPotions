using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public Inventory inventory;

    public WateringPot wateringPot;

    public PlayerData(int coins)
    {
        inventory = new Inventory(32);
        inventory.AddCoins(coins);
        wateringPot = new WateringPot(5);
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
        saveData.waterAmount = wateringPot.currentValue;
        saveData.coins = inventory.coins;

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
        wateringPot.SetNeededAmount(saveData.waterAmount);
        inventory.AddCoins(saveData.coins);
    }

    [System.Serializable]
    private class SaveData
    {
        public List<ItemToSerialize> items = new List<ItemToSerialize>();
        public int coins;
        public int waterAmount;
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
