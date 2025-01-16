using UnityEngine;

public class SleepState : MonoBehaviour
{
    [SerializeField] private DayTimeManager dayTimeManager;

    private void OnEnable()
    {
        dayTimeManager.DayAdd();
        gameObject.SetActive(false);
    }
}
