using UnityEngine;

public class PoppingElementUI : MonoBehaviour
{
    [SerializeField] private UIWinLose m_UIWinLose;
    private RectTransform[] rectTransform; 
    private PoppingUI m_poppingUI;

    private void OnEnable()
    {
        m_poppingUI = new PoppingUI();
        

    }
}
