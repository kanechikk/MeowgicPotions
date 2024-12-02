using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotionsCreating : MonoBehaviour
{
    [SerializeField] private List<Potion> potions;
    //private List<Ingredient> cauldron = new List<Ingredient>();
    //public Action<Ingredient> onIngredientAdded;
    private Potion finalPotion;
    public Action<Potion> onPotionReady;

    public void AddIngredientToCauldron(Ingredient item)
    {
        finalPotion.aqua += item.aqua;
        finalPotion.terra += item.terra;
        finalPotion.solar += item.solar;
        finalPotion.ignis += item.ignis;
        finalPotion.aer += item.aer;

        CountRatio();
    }

    private void CountRatio()
    {
        foreach (var potion in potions)
        {
            if (finalPotion.aqua / finalPotion.terra == potion.aqua / potion.terra &&
                finalPotion.aqua / finalPotion.solar == potion.aqua / potion.solar &&
                finalPotion.aqua / finalPotion.ignis == potion.aqua / potion.ignis &&
                finalPotion.aqua / finalPotion.aer == potion.aqua / potion.aer &&
                
                finalPotion.terra / finalPotion.solar == potion.terra / potion.solar &&
                finalPotion.terra / finalPotion.ignis == potion.terra / potion.ignis &&
                finalPotion.terra / finalPotion.aer == potion.terra / potion.aer &&
                
                finalPotion.solar / finalPotion.ignis == potion.solar / potion.ignis &&
                finalPotion.solar / finalPotion.aer == potion.solar / potion.aer &&
                
                finalPotion.ignis / finalPotion.aer == potion.ignis / potion.aer)
            {
                onPotionReady?.Invoke(potion);
                return;
            }
        }
    }
}
