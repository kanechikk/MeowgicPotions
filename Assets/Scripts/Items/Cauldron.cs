using System.Collections.Generic;
using System;
using UnityEngine;
using JetBrains.Annotations;
using Unity.Mathematics;

public class Cauldron : MonoBehaviour
{
    private List<Ingredient> m_addedIngredients;
    public IReadOnlyList<Ingredient> addedIngredients => m_addedIngredients;
    private string m_elementsInfo;
    public string elementsInfo => m_elementsInfo;
    // public int aquaCount { private set; get; } = 0;
    // public int ignisCount { private set; get; } = 0;
    // public int terraCount { private set; get; } = 0;
    // public int aerCount { private set; get; } = 0;
    // public int solarCount { private set; get; } = 0;

    private void Awake()
    {
        m_addedIngredients = new List<Ingredient>();
        m_elementsInfo = "";

    }
    public void AddIngredient(Ingredient ingredient)
    {
        if (ingredient != null)
        {
            m_addedIngredients.Add(ingredient);
        }
    }

    public void RemoveIngredient(Ingredient ingredient)
    {
        if (ingredient != null)
        {
            m_addedIngredients.Remove(ingredient);
        }
    }

    public void ClearCauldron()
    {
        m_addedIngredients = new List<Ingredient>();
    }

    public bool RecipeCheck(Potion recipe)
    {
        m_elementsInfo = "";
        foreach (Element item in recipe.elements)
        {
            int val = 0;
            foreach (Ingredient ingr in m_addedIngredients)
            {
                val += ingr.elements.Find(x => x.type == item.type).value;
            }

            m_elementsInfo += $"{item.elementName}: {val}]\n";

            if (val != item.value)
            {
                return false;
            }  
        }
        return true;
    }
}

