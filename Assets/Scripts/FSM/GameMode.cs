using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.Video;

public class GameMode : MonoBehaviour
{
    private StateActivator m_stateActivator;
    public IGameState CurrGameState => m_stateActivator.current;

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

        GoToWalking();
    }

    private void OnDestroy()
    {
        m_stateActivator.current.Deactivate();
        m_stateActivator.current.Exit();
    }

    private void OnEnable()
    {
        GameManager.instance.audioManager.PlayBackgroundMusic(GameManager.instance.audioManager.BackgroundMusic[1]);
    }

    private void OnDisable()
    {
        GameManager.instance.audioManager.PlayBackgroundMusic(GameManager.instance.audioManager.BackgroundMusic[0]);
    }

    public void Back()
    {
        m_stateActivator.Back();
    }

    public void BackWhile()
    {
        m_stateActivator.BackWhile();
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

        if (state is TalkingState)
        {
            GoToTalking();
            return;
        }

        if (state is CheckingQuestsState)
        {
            GoToQuests();
            return;
        }
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

    public void GoToPlanting()
    {
        m_stateActivator.Push<PlantingState>();
    }

    public void GoToSleep()
    {
        m_stateActivator.Push<SleepState>();
    }

    public void GoToRhythmGame()
    {
        m_stateActivator.Push<RhythmGameState>();
    }

    public void GoToWatering()
    {
        m_stateActivator.RunWhile<WateringState>();
    }

    public void GoToTalking()
    {
        m_stateActivator.Push<TalkingState>();
    }

    public void GoToQuests()
    {
        m_stateActivator.Push<CheckingQuestsState>();
    }

    public void GoToPause()
    {
        m_stateActivator.Push<PauseState>();
    }

    public void GoToSettings()
    {
        m_stateActivator.Push<SettingsState>();
    }
}
