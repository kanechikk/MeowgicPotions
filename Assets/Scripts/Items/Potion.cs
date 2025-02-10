using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Scriptable Objects/Potion")]
public class Potion : Item
{
    // [SerializeField] private int m_aqua;
    // [SerializeField] private int m_terra;
    // [SerializeField] private int m_solar;
    // [SerializeField] private int m_ignis;
    // [SerializeField] private int m_aer;
    // private Dictionary<string, int> m_elements;

    [SerializeField] private List<Element> m_elements;
    public List<Element> elements => m_elements;
    [SerializeField] private string m_description;
    public string description => m_description;
    private string m_elementString = "";

    // public Dictionary<string, int> elements => this.m_elements;

    private void OnEnable()
    {
        foreach (Element element in m_elements)
        {
            m_elementString += $"{element.elementName}: {element.value}\n";
        }
    }

    public string ElementsToString()
    {
        return m_elementString;
    }
}
