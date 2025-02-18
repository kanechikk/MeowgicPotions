using System;
using UnityEngine;

public class DayTimeManager : MonoBehaviour
{
    [SerializeField] private int day = 1;
    [SerializeField] private int hour = 8;
    [SerializeField] private int minute;
    private DayTime m_dayTime;

    public int tickMinutesIncrease = 10;
    public float timeBetweenTicks = 1;
    public float currentTimeBetweenTicks = 0;
    public bool timePass;
    public DayTime dayTime => m_dayTime;

    public Action<DayTime> onDayTimeChange;
    public Action onDayChange;
    public Action onDayEnd;

    private void Awake()
    {
        m_dayTime = new DayTime(day, hour, minute);
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
        if (m_dayTime.Hour == 10)
        {
            Pause();
        }
        //Debug.Log(m_dayTime.Hour);
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
        onDayEnd?.Invoke();
    }

    private void Start()
    {
        timePass = true;
    }
}
