using System;
using UnityEngine;

public class CounterActivate : MonoBehaviour
{
    private Collider m_collider;
    private Interactable m_inter;
    [SerializeField] private AgentController m_agentController;

    public void Start()
    {
        m_collider = gameObject.GetComponent<Collider>();
        m_inter = gameObject.GetComponent<Interactable>();
        m_agentController.onReachSpot += OnAgentStop;
        m_agentController.onLeave += OnAgentGo;
    }

    private void OnAgentGo()
    {
        m_collider.enabled = false;
        m_inter.enabled = false;
    }

    private void OnAgentStop()
    {
        m_collider.enabled = true;
        m_inter.enabled = true;
    }
}
