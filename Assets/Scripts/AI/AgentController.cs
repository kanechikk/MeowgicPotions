using System;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent m_navMeshAgent;
    public Action onStopped;
    public Action onGoing;

    public void GoToDestination(Vector3 destinationPoint)
    {
        m_navMeshAgent.SetDestination(destinationPoint);
    }

    private void Update()
    {
        if (m_navMeshAgent.velocity == Vector3.zero)
        {
            onStopped?.Invoke();
        }
        else
        {
            onGoing?.Invoke();
        }
    }
}
