using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopData
{
    public Inventory inventory;

    public ShopData(Ingredient[] ingredients, Seed[] seeds)
    {
        inventory = new Inventory(32);
        foreach (Ingredient ingredient in ingredients)
        {
            inventory.AddItem(ingredient);
        }
        foreach (Seed seed in seeds)
        {
            inventory.AddItem(seed);
        }
    }
}
