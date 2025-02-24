
using System;
using System.Diagnostics;

public class WateringPot
{
    private int m_maxValue;
    private int m_currentValue;
    public int currentValue => m_currentValue;
    public int maxValue => m_maxValue;
    public event Action onValueChange;

    public WateringPot(int maxValue)
    {
        m_maxValue = maxValue;
        m_currentValue = maxValue;
    }

    public void SetNeededAmount(int amount)
    {
        m_currentValue = amount;
        onValueChange?.Invoke();
    }

    public void FillPot()
    {
        m_currentValue = m_maxValue;
        onValueChange?.Invoke();
    }

    public void UsePot()
    {
        m_currentValue--;
        onValueChange?.Invoke();
    }
}
