using System.Collections.Generic;
using System;
using UnityEngine;
using JetBrains.Annotations;
using Unity.Mathematics;

public class Cauldron: MonoBehaviour
{
    private List<Ingredient> m_addedIngredients;
    public IReadOnlyList<Ingredient> addedIngredients => m_addedIngredients;
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
            m_addedIngredients.Add(ingredient);

            aquaCount += ingredient.elements["Aqua"];
            ignisCount += ingredient.elements["Ignis"];
            terraCount += ingredient.elements["Terra"];
            aerCount += ingredient.elements["Aer"];
            solarCount += ingredient.elements["Solar"];
        }
    }

    public void RemoveIngredient(Ingredient ingredient)
    {
        if (ingredient != null)
        {
            m_addedIngredients.Remove(ingredient);
            
            aquaCount -= ingredient.elements["Aqua"];
            ignisCount -= ingredient.elements["Ignis"];
            terraCount -= ingredient.elements["Terra"];
            aerCount -= ingredient.elements["Aer"];
            solarCount -= ingredient.elements["Solar"];
        }
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
}

