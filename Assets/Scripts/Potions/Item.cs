using UnityEngine;

public abstract class Item : ScriptableObject
{
    public int id;
    public string itemName = "ItemSample";
    public float price = 100.0f;
    public Sprite icon;
    public GameObject prefab;
}
