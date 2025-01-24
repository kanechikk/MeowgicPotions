
using System.Diagnostics;

public class WateringPot
{
    private int m_maxValue;
    private int m_currentValue;
    public int currentValue => m_currentValue;

    public WateringPot(int maxValue)
    {
        m_maxValue = maxValue;
        m_currentValue = 0;
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
