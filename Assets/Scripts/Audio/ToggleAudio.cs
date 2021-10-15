using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAudio : MonoBehaviour
{
    [SerializeField] private bool _toggleEffects, _toggleMusic;

    public void Toggle()
    {
        if (_toggleEffects) AudioManager.Instance.ToggleEffects();
        if (_toggleMusic) AudioManager.Instance.ToogleMusic();
    }
}
