using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private GameObject questsListPanel;
    private List<GameObject> questsList = new List<GameObject>();
    [SerializeField] private GameObject questLinePrefab;
    private QuestLineUI questLineUI;
    [SerializeField] private TextMeshProUGUI questsNameUI;
    [SerializeField] private TextMeshProUGUI questBodyUI;
    [SerializeField] private Image item;
    [SerializeField] private Sprite sampleImage;
    [SerializeField] private Button finishButton;

    public void FillQuestList(List<Objective> quests)
    {
        for (int i = 0; i < quests.Count; i++)
        {
            GameObject line = Instantiate(questLinePrefab, questsListPanel.transform);

            questsList.Add(line);

            questLineUI = line.GetComponent<QuestLineUI>();
            questLineUI.FillLine(quests[i].QuestName);

            Button button = line.GetComponent<Button>();
            SetListenerToButton(button, quests[i]);

            finishButton.interactable = false;
        }
    }

    private void OnDisable()
    {
        EraseQuestsList();
    }

    private void SetListenerToButton(Button button, Objective quest)
    {
        button.onClick.AddListener(() => FillQuestInfo(quest));
    }

    public void FillQuestInfo(Objective quest)
    {
        questsNameUI.text = quest.QuestName;
        questBodyUI.text = quest.QuestDecsription + "\n" + quest.GetStatusText();
        item.sprite = quest.Item.icon;
        if (quest.IsComplete)
        {
            finishButton.interactable = true;
        }
    }

    public void EraseQuestsList()
    {
        foreach (GameObject line in questsList)
        {
            Destroy(line);
        }
        questsNameUI.text = "Quest Name";
        questBodyUI.text = "To Do:";
        item.sprite = sampleImage;
        finishButton.interactable = false;
    }
}
