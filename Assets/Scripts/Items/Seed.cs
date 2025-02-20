using UnityEngine;

[CreateAssetMenu(fileName = "Seed", menuName = "Scriptable Objects/Seed")]
public class Seed : Item
{
    [SerializeField] private int m_daysToGrow = 1;

	public int daysToGrow => m_daysToGrow;

	public override string ToStringItem()
	{
		return $"Price: {price}, Days to grow: {m_daysToGrow}";
	}
}
