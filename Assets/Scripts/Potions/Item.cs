using UnityEngine;

public abstract class Item : ScriptableObject
{
    public int id;
    public string itemName = "ItemSample";
    public float price = 100.0f;
    //maybe we shouldnt have price for all items? tools shouldnt be sellable and such
    //ingridients too
    //only potions are sellable i think
    public Sprite icon;
    public GameObject prefab;
}
