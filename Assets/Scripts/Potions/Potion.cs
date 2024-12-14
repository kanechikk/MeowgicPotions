using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Scriptable Objects/Potion")]
public class Potion : Item
{
    //public List<ElementType> elementsNeedded = new List<ElementType>();
    public int aqua;
    public int terra;
    public int solar;
    public int ignis;
    public int aer;
    public Dictionary<string, int> elements;

    public void AddToDictionary()
    {
        elements = new Dictionary<string, int>()
        {
            {"aqua", aqua},
            {"terra", terra},
            {"solar", solar},
            {"ignis", ignis},
            {"aer", aer}
        };
    }
}
