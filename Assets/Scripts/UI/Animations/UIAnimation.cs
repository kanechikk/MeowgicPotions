using UnityEngine;
using DG.Tweening;

public class UIAnimation : MonoBehaviour
{
    [SerializeField] private float m_fadeTime = 1f;
    [SerializeField] private CanvasGroup m_canvasGroup;
    [SerializeField] RectTransform m_rectTransform;

    public void PanelFadeIn()
    {
        m_rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        m_rectTransform.DOAnchorPos(new Vector2(0f, 0f), m_fadeTime, false).SetEase(Ease.OutElastic);
    }

    public void PanelFadeOut()
    {
        m_rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        m_rectTransform.DOAnchorPos(new Vector2(0f, -1000f), m_fadeTime, false).SetEase(Ease.InOutQuint);
    }
}
