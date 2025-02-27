using System;
using TMPro;
using UnityEngine;

public class UIDayTimeChange : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_hourText;
    [SerializeField] private TextMeshProUGUI m_minutesText;
    [SerializeField] private TextMeshProUGUI m_dayText;
    [SerializeField] private DayTimeManager m_dayTimeManager;

    private void OnEnable()
    {
        m_dayTimeManager.onDayTimeChange += OnTimeChange;
        m_dayTimeManager.onDayChange += OnDayChange;
    }

    public void NewGame()
    {
        m_dayText.text = "1";
    }

    private void OnDayChange(DayTime time)
    {
        m_dayText.text = $"Day: {time.TotalNumDays}";
        m_hourText.text = "8";
        m_minutesText.text = "00";
    }

    private void OnTimeChange(DayTime time)
    {
        m_hourText.text = time.Hour.ToString();
        if (time.Minute == 0)
        {
            m_minutesText.text = "00";
        }
        else
        {
            m_minutesText.text = time.Minute.ToString();
        }
    }

}
