using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Scriptable Objects/Ingredient")]
public class Ingredient : ScriptableObject
{
    public string itemName = "Ingredient";
    public float price = 100.0f;
    public Sprite Icon;
    public float aqua = 0.0f;
    public float terra = 0.0f;
    public float solar = 0.0f;
    public float ignis = 0.0f;
    public float aer = 0.0f;
}
