using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public Inventory inventory;

    public WateringPot wateringPot;

    public PlayerState lastPlayerState = new PlayerState();

    public PlayerData(int coins)
    {
        inventory = new Inventory(32);
        inventory.AddCoins(coins);
        wateringPot = new WateringPot(4);
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
    }

    [System.Serializable]
    private class SaveData
    {
        public PlayerState state;
        public List<ItemToSerialize> items = new List<ItemToSerialize>();
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

[System.Serializable]
public class PlayerState
{
    public Vec3 pos;
    public Vec3 rot;
    public int hp;
    public bool valid;
}

[System.Serializable]
public struct Vec3
{
    public float x;
    public float y;
    public float z;

    public static implicit operator Vector3(Vec3 v3) => new Vector3(v3.x, v3.y, v3.z);
    public static implicit operator Vec3(Vector3 v3) => new Vec3() { x = v3.x, y = v3.y, z = v3.z };
}
