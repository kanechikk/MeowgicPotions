using UnityEngine;

public class GamePlayState : MonoBehaviour
{
	public static Inventory inventory;
	private Ingredient[] ingredients;
	private Potion[] potions;
	
	private void Awake()
	{
		inventory = new Inventory(16);
		ingredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
		potions = Resources.LoadAll<Potion>("ScriptableObjects/Potions");
	}
	private void Start()
	{
		inventory.AddItem(potions[0]);
		inventory.AddItem(potions[1]);
		for (int i = 0; i < 6; i++)
		{
			inventory.AddItem(ingredients[i]);
		}
	}
}
