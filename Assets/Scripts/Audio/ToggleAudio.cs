using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAudio : MonoBehaviour
{
    [SerializeField] private bool _toggleEffects, _toggleMusic;

    private Image soundOff;
    [SerializeField] private Sprite[]sounds;

    private void Start()
    {
        soundOff = GetComponent<Image>();
    }
    private void Update()
    {

    }
    public void Toggle()
    {
        if (_toggleEffects)
        {
            AudioManager.Instance.ToggleEffects();
            if (AudioManager.changeSound == true)
            {
                soundOff.sprite = sounds[0];
            }
            if (AudioManager.changeSound == false)
            {
                soundOff.sprite = sounds[1];
            }
        }
        if (_toggleMusic)
        {
            AudioManager.Instance.ToogleMusic();
            if (AudioManager.changeSound == true)
            {
                soundOff.sprite = sounds[0];
            }
            if (AudioManager.changeSound == false)
            {
                soundOff.sprite = sounds[1];
            }
        }
    }
}
