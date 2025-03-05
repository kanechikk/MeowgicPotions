using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Scriptable Objects/Ingredient")]
public class Ingredient : Item
{
    [SerializeField] private Material m_material;
    [SerializeField] private List<Element> m_elements;
    public List<Element> elements => m_elements;
    public Material material => m_material;

    private string m_elementString = "";
    
    public override string ToStringItem()
    {
        if (m_elementString == "")
        {
            foreach (Element element in m_elements)
            {
                m_elementString += $"{element.elementName}: {element.value}\n";
            }
        }
        
        return m_elementString;
    }
}
