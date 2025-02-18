using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Scriptable Objects/Ingredient")]
public class Ingredient : Item
{
    // [SerializeField] private int m_aqua;
    // [SerializeField] private int m_terra;
    // [SerializeField] private int m_solar;
    // [SerializeField] private int m_ignis;
    // [SerializeField] private int m_aer;
    // private Dictionary<string, int> m_elements;

    [SerializeField] private Material m_material;
    [SerializeField] private List<Element> m_elements;
    public List<Element> elements => m_elements;
    public Material material => m_material;

    private string m_elementString = "";

    // public Dictionary<string, int> elements => this.m_elements;

    private void OnEnable()
    {
        if (m_elementString == "")
        {
            foreach (Element element in m_elements)
            {
                m_elementString += $"{element.elementName}: {element.value}";
            }
        }
    }
    
    public string ElementsToString()
    {
        return m_elementString;
    }
}
