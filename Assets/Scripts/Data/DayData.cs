using UnityEngine;

public class DayData
{
    public DayTimeManager dayTimeManager;

    public DayData(DayTimeManager dayTimeManager)
    {
        this.dayTimeManager = dayTimeManager;
    }

    public string ToJson()
    {
        SaveData saveData = new SaveData();

        saveData.day = dayTimeManager.dayTime.TotalNumDays;

        return JsonUtility.ToJson(saveData);
    }

    public void FromJson(string json)
    {
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);
        if (saveData != null)
        {
            dayTimeManager.SetDay(saveData.day);
        }
    }

    [System.Serializable]
    private class SaveData
    {
        public int day;
    }
}
