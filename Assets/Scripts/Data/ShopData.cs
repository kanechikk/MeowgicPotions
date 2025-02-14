using UnityEngine;

public class ShopData
{
    public Inventory inventory;

    public ShopData()
    {
        inventory = new Inventory(32);
    }

    public string ToJson()
    {
        SaveData saveData = new SaveData();
        saveData.inventory = inventory;

        return JsonUtility.ToJson(saveData);
    }

    public void FromJson(string json)
    {
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);
        if (saveData != null)
        {
            inventory = saveData.inventory;
        }
    }

    [System.Serializable]
    private class SaveData
    {
        public Inventory inventory;
    }
}
