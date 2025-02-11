using System;
using UnityEngine;

[System.Serializable]
public class Element : ICloneable
{
    public ElementType type;
	public string elementName;
	public int value;

	public Element(ElementType type, string elementName, int value)
	{
		this.type = type;
		this.elementName = elementName;
		this.value = value;
	}

    public object Clone()
    {
        return new Element(type, elementName, value);
    }
}
