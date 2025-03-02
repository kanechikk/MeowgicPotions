using System;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGameController : MonoBehaviour
{
    [SerializeField] private RatingSpawner ratingSpawner;
    [SerializeField] private RhythmCheck rhythmCheck;
    [SerializeField] private RhythmController rhythmController;
    private float m_timer;
    [SerializeField] private int m_score = 0;
    [SerializeField] private GameMode m_gameMode;
    [SerializeField] private GameObject m_winWindow;
    [SerializeField] private GameObject m_loseWindow;
    private int m_healthPoints;
    [SerializeField] private List<GameObject> m_hpPict;
    //public event Action<int> onGameEnd;
    public event Action<int> onScoreInc;
    [SerializeField] private CanvasGroup m_gamePlayWindow;
    private UIWinLose m_uiWinLose;
    private PoppingUI m_poppingUI;

    public event Action onGameEnd;

    private AudioManager m_audioManager;

    private void Start()
    {
        m_uiWinLose = gameObject.GetComponent<UIWinLose>();

        m_poppingUI = new PoppingUI();
        //m_audioManager = GameManager.instance.audioManager;
    }
    public void OnEnable()
    {
        m_audioManager = GameManager.instance.audioManager;
        m_audioManager.TurnOffBackgroundMusic();

        m_gamePlayWindow.alpha = 1;
        m_gamePlayWindow.gameObject.SetActive(true);
        //m_timer = AudioSettings.dspTime - m_delay;
        //stick.onCollisionStick += OnCollisionStick;
        rhythmCheck.onBeatBad += OnBeatBad;
        rhythmCheck.onBeatGood += OnBeatGood;
        rhythmCheck.onBeatMid += OnBeatMid;
        rhythmController.OnMusicEnd += OnMusicEnd;

        m_healthPoints = 3;

        foreach (var point in m_hpPict)
        {
            point.SetActive(true);
        }

        m_score = 0;
    }

    private void OnDisable()
    {
        // if (stick)
        // {
        //     //stick.onCollisionStick -= OnCollisionStick;
        // }
        if (rhythmCheck)
        {
            rhythmCheck.onBeatBad -= OnBeatBad;
            rhythmCheck.onBeatGood -= OnBeatGood;
            rhythmCheck.onBeatMid -= OnBeatMid;
        }
        if (rhythmController)
        {
            rhythmController.OnMusicEnd -= OnMusicEnd;
        }

        m_loseWindow.SetActive(false);
        m_winWindow.SetActive(false);

        m_audioManager.TurnOnBackgroundMusic();
    }

    private void OnBeatGood()
    {
        m_score += 10;
        Debug.Log($"Good! score: {m_score}");
        ratingSpawner.Spawn(0);
        onScoreInc?.Invoke(m_score);
    }

    private void OnBeatMid()
    {
        m_score += 5;
        Debug.Log($"Eh.. score: {m_score}");
        ratingSpawner.Spawn(1);
        onScoreInc?.Invoke(m_score);
    }

    private void OnBeatBad()
    {
        m_audioManager.PlaySFX(m_audioManager.SFXFailClick);

        m_score -= 5;
        Debug.Log($"Bad! score: {m_score}");
        ratingSpawner.Spawn(2);
        m_healthPoints--;
        
        if (m_healthPoints == 0)
        {
            m_audioManager.PlaySFX(m_audioManager.SFXLosingGame);
            //m_gameMode.Back();
            m_gamePlayWindow.alpha = 0;
            m_loseWindow.SetActive(true);
            m_uiWinLose.ChangeIngredients();
            m_poppingUI.PoppingItems(m_uiWinLose.lossItems.ToArray());
            rhythmController.OnMusicEnd -= OnMusicEnd;
            //m_beatSpawner.SetActive(false);
            //Time.timeScale = 0;
            m_gamePlayWindow.gameObject.SetActive(false);
            onGameEnd?.Invoke();
            return;
        }

        m_hpPict[m_healthPoints - 1].SetActive(false);

        onScoreInc?.Invoke(m_score);
    }

    private void OnMusicEnd()
    {
        m_audioManager.PlaySFX(m_audioManager.SFXWinningGame);
        Debug.Log("GAME END");
        rhythmController.OnMusicEnd -= OnMusicEnd;
        //onGameEnd?.Invoke(m_score);
        //m_gameMode.Back();
        m_gamePlayWindow.alpha = 0;
        m_winWindow.SetActive(true);
        m_uiWinLose.ChangePotion();
        m_poppingUI.PopItem(m_uiWinLose.rewardPotion);
        m_gamePlayWindow.gameObject.SetActive(false);
        //m_beatSpawner.SetActive(false);
        //Time.timeScale = 0;
    }

    public void BackToBrewing()
    {
        m_gameMode.Back();
    }
}

