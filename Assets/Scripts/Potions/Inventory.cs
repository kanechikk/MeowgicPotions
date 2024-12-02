using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Ingredient> ingredients = new List<Ingredient>();
    
    public Ingredient GetIngredient(string name)
    {
        foreach (var ing in ingredients)
        {
            if (ing.itemName == name)
            {
                return ing;
            }
        }
        return null;
    }
}
