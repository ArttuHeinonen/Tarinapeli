﻿using UnityEngine;
using System.Collections;

public class SpaceSoundManager : MonoBehaviour {

    public AudioSource sfxSource;
    public AudioSource musicSource;
    public static SpaceSoundManager Instance = null;

    public AudioClip click;
    public AudioClip boing;
    public AudioClip splat;

    public AudioClip titleMusic;
    public AudioClip birdMusic;
    public AudioClip melonGameMusic;
    public AudioClip underwaterGameMusic;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void StopAllSounds()
    {
        sfxSource.Stop();
        musicSource.Stop();
    }

    public void StopPlayingMusic()
    {
        musicSource.Stop();
    }

    public void StopPlayingSFX()
    {
        sfxSource.Stop();
    }

    public void PlaySingle(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    public void PlayClick()
    {
        sfxSource.clip = click;
        sfxSource.Play();
    }

    public void PlayBoing()
    {
        sfxSource.clip = boing;
        sfxSource.Play();
    }

    public void PlaySplat()
    {
        sfxSource.clip = splat;
        sfxSource.Play();
    }

    public void ChangeSong(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlayTitleMusic()
    {
        musicSource.clip = titleMusic;
        musicSource.Play();
    }

    public void PlayBirdMusic()
    {
        musicSource.clip = birdMusic;
        musicSource.Play();
    }

    public void PlayMelonGameMusic()
    {
        musicSource.clip = melonGameMusic;
        musicSource.Play();
    }

    public void PlayUnderWaterMusic()
    {
        musicSource.clip = underwaterGameMusic;
        musicSource.Play();
    }

    public IEnumerator MuteAllSoundsForLimitedTime(float seconds)
    {
        sfxSource.volume = 0;
        musicSource.volume = 0;
        yield return new WaitForSeconds(seconds);
        sfxSource.volume = 1;
        musicSource.volume = 1;
    }
}