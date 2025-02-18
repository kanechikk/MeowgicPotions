using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestsData
{
    public ObjectiveManager objectives;

    public QuestsData(ObjectiveManager objectives)
    {
        this.objectives = objectives;
    }

    public string ToJson()
    {
        SaveData saveData = new SaveData();

        foreach (Objective quest in objectives.Objectives)
        {
            saveData.quests.Add(new QuestToSerialize(quest.Id, quest.CurrentValue));
        }

        return JsonUtility.ToJson(saveData);
    }

    public void FromJson(string json, List<QuestInfo> quests)
    {
        QuestInfo newQuest;
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);
        if (saveData != null)
        {
            foreach (QuestToSerialize quest in saveData.quests)
            {
                newQuest = quests.Find(x => x.Id == quest.id);
                objectives.AddObjective(new Objective(newQuest.Item, newQuest.StatusText, newQuest.MaxValue,
                newQuest.QuestName, newQuest.QuestDecsription, newQuest.Main, newQuest.Id, quest.currentValue));
            }
        }
    }

    [System.Serializable]
    private class SaveData
    {
        public List<QuestToSerialize> quests = new List<QuestToSerialize>();
    }
}

[System.Serializable]
public class QuestToSerialize
{
    public int id;
    public int currentValue;

    public QuestToSerialize()
    {

    }

    public QuestToSerialize(int id, int currentValue)
    {
        this.id = id;
        this.currentValue = currentValue;
    }
}
