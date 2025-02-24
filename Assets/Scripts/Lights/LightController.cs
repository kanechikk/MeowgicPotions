using System;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] DayTimeManager m_dayTimeManager;
    [SerializeField] GameObject m_light;
    private int m_minutes;

    private void Start()
    {
        m_dayTimeManager.onDayTimeChange += OnTimeChange;
        m_minutes = m_dayTimeManager.dayTime.Minute;
    }

    private void OnTimeChange(DayTime time)
    {
        if (time.Minute > m_minutes)
        {
            m_light.transform.Rotate(new Vector3(0, 1.5f, 0));
        }
    }
}
