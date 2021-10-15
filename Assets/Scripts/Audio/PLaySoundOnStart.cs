using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLaySoundOnStart : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlaySound(_clip);
    }
}
