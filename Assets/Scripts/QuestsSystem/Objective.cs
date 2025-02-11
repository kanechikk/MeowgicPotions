using System;
using UnityEngine;

public class Objective
{
    public Action OnComplete;
    public Action OnValueChange;
    public Item Item { get; }
    public bool IsComplete { get; private set; }
    public int MaxValue { get; }
    public int CurrentValue { get; private set; }
    public bool Done = false;
    public string QuestName;
    public string QuestDecsription;
    public bool IsMain;

    private readonly string _statusText;
    public Objective(Item item, string statusText, int maxValue, string questName, string questDescription, bool main)
    {
        Item = item;
        _statusText = statusText;
        MaxValue = maxValue;
        QuestName = questName;
        QuestDecsription = questDescription;
        IsMain = main;
    }

    private void CheckCompletion()
    {
        if (CurrentValue >= MaxValue)
        {
            IsComplete = true;
            OnComplete?.Invoke();
            Done = true;
            Debug.Log($"{Item.name} done");
        }
    }

    public void AddProgress(int value)
    {
        if (IsComplete)
        {
            return;
        }
        CurrentValue += value;
        if (CurrentValue > MaxValue)
        {
            CurrentValue = MaxValue;
        }
        OnValueChange?.Invoke();
        CheckCompletion();
    }

    public string GetStatusText()
    {
        return string.Format(_statusText, CurrentValue, MaxValue);
    }
}
