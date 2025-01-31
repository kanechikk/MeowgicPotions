using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent m_navMeshAgent;
    
    public void GoToDestination(Vector3 destinationPoint)
    {
        m_navMeshAgent.SetDestination(destinationPoint);
    }
}
