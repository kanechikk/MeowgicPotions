using Unity.VisualScripting;
using UnityEngine;

public class QuestsDB
{
    private QuestInfo[] m_mainQuests;
    private QuestInfo[] m_secondaryQuests;

    public QuestInfo[] mainQuests => this.m_mainQuests;
    public QuestInfo[] secondaryQuests => this.m_secondaryQuests;

    public QuestsDB(QuestInfo[] newMainQuests, QuestInfo[] newSecondaryQuests)
    {
        m_mainQuests = newMainQuests;
        m_secondaryQuests = newSecondaryQuests;
    }
}
