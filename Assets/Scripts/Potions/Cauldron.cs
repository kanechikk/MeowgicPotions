using System.Collections.Generic;
using System;
using UnityEngine;
using JetBrains.Annotations;

public class Cauldron: MonoBehaviour
{
    private List<Ingredient> m_addedIngredients;
    public int aquaCount { private set; get; } = 0;
    public int ignisCount { private set; get; } = 0;
    public int terraCount { private set; get; } = 0;
    public int aerCount { private set; get; } = 0;
    public int solarCount { private set; get; } = 0;

    private void Awake()
    {
        m_addedIngredients = new List<Ingredient>();
    }
    public void AddIngredient(Ingredient ingredient)
    {
        if (ingredient != null)
        {
            Debug.Log(ingredient);
            m_addedIngredients.Add(ingredient);

            aquaCount += ingredient.elements["Aqua"];
            ignisCount += ingredient.elements["Ignis"];
            terraCount += ingredient.elements["Terra"];
            aerCount += ingredient.elements["Aer"];
            solarCount += ingredient.elements["Solar"];

            Debug.Log($"Добавлен ингредиент: {ingredient.itemName}");
        }
    }

    public void RemoveIngredient(Ingredient ingredient)
    {
        if (m_addedIngredients.Count == 0)
        {
            Debug.LogWarning("Котел пуст, нечего удалять");
            return;
        }
        if (ingredient != null)
        {
            m_addedIngredients.Remove(ingredient);
            
            aquaCount -= ingredient.elements["Aqua"];
            ignisCount -= ingredient.elements["Ignis"];
            terraCount -= ingredient.elements["Terra"];
            aerCount -= ingredient.elements["Aer"];
            solarCount -= ingredient.elements["Solar"];

            Debug.Log($"Удален ингредиент: {ingredient.itemName}"); 
        }
    }

    public void ClearAll()
    {
        m_addedIngredients.Clear();

        aquaCount = 0;
        ignisCount = 0;
        terraCount = 0;
        aerCount = 0;
        solarCount = 0;
    }

    public bool RecipeCheck(Potion recipe)
    {
        if (recipe.elements["Aqua"] == aquaCount &&
            recipe.elements["Ignis"] == ignisCount &&
            recipe.elements["Terra"] == terraCount &&
            recipe.elements["Aer"] == aerCount &&
            recipe.elements["Solar"] == solarCount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ShowIngredients()
    {
        Debug.Log("Содержимое котла:");
        foreach (var ingredient in m_addedIngredients)
            Debug.Log($"- {ingredient.itemName}");
        
        Debug.Log("Свойства в котле:");
        Debug.Log($"Aqua: {aquaCount}");
        Debug.Log($"Ignis: {ignisCount}");
        Debug.Log($"Terra: {terraCount}");
        Debug.Log($"Aer: {aerCount}");
        Debug.Log($"Solar: {solarCount}");
    }
}

