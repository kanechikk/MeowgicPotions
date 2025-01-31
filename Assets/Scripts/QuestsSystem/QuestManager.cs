using System;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private ObjectiveManager m_objectiveManager = new ObjectiveManager();
    [SerializeField] private AgentController m_agentController;
    [SerializeField] private Transform[] m_destinationPoints;

    private void Start()
    {
        m_objectiveManager.OnObjectiveAdded += OnObjectiveAdded;
    }

    private void OnObjectiveAdded(Objective objective)
    {
        m_agentController.GoToDestination(m_destinationPoints[1].position);
    }

    public void GoToDesk()
    {
        m_agentController.GoToDestination(m_destinationPoints[0].position);
    }
}
