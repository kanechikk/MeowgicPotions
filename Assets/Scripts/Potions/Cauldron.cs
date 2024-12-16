using System.Collections.Generic;
using System;
using UnityEngine;

public class Cauldron: MonoBehaviour
{
    private List<Ingredient> addedIngredients = new List<Ingredient>();
    private int aquaCount = 0;
    private int ignisCount = 0;
    private int terraCount = 0;
    private int aerCount = 0;
    private int solarCount = 0;

    public void AddIngredient(Ingredient ingredient)
    {
        if (ingredient != null)
        {
            addedIngredients.Add(ingredient);
            foreach (ElementType element in ingredient.elementsHaving)
            {
                switch (element)
                {
                    case ElementType.Aqua:
                        aquaCount++;
                        break;
                    case ElementType.Ignis:
                        ignisCount++;
                        break;
                    case ElementType.Terra:
                        terraCount++;
                        break;
                    case ElementType.Aer:
                        aerCount++;
                        break;
                    case ElementType.Solar:
                        solarCount++;
                        break;
                }
            }
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
            foreach (ElementType element in ingredient.elementsHaving)
            {
                switch (element)
                {
                    case ElementType.Aqua:
                        aquaCount--;
                        break;
                    case ElementType.Ignis:
                        ignisCount--;
                        break;
                    case ElementType.Terra:
                        terraCount--;
                        break;
                    case ElementType.Aer:
                        aerCount--;
                        break;
                    case ElementType.Solar:
                        solarCount--;
                        break;
                }
            }
            Debug.Log($"Удален ингредиент: {ingredient.itemName}"); 
        }
    }

    public void ShowIngredients()
    {
        Debug.Log("Содержимое котла:");
        foreach (var ingredient in addedIngredients)
            Debug.Log($"- {ingredient.itemName}");
        
        Debug.Log("Свойства в котле:");
        Debug.Log($"Aqua: {aquaCount}");
        Debug.Log($"Ignis: {ignisCount}");
        Debug.Log($"Terra: {terraCount}");
        Debug.Log($"Aer: {aerCount}");
        Debug.Log($"Solar: {solarCount}");
    }
}

