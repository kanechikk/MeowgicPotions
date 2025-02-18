using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectiveManager
{
	public Action<Objective> OnObjectiveAdded;
	public Action OnQuestDeleted;
	public List<Objective> Objectives { get; } = new();
	private readonly Dictionary<string, List<Objective>> _objectiveMap = new();
	public void AddObjective(Objective objective)
	{
		Objectives.Add(objective);
		if (!_objectiveMap.ContainsKey(objective.Item.id))
		{
			_objectiveMap.Add(objective.Item.id, new List<Objective>());
		}

		_objectiveMap[objective.Item.id].Add(objective);

		OnObjectiveAdded?.Invoke(objective);
	}

	public void AddProgress(Item item, int value)
	{
		if (!_objectiveMap.ContainsKey(item.id))
			return;
		foreach (var objective in _objectiveMap[item.id])
		{
			objective.AddProgress(value);
		}
	}

	public List<Item> FinishAllQuests()
	{
		List<Item> items = new List<Item>();

		for (int i = 0; i < Objectives.Count; i++)
		{
			if (Objectives[i].IsComplete)
			{
				for (int j = 0; j < Objectives[i].MaxValue; j++)
				{
					items.Add(Objectives[i].Item);
				}
				
				Objectives.Remove(Objectives[i]);
			}
		}
		
		OnQuestDeleted?.Invoke();
		return items;
	}
}
