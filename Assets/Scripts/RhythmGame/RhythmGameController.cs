using System;
using UnityEngine;

public class RhythmGameController : MonoBehaviour
{
    [SerializeField] private RatingSpawner ratingSpawner;
    [SerializeField] private RhythmCheck rhythmCheck;
    [SerializeField] private RhythmController rhythmController;
    private float m_timer;
    [SerializeField] private int m_score = 0;

    public event Action<int> onGameEnd;
    public event Action<int> onScoreInc;

    public void OnEnable()
    {
        //m_timer = AudioSettings.dspTime - m_delay;
        //stick.onCollisionStick += OnCollisionStick;
        rhythmCheck.onBeatBad += OnBeatBad;
        rhythmCheck.onBeatGood += OnBeatGood;
        rhythmCheck.onBeatMid += OnBeatMid;
        rhythmController.OnMusicEnd += OnMusicEnd;

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
        m_score -= 5;
        Debug.Log($"Bad! score: {m_score}");
        ratingSpawner.Spawn(2);
        onScoreInc?.Invoke(m_score);
    }

    private void OnMusicEnd()
    {
        Debug.Log("GAME END");
        //onGameEnd?.Invoke(m_score);

        rhythmController.gameObject.SetActive(false);
    }
}

