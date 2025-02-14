using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class RhythmController : MonoBehaviour
{
    public event System.Action OnBeatStoneSync;
    public event System.Action OnMusicEnd;
    public float bpm = 120f;
    private float songPosition;
    private float songPositionInBeats;
    private float secPerBeat;
    private float dspSongTime;
    private AudioSource musicSource;
    public BeatSpawner beatSpawner;
    public RhythmCheck rhythmCheck;
    private int beatCount = 0;
    public TextAsset layoutTextFile;
    private List<int> beatArray;
    public float musicDelay = 3f;

    [SerializeField] private RhythmGameController m_rhythmGameController;
    private bool m_isGameOver;

    void OnEnable()
    {
        secPerBeat = 60f / bpm;
        musicSource = GetComponent<AudioSource>();
        dspSongTime = (float)AudioSettings.dspTime;
        beatArray = new List<string>(layoutTextFile.text.Split('\n')).Select(s => int.Parse(s)).ToList();
        musicSource.Play();
        beatSpawner.timeToScroll = musicDelay;
        rhythmCheck.offsetMax = Mathf.Min(rhythmCheck.offsetMax, secPerBeat - 0.02f);

        m_rhythmGameController.onGameEnd += OnGameEnd;
        m_isGameOver = false;
    }
    void OnDisable()
    {
        beatCount = 0;
    }

    void FixedUpdate()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        songPositionInBeats = songPosition / secPerBeat;
        StartCoroutine("BeatSupplier");
        if (!musicSource.isPlaying)
        {
            OnMusicEnd?.Invoke();
        }
    }

    private void OnGameEnd()
    {
        m_isGameOver = true;
        StopCoroutine("BeatSupplier");
    }

    private IEnumerator BeatSupplier()
    {
        if (beatCount < beatArray.Count)
        {
            if (songPositionInBeats > beatArray[beatCount])
            {
                beatCount++;
                beatSpawner.Spawn();
                //Invoke(nameof(rhythmCheck.CheckStart), musicDelay - 0.45f);
                
                yield return new WaitForSeconds(musicDelay - Mathf.Min(rhythmCheck.offsetMax, secPerBeat - 0.02f));
                TempSolutionAAAAA();
                //Invoke(nameof(TempSolutionAAAAA), musicDelay - Mathf.Min(rhythmCheck.offsetMax, secPerBeat - 0.02f));

                //Invoke(nameof(TempSolution), musicDelay - 0.58f);
                
            }
        }
    }

    private void TempSolution()
    {
        OnBeatStoneSync?.Invoke();
    }
    private void TempSolutionAAAAA()
    {
        if (!m_isGameOver)
        {
            rhythmCheck.CheckStart();
        }
    }

}
