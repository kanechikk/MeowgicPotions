using UnityEngine;

public class DayTimeManager : MonoBehaviour
{

    private int m_dayCount = 0;
    private int m_currentHour = 0;
    private int m_currentMinutes = 0;
//maybe use a construct to store day-time? would make easier making a calendar thing

    public void DayAdd()
    {
        m_dayCount++;
        Debug.Log("Day advanced");
        //reset time to morning here?
    }

    public int DayGetCount()
    {
        Debug.Log($"Current day: {m_dayCount}");
        return m_dayCount;
    }

    public void DayClear()
    {
        m_dayCount = 0;
    }

    public void TimeTick()
    {
        //advance time by tick
    }
    //more func: TimeGet, TimeConvert, TimeReset, TimeElapsed etc
}
