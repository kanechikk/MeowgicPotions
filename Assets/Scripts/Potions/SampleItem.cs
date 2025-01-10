using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class SampleItem : Item
{
    public string SampleToString()
    {
        string text = $"Name: {itemName}, price: {price}";
        return text;
    }
}
