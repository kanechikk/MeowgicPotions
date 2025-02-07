using System;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent m_navMeshAgent;
    [SerializeField] private GameObject m_pathDesck;
    [SerializeField] private GameObject m_agent;
    public Action onReachSpot;
    public Action onLeave;

    public void GoToDestination(Vector3 destinationPoint)
    {
        m_navMeshAgent.SetDestination(destinationPoint);
    }

    private void Update()
    {
        if (Vector3.Distance(m_agent.transform.position, m_pathDesck.transform.position) < 0.1)
        {
            onReachSpot?.Invoke();
        }
        else
        {
            onLeave?.Invoke();
        }
    }
}
