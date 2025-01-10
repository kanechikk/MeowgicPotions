using UnityEngine;

public class DayTimeManager : MonoBehaviour
{
    private int m_dayCount=0;
    //action or event here I guess
    //public static ??event?? ?Action<>??? UnityAction??? OnDateTimeChange; //<- forgor how help

    public void DayAdd()
    {
        m_dayCount++;
        Debug.Log($"day added, current day: {m_dayCount}");
        //here give signal that day changed to whoever subscribed
    }

    public void DayResetCounter()
    {
        m_dayCount = 0;
        //signal here too
    }
    public int DayGetCounter()
    {
        return m_dayCount;
    }
}
