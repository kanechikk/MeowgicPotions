using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotionCreating : MonoBehaviour
{
    [SerializeField] private List<Potion> potions;
    //private List<Ingredient> cauldron = new List<Ingredient>();
    //public Action<Ingredient> onIngredientAdded;
    [SerializeField] private Potion finalPotion;
    public Action<Potion> onPotionReady;

    //private int countIng = 0;

    public void ClearPotion()
    {
        finalPotion.aqua = 0.0f;
        finalPotion.terra = 0.0f;
        finalPotion.solar = 0.0f;
        finalPotion.ignis = 0.0f;
        finalPotion.aer = 0.0f;

        //countIng = 0;
    }
    public void AddIngredientToCauldron(Ingredient item)
    {
        finalPotion.aqua += item.aqua;
        finalPotion.terra += item.terra;
        finalPotion.solar += item.solar;
        finalPotion.ignis += item.ignis;
        finalPotion.aer += item.aer;
        //countIng++;
    }

    public void CountRatio()
    {
       // Debug.Log(finalPotion.aqua / finalPotion.terra != float.NaN);
        foreach (var potion in potions)
        {
            Debug.Log(finalPotion.aqua / finalPotion.terra);
            if ((finalPotion.aqua / finalPotion.terra == potion.aqua / potion.terra || finalPotion.aqua / finalPotion.terra != float.NaN) &&
                (finalPotion.aqua / finalPotion.solar == potion.aqua / potion.solar || finalPotion.aqua / finalPotion.solar != float.NaN) &&
                (finalPotion.aqua / finalPotion.ignis == potion.aqua / potion.ignis || finalPotion.aqua / finalPotion.ignis != float.NaN) &&
                (finalPotion.aqua / finalPotion.aer == potion.aqua / potion.aer || finalPotion.aqua / finalPotion.aer != float.NaN) &&
                
                (finalPotion.terra / finalPotion.solar == potion.terra / potion.solar || finalPotion.terra / finalPotion.solar != float.NaN) &&
                (finalPotion.terra / finalPotion.ignis == potion.terra / potion.ignis || finalPotion.terra / finalPotion.ignis != float.NaN) &&
                (finalPotion.terra / finalPotion.aer == potion.terra / potion.aer || finalPotion.terra / finalPotion.aer != float.NaN) &&
                
                (finalPotion.solar / finalPotion.ignis == potion.solar / potion.ignis || finalPotion.solar / finalPotion.ignis != float.NaN) &&
                (finalPotion.solar / finalPotion.aer == potion.solar / potion.aer || finalPotion.solar / finalPotion.aer != float.NaN) &&
                
                (finalPotion.ignis / finalPotion.aer == potion.ignis / potion.aer || finalPotion.ignis / finalPotion.aer != float.NaN))
            {
                Debug.Log(potion.itemName);
                //onPotionReady?.Invoke(potion);
                //return;
            }
        }
    }
}
