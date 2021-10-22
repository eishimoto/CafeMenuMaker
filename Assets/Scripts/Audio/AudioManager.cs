using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource _musicSource, _effectsSource;

    public static bool changeSound;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void ToggleEffects()
    {
        _effectsSource.mute = !_effectsSource.mute;

        if(_effectsSource.mute)
        {
            changeSound = true;
        }
        else
        {
            changeSound = false;
        }
    }

    public void ToogleMusic()
    {
        _musicSource.mute = !_musicSource.mute;

        if (_musicSource.mute)
        {
            changeSound = true;
        }
        else
        {
            changeSound = false;
        }
    }
}
