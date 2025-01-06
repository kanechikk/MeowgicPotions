using UnityEngine;

public class GamePlayState : MonoBehaviour
{
	public static Inventory inventory;
	private Ingredient[] ingredients;
	private Potion[] potions;
	
	
	private void Awake()
	{
		inventory = new Inventory(32);
		ingredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
		potions = Resources.LoadAll<Potion>("ScriptableObjects/Potions");
	}
	private void Start()
	{
		inventory.AddCoins(1000);
		for (int i = 0; i < 5; i++)
		{
			inventory.AddItem(potions[i]);
		}
		for (int i = 0; i < 8; i++)
		{
			inventory.AddItem(ingredients[i]);
		}
	}
}
