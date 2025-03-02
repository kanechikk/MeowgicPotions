using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class DayChangeController : MonoBehaviour
{
    [SerializeField] QuestManager m_questManager;
    [SerializeField] SkyboxController m_skyboxController;
    [SerializeField] LightController m_lightController;
    GameManager m_gameManager;

    private void Start()
    {
        m_gameManager = FindAnyObjectByType<GameManager>();
    }

    public IEnumerator SavingInfo()
    {
        yield return new WaitForSecondsRealtime(1f);

        m_gameManager.SaveData();
        m_questManager.SaveQuestInfo();

        m_skyboxController.ResetSkybox();
        m_lightController.ResetLight();
    }
}
