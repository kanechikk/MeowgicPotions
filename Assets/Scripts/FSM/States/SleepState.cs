using UnityEngine;

public class SleepState : GameStateBehaviour
{
    [SerializeField] private DayTimeManager dayTimeManager;

    private void OnEnable()
    {
        dayTimeManager.DayAdd();
        gameObject.SetActive(false);
    }
}
