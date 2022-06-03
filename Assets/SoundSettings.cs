using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettings : MonoBehaviour
{
    private static readonly string musicPref = "MusicPref";
    private float musicFloat;
    public AudioSource musicSource;
    void Awake()
    {
        ContinueSettings(); 
    }

    private void ContinueSettings()
    {
        musicFloat = PlayerPrefs.GetFloat(musicPref);
        musicSource.volume = musicFloat;
    }
}
