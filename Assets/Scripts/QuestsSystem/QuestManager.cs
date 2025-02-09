using System;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestsDB questsDB;
    private ObjectiveManager m_objectiveManager = new ObjectiveManager();
    private QuestInfo m_questHolder;
    [SerializeField] private AgentController m_agentController;
    [SerializeField] private Transform[] m_destinationPoints;
    [SerializeField] private DayTimeManager m_dayTimeManager;

    private void Awake()
    {
        QuestInfo[] mainQuests = Resources.LoadAll<QuestInfo>("ScriptableObjects/Quests/Main");
        QuestInfo[] secondaryQuests = Resources.LoadAll<QuestInfo>("ScriptableObjects/Quests/Second");

        questsDB = new QuestsDB(mainQuests, secondaryQuests);
    }

    private void Start()
    {
        m_objectiveManager.OnObjectiveAdded += OnObjectiveAdded;
        m_dayTimeManager.onDayChange += OnDayChange;
        OnDayChange();
    }

    public void OnDayChange()
    {
        bool gotMain = false;
        if (m_dayTimeManager.dayTime.TotalNumDays % 2 != 0)
        {
            foreach (QuestInfo quest in questsDB.mainQuests)
            {
                if (quest.Day == m_dayTimeManager.dayTime.TotalNumDays)
                {
                    m_questHolder = quest;
                    gotMain = true;
                    break;
                }
            }
            if (!gotMain)
            {
                int rand = UnityEngine.Random.Range(0, questsDB.secondaryQuests.Length);
                m_questHolder = questsDB.secondaryQuests[rand];
            }
        }
    }

    private void OnObjectiveAdded(Objective objective)
    {
        m_agentController.GoToDestination(m_destinationPoints[1].position);
    }

    public void GoToDesk()
    {
        m_agentController.GoToDestination(m_destinationPoints[0].position);
    }

    public void Refuse()
    {
        m_agentController.GoToDestination(m_destinationPoints[1].position);
    }

    public void Accept()
    {
        m_objectiveManager.AddObjective(new Objective(m_questHolder.EventTrigger, m_questHolder.StatusText, m_questHolder.MaxValue));
        Debug.Log(m_objectiveManager.Objectives[0].EventTrigger);
    }
}
