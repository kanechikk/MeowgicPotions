using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class DataProcess
{
    public static string pathFileForPlayer => Path.Combine(Application.persistentDataPath, "playerSaveData.json");
    public static string pathFileForQuests => Path.Combine(Application.persistentDataPath, "questsSaveData.json");
    public static string pathFileForDayData => Path.Combine(Application.persistentDataPath, "daySaveData.json");

    public static void SavePlayer(PlayerData playerData)
    {
        var json = playerData.ToJson();

        File.WriteAllText(pathFileForPlayer, json);
    }

    public static void LoadPlayer(PlayerData playerData, List<Item> items)
    {
        if (File.Exists(pathFileForPlayer))
        {
            var json = File.ReadAllText(pathFileForPlayer);

            playerData.FromJson(json, items);
        }
    }

    public static void SaveQuests(QuestsData questsData)
    {
        var json = questsData.ToJson();

        File.WriteAllText(pathFileForQuests, json);
    }

    public static void LoadQuests(QuestsData questsData, List<QuestInfo> quests)
    {
        if (File.Exists(pathFileForQuests))
        {
            var json = File.ReadAllText(pathFileForQuests);

            questsData.FromJson(json, quests);
        }
    }

    public static void SaveDay(DayData dayData)
    {
        var json = dayData.ToJson();

        File.WriteAllText(pathFileForDayData, json);
    }

    public static void LoadDay(DayData dayData)
    {
        if (File.Exists(pathFileForDayData))
        {
            var json = File.ReadAllText(pathFileForDayData);

            dayData.FromJson(json);
        }
    }
}
