using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField] private string m_itemName = "ItemSample";
    [SerializeField] private  float m_price = 100.0f;
    [SerializeField] private Sprite m_icon;

    public string itemName => this.m_itemName;
    public float price => this.m_price;
    public Sprite icon => this.m_icon;
}
