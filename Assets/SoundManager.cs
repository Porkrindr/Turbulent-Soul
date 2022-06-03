using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private static readonly string firstPlay = "FirstPlay";
    private static readonly string musicPref = "MusicPref";
    private int firstPlayInt;
    public Slider musicSlider;
    private float musicFloat;
    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(firstPlay);
        if (firstPlayInt == 0)
        {
            musicFloat = .5f;
            musicSlider.value = musicFloat;
            PlayerPrefs.SetFloat(musicPref, musicFloat);
            PlayerPrefs.SetInt(firstPlay, -1);
        }
        else
        {
            musicFloat = PlayerPrefs.GetFloat(musicPref);
            musicSlider.value = musicFloat;
        }

    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(musicPref, musicSlider.value);

    }
    private void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }
    public void UpdateSound()
    {
        musicSource.volume = musicSlider.value;
    }
}
