using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private int mainQuestProgress;
    public static QuestsDB questsDB;
    private ObjectiveManager m_objectiveManager = new ObjectiveManager();
    private QuestInfo m_questHolder;
    private List<Item> m_itemTypesNeeded = new List<Item>();
    [SerializeField] private AgentController m_agentController;
    [SerializeField] private Transform[] m_destinationPoints;
    [SerializeField] private DayTimeManager m_dayTimeManager;
    public TalkingUI talkingUI;
    public TalkingState talkingState;
    public QuestUI questUI;
    public CheckingQuestsState checkingQuestsState;
    private QuestsData questsData;

    private void Awake()
    {
        QuestInfo[] mainQuests = Resources.LoadAll<QuestInfo>("ScriptableObjects/Quests/Main");
        QuestInfo[] secondaryQuests = Resources.LoadAll<QuestInfo>("ScriptableObjects/Quests/Second");

        questsDB = new QuestsDB(mainQuests, secondaryQuests);
        questsData = new QuestsData(m_objectiveManager);
        LoadQuests();
    }

    private void FindMainQuestID()
    {
        if (questsData.objectives.Objectives.Count > 0)
        {
            foreach (Objective objective in questsData.objectives.Objectives)
            {
                if (objective.IsMain)
                {
                    mainQuestProgress = objective.Id;
                    break;
                }
            }
        }
    }

    private void LoadQuests()
    {
        List<QuestInfo> quests = new List<QuestInfo>();
        quests.AddRange(questsDB.mainQuests);
        quests.AddRange(questsDB.secondaryQuests);
        DataProcess.LoadQuests(questsData, quests);
        FindMainQuestID();
    }

    private void Start()
    {
        GameManager.instance.player.inventory.onInvChange += OnInventoryChange;
        m_dayTimeManager.onDayChange += OnDayChange;
        m_dayTimeManager.onDayEnd += OnDayEnd;

        talkingState.onActivated += OnTalkingStateActive;
        checkingQuestsState.onActivated += OnQuestStateActive;
    }

    private void OnQuestStateActive()
    {
        questUI.FillQuestList(m_objectiveManager.Objectives);
    }

    private void OnTalkingStateActive()
    {
        if (m_questHolder != null)
        {
            talkingUI.FillQuestInfo(m_questHolder);
        }
    }

    public void OnInventoryChange(Item item)
    {
        foreach (Objective quest in m_objectiveManager.Objectives)
        {
            if (quest.Item.id == item.id)
            {
                m_objectiveManager.AddProgress(item, 1);
            }
        }
    }

    public void OnDayChange(DayTime time)
    {
        bool gotMain = false;
        if (m_dayTimeManager.dayTime.TotalNumDays % 2 == 0)
        {
            GoToCounter();
            foreach (QuestInfo quest in questsDB.mainQuests)
            {
                if (quest.Id == mainQuestProgress)
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

    public void SaveQuestInfo()
    {
        DataProcess.SaveQuests(questsData);
    }

    private void OnDayEnd()
    {
        GoHome();
    }

    public void Refuse()
    {
        GoHome();
    }

    public void Accept()
    {
        m_objectiveManager.AddObjective(new Objective(m_questHolder.Item, m_questHolder.StatusText, m_questHolder.MaxValue,
        m_questHolder.QuestName, m_questHolder.QuestDecsription, m_questHolder.Main, m_questHolder.Id, 0));
        m_itemTypesNeeded.Add(m_questHolder.Item);

        int hasSuch = CheckIfHasItem(m_questHolder.Item);

        if (hasSuch >= m_questHolder.MaxValue)
        {
            m_objectiveManager.AddProgress(m_questHolder.Item, m_questHolder.MaxValue);
        }
        else
        {
            m_objectiveManager.AddProgress(m_questHolder.Item, hasSuch);
        }
        
        if (m_questHolder.Main)
        {
            mainQuestProgress++;
        }

        GoHome();
    }

    private int CheckIfHasItem(Item itemToFind)
    {
        foreach (InventorySlot itemSlot in GameManager.instance.player.inventory.slots)
        {
            if (itemSlot.category != ItemCategory.Nothing)
            {
                if (itemSlot.item.id == itemToFind.id)
                {
                    return itemSlot.count;
                }
            }
        }
        return 0;
    }

    private void GoToCounter()
    {
        m_agentController.GoToDestination(m_destinationPoints[0].position);
    }

    private void GoHome()
    {
        m_agentController.GoToDestination(m_destinationPoints[1].position);
    }

    public void FinishQuests()
    {
        List<Item> itemsErase = m_objectiveManager.FinishAllQuests();
        int sum = 0;
        foreach (Item item in itemsErase)
        {
            sum += item.price * 2;
            GameManager.instance.player.inventory.RemoveItem(item);
        }
        GameManager.instance.player.inventory.AddCoins(sum);
        questUI.EraseQuestsList();
        questUI.FillQuestList(m_objectiveManager.Objectives);
    }
}
