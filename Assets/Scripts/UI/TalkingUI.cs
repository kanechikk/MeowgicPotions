using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TalkingUI : MonoBehaviour
{
    public Image itemToShow;
    public TextMeshProUGUI questName;
    public TextMeshProUGUI questDesciption;
    public GameObject refuseButton;

    public void FillQuestInfo(QuestInfo questInfo)
    {
        itemToShow.sprite = questInfo.Item.icon;
        questName.text = questInfo.QuestName;
        questDesciption.text = questInfo.QuestDecsription;

        if (questInfo.Main)
        {
            refuseButton.SetActive(false);
        }
        else
        {
            refuseButton.SetActive(true);
        }
    }
}
