using UnityEngine;

public class WalkingState : GameStateBehaviour
{
	public static Inventory inventory;
	private static Ingredient[] m_ingredients;
	public static Ingredient[] ingredients => m_ingredients;
	private Potion[] m_potions;
	private static Seed[] m_seeds;

	private void Awake()
	{
		inventory = new Inventory(32);
		m_ingredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
		m_potions = Resources.LoadAll<Potion>("ScriptableObjects/Potions");
		m_seeds = Resources.LoadAll<Seed>("ScriptableObjects/Seeds");
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
		for (int i = 0; i < 8; i++)
		{
			inventory.AddItem(m_seeds[i]);
		}

		inventory.AddItem(m_ingredients[1]);
		inventory.AddItem(m_ingredients[1]);
		inventory.AddItem(m_ingredients[1]);
		inventory.AddItem(m_potions[1]);
		inventory.AddItem(m_potions[1]);
		inventory.AddItem(m_potions[1]);
	}
}
