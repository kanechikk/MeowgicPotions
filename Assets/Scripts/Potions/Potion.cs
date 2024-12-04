using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Scriptable Objects/Potion")]
public class Potion : Item
{
    //следующие переменные обозначают соотношение
    public ElementType element1;
    public ElementType element2;
    public float aqua;
    public float terra;
    public float solar;
    public float ignis;
    public float aer;
    //------------------------------------
    public string newThing;
    public float ratio;
}
