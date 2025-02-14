using UnityEngine;

public class ShopData
{
    public Inventory inventory = new Inventory(32);

    public ShopData()
    {
        
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
