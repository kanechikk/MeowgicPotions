using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SleepState : GameStateBehaviour
{
    [SerializeField] private DayTimeManager dayTimeManager;
    [SerializeField] private GameMode m_gameMode;
    [SerializeField] private DayChangeController m_dayChangeController;
    private Coroutine m_coroutine;

    private void OnEnable()
    {
        m_dayChangeController.onCoroutineStop += OnCoroutineStop;

        dayTimeManager.DayPass();

        m_coroutine = StartCoroutine(m_dayChangeController.SavingInfo());
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
