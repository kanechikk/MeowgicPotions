using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<Ingredient> ingredients;
    [SerializeField] private PotionCreating potionsCreating;
    private void Start()
    {
        if (ingredients.Count != 0 && potionsCreating)
        {
            potionsCreating.AddIngredientToCauldron(ingredients[0]);
            potionsCreating.CountRatio();
            potionsCreating.AddIngredientToCauldron(ingredients[1]);
            potionsCreating.CountRatio();
            potionsCreating.AddIngredientToCauldron(ingredients[2]);
            potionsCreating.CountRatio();
        }
    }

    private void OnDisable()
    {
        potionsCreating.ClearPotion();
    }

    // private void Update()
    // {
    //     potionsCreating.onPotionReady += PotionReady;
    // }

    // private void PotionReady(Potion potion)
    // {
    //     Debug.Log(potion.itemName);
    // }
}
