using UnityEngine;

public class PlayerData
{
    private Inventory m_inventory;

    public PlayerState lastPlayerState = new PlayerState();

    public PlayerData()
    {
        m_inventory = new Inventory(32);
    }

    public string ToJson()
    {
        SaveData saveData = new SaveData();
        saveData.state = lastPlayerState;

        return JsonUtility.ToJson(saveData);
    }

    public void FromJson(string json)
    {
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);
        if (saveData != null)
        {
            lastPlayerState = saveData.state;
        }
    }

    [System.Serializable]
    private class SaveData
    {
        public PlayerState state;
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
