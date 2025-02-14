using System.IO;
using UnityEngine;

public class ShopDataProcess
{
    public static string pathFile => Path.Combine(Application.persistentDataPath, "playerSaveData.json");

    public static void SaveShop(ShopData shopData)
    {
        var json = shopData.ToJson();

        File.WriteAllText(pathFile, json);
    }

    public static void LoadShop(ShopData shopData)
    {
        if (File.Exists(pathFile))
        {
            var json = File.ReadAllText(pathFile);

            shopData.FromJson(json);
        }
    }
}
