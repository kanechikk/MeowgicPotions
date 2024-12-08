using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Scriptable Objects/Ingredient")]
public class Ingredient : Item
{
    List<ElementType> elementsHaving = new List<ElementType>();
}
