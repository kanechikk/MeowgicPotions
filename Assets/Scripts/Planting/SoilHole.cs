using UnityEngine;

public class SoilHole : MonoBehaviour
{
    private bool m_isBusy = false;
    public bool isBusy => m_isBusy;

    public void GetBusy(bool busy)
    {
        m_isBusy = busy;
    }
}
