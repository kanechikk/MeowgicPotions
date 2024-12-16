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
        //while in process of counting
        {
            foreach (ElementType recepieComponent in recepie)
            //for each element in recepie
            {
                m_isChecked = false;
                //at the begining of checking recepie element say that it is yet to be confirmed to be part of received
                for (int i = 0; i < ingridientSum.Count - 1;)
                {
                    if (ingridientSum[i] == recepieComponent)
                    //go thru list of all recived checking if we have the needed element
                    {
                        ingridientSum.RemoveAt(i);
                        m_isChecked = true;
                        break;
                        //if true remove the needed element, confirm check, leave loop to get to next element check
                    }
                }
                if (!m_isChecked) break;
                //if the check fails we dont have the needed element, stop the loop
            }
            m_isInProcess = m_isChecked;
            //when stopping from lack of a needed element process stops, otherwise continues
            if (m_isChecked) m_brewCount++;
            //if the check has been successfull add to count
        }
        return m_brewCount;
        //amount of times the recepie can be found in given element amount
    }

}
