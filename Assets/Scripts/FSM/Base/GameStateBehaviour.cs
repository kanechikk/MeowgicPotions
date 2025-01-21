using System.Collections.Generic;
using UnityEngine;

public class GameStateBehaviour : MonoBehaviour, IGameState
{
    private List<IController> m_controllers = new List<IController>();

    private void Awake()
    {
        GetComponentsInChildren(m_controllers);
    }

    public void Enter()
    {
        OnEnter();
    }

    public void Exit()
    {
        OnExit();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnEnter()
    {
    }

    protected virtual void OnExit()
    {
    }
}
