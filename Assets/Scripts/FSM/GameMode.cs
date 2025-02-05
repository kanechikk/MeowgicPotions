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

        GoToWalking();
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
            return;
        }
        
        if (state is ShoppingState)
        {
            GoToShopping();
            return;
        }
        
        if (state is SleepState)
        {
            GoToSleep();
            return;
        }

        if (state is PlantingState)
        {
            GoToPlanting();
            return;
        }
    }

    public void GoToBrewing()
    {
        m_stateActivator.Push<BrewingState>();
        Time.timeScale = 0;
    }

    public void GoToPotionBook()
    {
        m_stateActivator.Push<PotionBookState>();
        Time.timeScale = 0;
    }

    public void GoToInventory()
    {
        m_stateActivator.Push<InventoryState>();
        Time.timeScale = 0;
    }

    public void GoToShopping()
    {
        m_stateActivator.Push<ShoppingState>();
        Time.timeScale = 0;
    }

    public void GoToWalking()
    {
        m_stateActivator.Activate<WalkingState>();
    }

    public void GoToPlanting()
    {
        m_stateActivator.Push<PlantingState>();
        Time.timeScale = 0;
    }

    public void GoToSleep()
    {
        m_stateActivator.Push<SleepState>();
        Time.timeScale = 0;
    }

    public void GoToRhythmGame()
    {
        m_stateActivator.Push<RhythmGameState>();
        Time.timeScale = 0;
    }

    public void GoToWatering()
    {
        m_stateActivator.RunWhile<WateringState>();
        Time.timeScale = 0;
    }
}
