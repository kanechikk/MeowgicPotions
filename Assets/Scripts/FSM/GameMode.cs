using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    private StateActivator m_stateActivator;
    private void Awake()
    {
        m_stateActivator = new StateActivator();
    }

    private void Start()
    {
        var states = GetComponentsInChildren<IGameState>(true);
        foreach (var state in states)
        {
            m_stateActivator.Add(state);
        }

        //m_stateActivator.Add(new PauseState());

        m_stateActivator.Activate<WalkingState>();
    }

    private void OnDestroy()
    {
        m_stateActivator.current.Deactivate();
        m_stateActivator.current.Exit();
    }

    public void Back()
    {
        m_stateActivator.Back();
    }

    public void GoToState(IGameState state)
    {
        if (state is BrewingState)
        {
            GoToBrewing();
        }
        
        if (state is ShoppingState)
        {
            GoToShopping();
        }
        // else if (state is SleepState)
        // {
        //     GoToSleep();
        // }
    }

    public void GoToBrewing()
    {
        m_stateActivator.Push<BrewingState>();
    }

    public void GoToPotionBook()
    {
        m_stateActivator.Push<PotionBookState>();
    }

    public void GoToInventory()
    {
        m_stateActivator.Push<InventoryState>();
    }

    public void GoToShopping()
    {
        m_stateActivator.Push<ShoppingState>();
    }

    public void GoToWalking()
    {
        m_stateActivator.Activate<WalkingState>();
    }

    // public void GoToSleep()
    // {
    //     m_stateActivator.Activate<SleepState>();
    // }
}
