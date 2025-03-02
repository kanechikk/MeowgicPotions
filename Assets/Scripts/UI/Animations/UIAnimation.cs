using UnityEngine;
using DG.Tweening;
using System.Collections;
using System;

public class UIAnimation : MonoBehaviour
{
    //for rotation
    [SerializeField] private RectTransform m_sunMoonPanel;
    [SerializeField] private RotateMode m_rotateMode;
    //for moving
    [SerializeField] private RectTransform m_transitionScreen;
    //general
    [SerializeField] private float m_fadeTime;
    [SerializeField] private Ease m_ease;
    private UIMoving m_uiMoving;
    private UIRotation m_uiRotation;

    private AudioManager m_audioManager;

    public Action onBackFromSleep;
    private void OnEnable()
    {
        m_audioManager = GameManager.instance.audioManager;

        m_sunMoonPanel.localRotation = Quaternion.Euler(0f, 0f, 0f);

        m_uiMoving = new UIMoving();
        m_uiRotation = new UIRotation();

        StartCoroutine(TransitionScreen());
    }

    private IEnumerator TransitionScreen()
    {
        m_audioManager.PlaySFX(m_audioManager.SFXSlidingIn);
        yield return m_uiMoving.Move(m_fadeTime, m_transitionScreen, m_ease, new Vector2(0f, 0f), new Vector3(0f, -1000f, 0f));
        m_audioManager.PlaySFX(m_audioManager.SFXSunMoonRotation);
        yield return m_uiRotation.Rotate(m_sunMoonPanel, new Vector3(0f, 0f, 180f), m_rotateMode, 2f, m_ease);
        m_audioManager.PlaySFX(m_audioManager.SFXSlidingIn);
        yield return m_uiMoving.Move(m_fadeTime, m_transitionScreen, m_ease, new Vector2(0f, -1000f), new Vector3(0f, 0f, 0f));

        onBackFromSleep?.Invoke();
    }
}
