using Mono.Cecil;
using UnityEngine;

public class GamePlayState : MonoBehaviour
{
	public static Inventory inventory;
	private Ingredient[] m_ingredients;
	private Potion[] m_potions;

	private void Awake()
	{
		inventory = new Inventory(32);
		m_ingredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
		m_potions = Resources.LoadAll<Potion>("ScriptableObjects/Potions");
	}
	private void Start()
	{
		inventory.AddCoins(1000);
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
	}
}
