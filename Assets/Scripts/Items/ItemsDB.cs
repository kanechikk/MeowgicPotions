using System;
using UnityEngine;

public class ItemsDB
{
	private Ingredient[] m_ingredients;
	private Potion[] m_potions;
	private Seed[] m_seeds;

	public Ingredient[] ingredients => m_ingredients;
	public Potion[] potions => m_potions;
	public Seed[] seeds => m_seeds;

	public ItemsDB(Ingredient[] newIngredients, Potion[] newPotions, Seed[] newSeeds)
	{
		m_ingredients = newIngredients;
		m_potions = newPotions;
		m_seeds = newSeeds;
	}
}
