using System.Collections.Generic;
using UnityEngine;

public class BrewCalculation : MonoBehaviour
{
    private bool m_isChecked = false;
    private bool m_isInProcess = true;
    private int m_brewCount = 0;
    public int BrewCount(List<ElementType> recepie, List<ElementType> ingridientSum)
    {
        while (m_isInProcess)
        {
            foreach (ElementType recepieComponent in recepie)
            {
                m_isChecked = false;
                for (int i = 0; i < ingridientSum.Count - 1;)
                {
                    if (ingridientSum[i] == recepieComponent)
                    {
                        ingridientSum.RemoveAt(i);
                        m_isChecked = true;
                        break;
                    }
                }
                if (!m_isChecked) break;
            }
            m_isInProcess = m_isChecked;
            if (m_isChecked) m_brewCount++;
        }
        return m_brewCount;
    }
    //is this okay code?? sorry me eepy anf dumb

}
