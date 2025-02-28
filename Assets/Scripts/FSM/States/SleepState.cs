using System.Collections;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class SleepState : GameStateBehaviour
{
    [SerializeField] private DayTimeManager dayTimeManager;
    [SerializeField] private GameMode m_gameMode;
    [SerializeField] private DayChangeController m_dayChangeController;
    [SerializeField] private UIAnimation m_uiAnimation;

    private void OnEnable()
    {
        m_uiAnimation.onBackFromSleep += OnCoroutineStop;

        dayTimeManager.DayPass();

        StartCoroutine(m_dayChangeController.SavingInfo());
    }

    private void OnCoroutineStop()
    {
        m_gameMode.Back();
    }

    private void OnDisable()
    {
        m_dayChangeController.onCoroutineStop -= OnCoroutineStop;
    }
}
