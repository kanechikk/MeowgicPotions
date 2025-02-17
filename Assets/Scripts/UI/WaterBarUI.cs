using UnityEngine;
using UnityEngine.UI;

public class WaterBarUI : MonoBehaviour
{
    [SerializeField] private Image m_fill;

    private void Awake()
    {
        m_fill.fillAmount = 0f;   
    }

    public void SetWater(float percent)
    {
        m_fill.fillAmount = percent;
    }
}
