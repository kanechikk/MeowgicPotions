using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public struct DayTime
{
    private Day m_currDay;
	private int m_hour;
	private int m_minute;

	private int m_totalNumDays;
	private int m_totalNumWeeks;

	public Day CurrDay => m_currDay;
	public int Hour => m_hour;
	public int Minute => m_minute;

	public int TotalNumDays => m_totalNumDays;
	public int TotalNumWeeks => m_totalNumWeeks;

	public DayTime(int day, int hour, int minute)
	{
		m_currDay = (Day)(day % 7);
		if (m_currDay == 0) m_currDay = (Day)7;
		m_hour = hour;
		m_minute = minute;

		m_totalNumDays = day;
		m_totalNumWeeks = m_totalNumDays / 7;
	}

	public void AdvanceMinutes(int minutesToAdvanceBy)
	{
		if (m_minute + minutesToAdvanceBy >= 60)
		{
			m_minute = (m_minute + minutesToAdvanceBy) % 60;
			AdvanceHour();
		}
		else
		{
			m_minute += minutesToAdvanceBy;
		}
	}

	private void AdvanceHour()
	{
		if ((m_hour + 1) == 24)
		{
			m_hour = 8;
			AdvanceDay();
		}
		else
		{
			m_hour++;
		}
	}

	private void AdvanceDay()
	{
		m_currDay++;
		if (m_currDay > (Day)7)
		{
			m_currDay = (Day)1;
			m_totalNumWeeks++;
		}

		m_totalNumDays++;
	}

	public void DayPass()
	{
		AdvanceDay();
		m_hour = 8;
		m_minute = 0;
	}

	public void SetDay(int day)
	{
		m_hour = 8;
		m_minute = 0;
		m_totalNumDays = day;
	}

	public string DayToString()
	{
		return $"currDay: {m_currDay}, hour: {m_hour}, minute {m_minute}, totalNumDays {m_totalNumDays}, totalNumWeeks {m_totalNumWeeks}";
	}
}
