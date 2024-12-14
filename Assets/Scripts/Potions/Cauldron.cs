using System.Collections.Generic;
using UnityEngine;

public class Cauldron: MonoBehaviour
{
    private List<Ingredient> addedIngredients = new List<Ingredient>();
    public void AddIngredient(Ingredient ingredient)
    {
        if (ingredient != null)
        {
            addedIngredients.Add(ingredient);
            Debug.Log($"Добавлен ингредиент: {ingredient.itemName}");
        }
    }

    public void RemoveIngredient(Ingredient ingredient)
    {
        if (addedIngredients.Count == 0)
        {
            Debug.LogWarning("Котел пуст, нечего удалять");
            return;
        }
        if (ingredient != null)
        {
            addedIngredients.Remove(ingredient);
            Debug.Log($"Удален ингредиент: {ingredient.itemName}");
        }
    }

    public void ShowIngredients()
    {
        Debug.Log("Содержимое котла:");
        foreach (var ingredient in addedIngredients)
        {
            Debug.Log($"- {ingredient.itemName}");
        }
    }
}

