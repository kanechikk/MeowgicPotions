using System;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class GardenData
{
	public PlantsManager plantsManager;

	public GardenData()
	{
		
	}

	public GardenData(PlantsManager plantsManager)
	{
		this.plantsManager = plantsManager;
	}

	public string ToJson()
	{
		SaveData saveData = new SaveData();

		for (int i = 0; i < plantsManager.plants.Length; i++)
		{
			if (plantsManager.plants[i].seed)
			{
				saveData.seeds.Add(new SeedsToSeralize(plantsManager.plants[i].seed.id, plantsManager.plants[i].isReadyToHarvest, plantsManager.plants[i].daysAfterPlanting));
			}
		}

		return JsonUtility.ToJson(saveData);
	}

	public void FromJson(string json, List<Seed> seeds)
	{
		SaveData saveData = JsonUtility.FromJson<SaveData>(json);

		if (saveData != null)
		{
			for (int i = 0; i < saveData.seeds.Count; i++)
			{
				plantsManager.plants[i].gameObject.SetActive(true);
				plantsManager.plants[i].SetData(seeds.Find(x => x.id == saveData.seeds[i].id),
				saveData.seeds[i].daysAfterPlanting, saveData.seeds[i].isReadyToHarvest);
			}
		}
	}

	[System.Serializable]
	private class SaveData
	{
		public List<SeedsToSeralize> seeds = new List<SeedsToSeralize>();
	}
}
[System.Serializable]
public class SeedsToSeralize
{
	public string id;
	public bool isReadyToHarvest;
	public int daysAfterPlanting;

	public SeedsToSeralize(string id, bool isReadyToHarvest, int daysAfterPlanting)
	{
		this.id = id;
		this.isReadyToHarvest = isReadyToHarvest;
		this.daysAfterPlanting = daysAfterPlanting;
	}
}
