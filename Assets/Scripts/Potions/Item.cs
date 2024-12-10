using UnityEngine;

public abstract class Item : ScriptableObject
{
    public int id;
    public string itemName = "ItemSample";
    public float price = 100.0f;
    public string iconPath = "/icon.png";
    public GameObject prefab;
}
