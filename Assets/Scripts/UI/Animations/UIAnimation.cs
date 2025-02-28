using UnityEngine;
using DG.Tweening;
using System.Collections;

public class UIAnimation : MonoBehaviour
{
    [SerializeField] private float m_fadeTime = 2f;
    [SerializeField] RectTransform m_sunMoonPanel;
    [SerializeField] RectTransform m_rectTransform;
    [SerializeField] private Ease m_ease;
    private Tween m_tween;

    public Tween PanelFadeIn()
    {
        m_rectTransform.transform.localPosition = new Vector3(0f, -2000f, 0f);
        return m_rectTransform.DOAnchorPos(new Vector2(0f, 0f), m_fadeTime, false).SetEase(m_ease).SetUpdate(true);
    }

    private IEnumerator Sequence(Tween tween)
    {
        yield return tween.WaitForCompletion();
    }
    
    public Tween PanelFadeOut()
    {
        m_rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        return m_rectTransform.DOAnchorPos(new Vector2(0f, -1000f), m_fadeTime, false).SetEase(m_ease).SetUpdate(true);
    }

    private Tween SunMoonExchange()
    {
        return m_sunMoonPanel.DOShapeCircle(new Vector2(0f, 0f), 180f, m_fadeTime);
    }

    private void OnEnable()
    {
        PanelFadeIn();
    }
}
