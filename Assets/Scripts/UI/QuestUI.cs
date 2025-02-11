using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private GameObject questsList;
    [SerializeField] private GameObject questLinePrefab;
    private QuestLineUI questLineUI;
    [SerializeField] private TextMeshProUGUI questsNameUI;
    [SerializeField] private TextMeshProUGUI questBodyUI;
    [SerializeField] private Image item;

    public void FillQuestList(List<Objective> quests)
    {
        for (int i = 0; i < quests.Count; i++)
        {
            GameObject line = Instantiate(questLinePrefab, questsList.transform);
            questLineUI = line.GetComponent<QuestLineUI>();
            questLineUI.FillLine(quests[i].QuestName);

            line.GetComponent<Button>().onClick.AddListener(() => FillQuestInfo(quests[i - 1]));
        }
    }

    public void FillQuestInfo(Objective quest)
    {
        questsNameUI.text = quest.QuestName;
        questBodyUI.text = quest.QuestDecsription;
        item.sprite = quest.Item.icon;
    }
}
