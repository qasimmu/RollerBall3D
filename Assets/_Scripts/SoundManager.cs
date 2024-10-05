﻿
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [Header("Audio Clips")]
    public AudioClip mainMenuSound;
    public AudioClip  gamePlaySound, buttonClick,levelPause, levelFailed, levelComplete;
    [Header("Audio Sources")]
    [SerializeField]
    internal AudioSource musicSource;
    [SerializeField]
    private AudioSource sfxSource, levelFail_CompleteSource;

    public static SoundManager _SoundManager;

    void Awake()
    {
        if (_SoundManager == null)
        {
            _SoundManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        verifyAudioSources();
    }

    public void sfxVolume()
    {
    }

    public void changeVolume()
    {
    }


    void verifyAudioSources()
    {
        musicSource.playOnAwake = false;
        musicSource.loop = true;

        sfxSource.playOnAwake = false;
        sfxSource.loop = false;

        levelFail_CompleteSource.playOnAwake = false;
        levelFail_CompleteSource.loop = false;
    }

    public void playMainMenuSounds()
    {
        musicSource.clip = mainMenuSound;
        musicSource.Play();
    }

    public void playMainMenuSounds(float temp)
    {
        musicSource.clip = mainMenuSound;
        musicSource.Play();
        musicSource.volume = temp;
    }

    public void playGameplaySounds()
    {
        musicSource.clip = gamePlaySound;
        musicSource.Play();
        musicSource.volume = 0.1f;
    }

    public void playGameplaySounds(float temp)
    {
        musicSource.clip = gamePlaySound;
        musicSource.Play();
        musicSource.volume = temp;
    }
    public void StopGameplaySounds()
    {
        musicSource.clip = null;
        musicSource.Stop();
    }

    public void playPauseSounds(float temp)
    {
        musicSource.clip = levelPause;
        musicSource.Play();
        musicSource.volume = temp;
    }

    public void playButtonClickSound()
    {
        sfxSource.clip = buttonClick;
        sfxSource.Play();
    }

    public void playLevelFailedSound()
    {
        levelFail_CompleteSource.clip = levelFailed;
        levelFail_CompleteSource.Play();
    }
    public void playLevelCompleteSound()
    {
        levelFail_CompleteSource.clip = levelComplete;
        levelFail_CompleteSource.Play();
    }
    public void StopLevelFailedSound()
    {
        levelFail_CompleteSource.clip = null;
        levelFail_CompleteSource.Stop();
    }
    public void StopLevelCompleteSound()
    {
        levelFail_CompleteSource.clip = null;
        levelFail_CompleteSource.Stop();
    }
}
