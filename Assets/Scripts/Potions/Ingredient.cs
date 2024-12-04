using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Scriptable Objects/Ingredient")]
public class Ingredient : Item
{
    //следующие переменные обозначают соотношение
    public float aqua;
    public float terra;
    public float solar;
    public float ignis;
    public float aer;
    //------------------------------------
    public string newThing;
}
