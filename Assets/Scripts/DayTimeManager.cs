using System;
using UnityEngine;

public class DayTimeManager : MonoBehaviour
{
    private int m_dayCount=0;
    public event Action onDateTimeChange; //<- ????

    public void DayAdd()
    {
        m_dayCount++;
        Debug.Log($"day added, current day: {m_dayCount}");
        //here give signal that day changed to whoever subscribed (сигнал для подписавшихся о смене дня)
        onDateTimeChange?.Invoke();
    }

    public void DayResetCounter()
    {
        m_dayCount = 0;
        //signal here too for reset
    }
    public int DayGetCounter()
    {
        return m_dayCount;
    }
}
