using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject button1, button2, button3;
    public GameObject text1;
    public GameObject menuPanel,introPanel;
    public float appearTime;
    private float timer;
    private bool timerComplete;
    private AudioSource _audio;


    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        timer = appearTime + Time.time;
    }
    private void Update()
    {
        if (timer < Time.time&& !timerComplete)
        {
            button1.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(true);
        }
        if (timer + appearTime<Time.time)
        {
            text1.SetActive(true);

        }
    }
    public void PlayGame()
    {
        _audio.Play(0);
        introPanel.SetActive(true);
        menuPanel.SetActive(false);
    }
    
    public void ExitGame()
    {
        _audio.Play(0);
        Debug.Log("Quit");
        Application.Quit();
    }
}
