using System;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class GardenData
{
	public Plant[] plants;

	public GardenData(Plant[] plants)
	{
		this.plants = plants;
	}

	public string ToJson()
	{
		SaveData saveData = new SaveData();

		for (int i = 0; i < plants.Length; i++)
		{
			Debug.Log(plants[i].seed);
			if (plants[i].seed)
			{
				saveData.seeds.Add(new SeedsToSeralize(plants[i].seed.id, plants[i].isReadyToHarvest, plants[i].daysAfterPlanting));
			}
		}

		return JsonUtility.ToJson(saveData);
	}

	public void FromJson(string json, List<Seed> seeds)
	{
		SaveData saveData = JsonUtility.FromJson<SaveData>(json);
		if (saveData != null)
		{
			for (int i = 0; i < plants.Length; i++)
			{
				plants[i].SetData(seeds.Find(x => x.id == saveData.seeds[i].id),
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
