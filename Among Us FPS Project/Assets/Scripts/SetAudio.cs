using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAudio : MonoBehaviour
{
    public AudioSource Music;
    void Start()
    {
        Music.volume = MenuManager.MusicVolume;
    }
}
