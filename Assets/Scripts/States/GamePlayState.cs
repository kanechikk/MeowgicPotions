using Mono.Cecil;
using UnityEngine;

public class GamePlayState : MonoBehaviour
{
	public static Inventory inventory;
	private Ingredient[] m_ingredients;
	private Potion[] m_potions;
	private Coins m_coins;

	private void Awake()
	{
		inventory = new Inventory(32);
		m_ingredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
		m_potions = Resources.LoadAll<Potion>("ScriptableObjects/Potions");
		m_coins = Resources.Load<Coins>("ScriptableObjects/Samples/Coins");
	}
	private void Start()
	{
		inventory.AddCoins(1000, m_coins);
		for (int i = 0; i < 5; i++)
		{
			inventory.AddItem(m_potions[i]);
		}
		for (int i = 0; i < 8; i++)
		{
			inventory.AddItem(m_ingredients[i]);
		}

		inventory.AddItem(m_ingredients[1]);
		inventory.AddItem(m_ingredients[1]);
		inventory.AddItem(m_ingredients[1]);

		foreach (var item in inventory.slots)
		{
			if (item.item != null)
			{
				Debug.Log($"{item.item.itemName} : {item.count}");
			}
		}
	}
}
