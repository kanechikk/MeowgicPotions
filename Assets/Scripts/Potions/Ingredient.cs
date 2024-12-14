using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Scriptable Objects/Ingredient")]
public class Ingredient : Item
{
    //public List<ElementType> elementsHaving = new List<ElementType>();
    public int aqua;
    public int terra;
    public int solar;
    public int ignis;
    public int aer;
    Dictionary<string, int> elements;

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
