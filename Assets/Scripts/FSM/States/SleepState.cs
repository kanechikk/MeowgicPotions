using UnityEngine;

public class SleepState : GameStateBehaviour
{
    [SerializeField] private DayTimeManager dayTimeManager;
    [SerializeField] private GameMode m_gameMode;

    private void OnEnable()
    {
        dayTimeManager.DayPass();
        m_gameMode.Back();
    }
}
