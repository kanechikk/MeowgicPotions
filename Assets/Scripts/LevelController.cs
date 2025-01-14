using UnityEngine;

public class LevelController : MonoBehaviour
{
	[SerializeField] DayTimeManager dayTimeManager;
	[SerializeField] Plant m_plant;
	private Inventory m_inventory;
	private Seed[] m_seeds;

	private static Ingredient[] m_ingredients;
	public static Ingredient[] ingredients => m_ingredients;

	public void Start()
	{
		m_inventory = new Inventory(32);
		m_seeds = Resources.LoadAll<Seed>("ScriptableObjects/Seeds");
		m_ingredients = Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients");
	}
	public void ChangeDay()
	{
		dayTimeManager.DayAdd();
	}

	public void PlantSeed()
	{
		m_plant.PlantSeed(m_seeds[0]);
	}
	public void WaterPlant()
	{
		m_plant.WaterPlant();
	}
	public void HarvestPlant()
	{
		Ingredient plant = m_plant.HarvestPlant();

		if(plant != null)
		{
			m_inventory.AddItem(plant);
		}

		foreach (var item in m_inventory.slots)
		{
			Debug.Log(item.item);
		}
	}
}
