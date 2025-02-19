
using System.Diagnostics;

public class WateringPot
{
    private int m_maxValue;
    private int m_currentValue;
    public int currentValue => m_currentValue;
    public int maxValue => m_maxValue;

    public WateringPot(int maxValue)
    {
        m_maxValue = maxValue;
        m_currentValue = maxValue;
    }

    public void SetNeededAmount(int amount)
    {
        m_currentValue = amount;
    }

    public void FillPot()
    {
        m_currentValue = m_maxValue;
    }

    public void UsePot()
    {
        m_currentValue--;
    }
}
