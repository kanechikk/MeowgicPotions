using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Scriptable Objects/Potion")]
public class Potion : Item
{
    [SerializeField] private List<Element> m_elements;
    public List<Element> elements => m_elements;
    [SerializeField] private string m_description;
    public string description => m_description;
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
