using System;
using UnityEngine;

public class DayTimeManager : MonoBehaviour
{
    private int day = 1;
    private int hour = 8;
    private int minute;
    private DayTime m_dayTime;

    public int tickMinutesIncrease = 10;
    public float timeBetweenTicks = 4;
    public float currentTimeBetweenTicks = 0;
    public bool timePass;
    public DayTime dayTime => m_dayTime;

    public Action<DayTime> onDayTimeChange;
    public Action<DayTime> onDayChange;
    public Action onDayEnd;

    private void Awake()
    {
        m_dayTime = new DayTime(day, hour, minute);
        StartTime();
    }

    private void OnEnable()
    {
        onDayChange?.Invoke(m_dayTime);
    }

    private void FixedUpdate()
    {
        if (timePass)
        {
            currentTimeBetweenTicks += Time.deltaTime;

            if (currentTimeBetweenTicks >= timeBetweenTicks)
            {
                currentTimeBetweenTicks = 0;
                Tick();
            }
        }
    }

    private void Tick()
    {
        AdvanceTime();
        if (m_dayTime.Hour == 20)
        {
            Pause();
        }
    }

    private void AdvanceTime()
    {
        m_dayTime.AdvanceMinutes(tickMinutesIncrease);

        onDayTimeChange?.Invoke(m_dayTime);
    }

    public void DayPass()
    {
        m_dayTime.DayPass();
        onDayChange?.Invoke(m_dayTime);
        StartTime();
    }

    public void SetDay(int day)
    {
        this.day = day;
        m_dayTime.SetDay(day);
    }

    private void Pause()
    {
        timePass = false;
        onDayEnd?.Invoke();
    }

    private void StartTime()
    {
        timePass = true;
    }
}
