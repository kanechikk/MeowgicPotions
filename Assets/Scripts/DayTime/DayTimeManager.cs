using System;
using UnityEngine;

public class DayTimeManager : MonoBehaviour
{
    public int day = 1;
    public int hour; 
    public int minute;
    private DayTime m_dayTime;

    public int tickMinutesIncrease = 10;
    public float timeBetweenTicks = 1;
    public float currentTimeBetweenTicks = 0;
    public bool timePass;

    public Action<DayTime> onDayTimeChange;
    public Action onDayChange;

    private void Awake()
    {
        m_dayTime = new DayTime(day, hour, minute);
    }

    private void Update()
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
        if (m_dayTime.Hour == 23)
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
        onDayChange?.Invoke();
        Start();
    }

    private void Pause()
    {
        timePass = false;
    }

    private void Start()
    {
        timePass = true;
    }
}
