using UnityEngine;
using UnityEngine.UI;

public class WaterBarUI : MonoBehaviour
{
    [SerializeField] private Slider m_fill;

    public void SetWater(float percent)
    {
        m_fill.value = percent;
    }
}
