using UnityEngine;

public class GamePlayState : MonoBehaviour
{
	public static Inventory inventory;
	public static Ingredient[] allIngredients;
	public static Potion[] allPotions;

	private void Awake()
	{
		inventory = new Inventory(16);
		allIngredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
		allPotions = Resources.LoadAll<Potion>("ScriptableObjects/Potions");
	}
	private void Start()
	{
		inventory.AddItem(allIngredients[0]);
		inventory.AddItem(allPotions[0]);
	}
}
