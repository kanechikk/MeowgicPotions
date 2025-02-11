using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class QuestLineUI : MonoBehaviour
{
    private TextMeshProUGUI questName;

    public void FillLine(string gotQuestName)
    {
        questName = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        questName.text = gotQuestName;
    }
}
