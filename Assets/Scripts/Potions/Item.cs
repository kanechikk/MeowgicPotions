using System;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField] private string m_itemName = "ItemSample";
    [SerializeField] private  int m_price = 100;
    [SerializeField] private Sprite m_icon;    

    public string itemName => this.m_itemName;
    public int price => this.m_price;
    public Sprite icon => this.m_icon;
    
}
