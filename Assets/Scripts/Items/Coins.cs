using UnityEngine;

[CreateAssetMenu(fileName = "Coins", menuName = "Scriptable Objects/Coins")]
public class Coins : Item
{
    public string CoinsToString()
    {
        return $"{itemName}";
    }
}
