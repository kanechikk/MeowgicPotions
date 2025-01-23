using UnityEngine;

public class SleepState : GameStateBehaviour
{
    [SerializeField] private DayTimeManager dayTimeManager;
    [SerializeField] private GameMode m_gameMode;

    private void OnEnable()
    {
        dayTimeManager.DayAdd();
        m_gameMode.Back();
    }
}
