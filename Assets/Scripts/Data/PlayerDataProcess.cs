using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerDataProcess
{
    public static string pathFile => Path.Combine(Application.persistentDataPath, "playerSaveData.json");

    public static void SavePlayer(PlayerData playerData)
    {
        var json = playerData.ToJson();

        File.WriteAllText(pathFile, json);
    }

    public static void LoadPlayer(PlayerData playerData, List<Item> items)
    {
        if (File.Exists(pathFile))
        {
            var json = File.ReadAllText(pathFile);

            playerData.FromJson(json, items);
        }
    }
}
