using System.Collections.Generic;
using System;
using UnityEngine;
using JetBrains.Annotations;
using Unity.Mathematics;

public class Cauldron : MonoBehaviour
{
    private List<Ingredient> m_addedIngredients;
    public IReadOnlyList<Ingredient> addedIngredients => m_addedIngredients;
    private List<object> m_addedElements;

    // public int aquaCount { private set; get; } = 0;
    // public int ignisCount { private set; get; } = 0;
    // public int terraCount { private set; get; } = 0;
    // public int aerCount { private set; get; } = 0;
    // public int solarCount { private set; get; } = 0;

    private void Awake()
    {
        m_addedIngredients = new List<Ingredient>();
        m_addedElements = new List<object>();
    }
    public void AddIngredient(Ingredient ingredient)
    {
        if (ingredient != null)
        {
            m_addedIngredients.Add(ingredient);

            foreach (Element element in ingredient.elements)
            {
                AddElement(element);
            }
        }
    }

    public void RemoveIngredient(Ingredient ingredient)
    {
        if (ingredient != null)
        {
            m_addedIngredients.Remove(ingredient);

            foreach (Element element in ingredient.elements)
            {
                RemoveElement(element);
            }
        }
    }

    public void ClearCauldron()
    {
        m_addedIngredients = new List<Ingredient>();
        m_addedElements = new List<object>();
    }

    private void AddElement(Element element)
    {
        foreach (Element elem in m_addedElements)
        {
            if (elem.type == element.type)
            {
                elem.value += element.value;
                return;
            }
        }

        m_addedElements.Add(element.Clone());
    }

    private void RemoveElement(Element element)
    {
        foreach (Element elem in m_addedElements)
        {
            if (elem.type == element.type)
            {
                elem.value -= element.value;

                if (elem.value == 0)
                {
                    m_addedElements.Remove(elem);
                    return;
                }
            }
        }
    }

    public bool RecipeCheck(Potion recipe)
    {
        Element element;
        foreach (Element item in recipe.elements)
        {
            int val = 0;
            foreach (Ingredient ingr in m_addedIngredients)
            {
                element = ingr.elements.Find(x => x.type == item.type);
                if (element != null)
                {
                    val += element.value;
                }
            }

            if (val != item.value)
            {
                return false;
            }  
        }
        return true;
    }

    public string GetInfo()
    {
        string elementsInfo = "";
        
        foreach (Element element in m_addedElements)
        {
            elementsInfo += $"{element.elementName}: {element.value}\n";
        }

        return elementsInfo;
    }
}

