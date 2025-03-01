using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource m_backgroundMusicSource;
    [SerializeField] private AudioSource m_sfxSource;
    [SerializeField] private AudioSource m_sfxWalking;

    [field: SerializeField] public AudioClip BackgroundMusic { get; private set; }

    //SFX UI
    [field: SerializeField] public AudioClip SFXPoppingElements { get; private set; }
    [field: SerializeField] public AudioClip SFXSliding { get; private set; }
    [field: SerializeField] public AudioClip SFXClickingButtons { get; private set; }
    [field: SerializeField] public AudioClip SFXSunMoonRotation { get; private set; }

    //SFX Brewing
    [field: SerializeField] public AudioClip SFXOpeningBrewing { get; private set; }
    [field: SerializeField] public AudioClip SFXAddingIngredients { get; private set; }

    [field: SerializeField] public AudioClip SFXOpeningBook { get; private set; }
    [field: SerializeField] public AudioClip SFXOpeningBag { get; private set; }

    //SFX Rhythm Game
    [field: SerializeField] public AudioClip SFXFailClick { get; private set; }
    [field: SerializeField] public AudioClip SFXWinningGame { get; private set; }
    [field: SerializeField] public AudioClip SFXLosingGame { get; private set; }

    //SFX Player 
    [field: SerializeField] public AudioClip SFXWalking { get; private set; }
    [field: SerializeField] public AudioClip SFXGettingWater { get; private set; }
    [field: SerializeField] public AudioClip SFXWateringPlants { get; private set; }

    [field: SerializeField] public AudioClip SFXTalkingNpc { get; private set; }
    [field: SerializeField] public AudioClip SFXFinishingQuest { get; private set; }

    [field: SerializeField] public AudioClip SFXCoins { get; private set; }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        m_backgroundMusicSource.clip = BackgroundMusic;
        m_backgroundMusicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        m_sfxSource.PlayOneShot(clip);
    }

    public void PlaySFXWalking(bool isMute)
    {
        m_sfxWalking.mute = isMute;
    }
}

