using System.Collections.Generic;
using System;
using UnityEngine;

public class Cauldron: MonoBehaviour
{
    private List<Ingredient> m_addedIngredients = new List<Ingredient>();
    private int m_aquaCount = 0;
    private int m_ignisCount = 0;
    private int m_terraCount = 0;
    private int m_aerCount = 0;
    private int m_solarCount = 0;

    public void AddIngredient(Ingredient ingredient)
    {
        if (ingredient != null)
        {
            m_addedIngredients.Add(ingredient);

            m_aquaCount += ingredient.elements["aqua"];
            m_ignisCount += ingredient.elements["ignis"];
            m_terraCount += ingredient.elements["terra"];
            m_aerCount += ingredient.elements["aer"];
            m_solarCount += ingredient.elements["solar"];

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
            
            m_aquaCount -= ingredient.elements["aqua"];
            m_ignisCount -= ingredient.elements["ignis"];
            m_terraCount -= ingredient.elements["terra"];
            m_aerCount -= ingredient.elements["aer"];
            m_solarCount -= ingredient.elements["solar"];

            Debug.Log($"Удален ингредиент: {ingredient.itemName}"); 
        }
    }

    public void ClearAll()
    {
        m_addedIngredients.Clear();

        m_aquaCount = 0;
        m_ignisCount = 0;
        m_terraCount = 0;
        m_aerCount = 0;
        m_solarCount = 0;
    }

    public bool RecipeCheck(Potion recipe)
    {
        if (recipe.elements["aqua"] == m_aquaCount &&
            recipe.elements["ignis"] == m_ignisCount &&
            recipe.elements["terra"] == m_terraCount &&
            recipe.elements["aer"] == m_aerCount &&
            recipe.elements["solar"] == m_solarCount)
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
        Debug.Log($"Aqua: {m_aquaCount}");
        Debug.Log($"Ignis: {m_ignisCount}");
        Debug.Log($"Terra: {m_terraCount}");
        Debug.Log($"Aer: {m_aerCount}");
        Debug.Log($"Solar: {m_solarCount}");
    }
}

