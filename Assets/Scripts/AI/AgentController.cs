using System;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent m_navMeshAgent;
    [SerializeField] private GameObject m_pathDesck;
    [SerializeField] private GameObject m_pathDoor;
    [SerializeField] private GameObject m_agent;
    [SerializeField] private GameObject m_mark;
    public Action onReachSpot;
    public Action onLeave;

    public void GoToDestination(Vector3 destinationPoint)
    {
        m_navMeshAgent.SetDestination(destinationPoint);
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(m_agent.transform.position, m_pathDesck.transform.position) < 0.3)
        {
            onReachSpot?.Invoke();
            m_mark.SetActive(true);
        }
        else
        {
            onLeave?.Invoke();
            m_mark.SetActive(false);
        }
        if (Vector3.Distance(m_agent.transform.position, m_pathDoor.transform.position) < 0.3)
        {
            m_agent.transform.rotation = Quaternion.Euler(0, 270, 0);
        }
    }
}
