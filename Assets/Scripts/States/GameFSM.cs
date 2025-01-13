using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameFSM
{
    private IGameState m_currentState;
    private Dictionary<GameStateEnum, IGameState> m_states = new Dictionary<GameStateEnum, IGameState>();

    public GameFSM(GameInstance context)
    {
        
    }

    public void ActivateState(GameStateEnum state)
    {
        Debug.Log($"FSM -> ACTIVATE: {state}");

        if (m_currentState != null)
        {
            m_currentState.Exit();
            m_currentState = null;
        }

        if (m_states.TryGetValue(state, out m_currentState))
        {
            m_currentState.Enter();
        }
    }

    public void Walking()
    {
        m_currentState?.Walking();
    }

    public void Shop()
    {
        m_currentState?.Shop();
    }

    public void PotionBook()
    {
        m_currentState?.PotionBook();
    }

    public void Inventory()
    {
        m_currentState?.Inventory();
    }

    public void Sleep()
    {
        m_currentState?.Sleep();
    }
}
