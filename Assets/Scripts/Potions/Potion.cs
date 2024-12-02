using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Scriptable Objects/Potion")]
public class Potion : ScriptableObject
{
    public string itemName = "Potion";
    public float price = 100.0f;
    public Sprite icon;
    //------------------------------------
    //следующие переменные обозначают соотношение
    public float aqua = 0.0f;
    public float terra = 0.0f;
    public float solar = 0.0f;
    public float ignis = 0.0f;
    public float aer = 0.0f;
    //------------------------------------

}
