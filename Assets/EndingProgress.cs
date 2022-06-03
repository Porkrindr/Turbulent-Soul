using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingProgress : MonoBehaviour
{
    public GameObject[] panel;
    private int panelNum=0;
    public float panelTime;
    private float timer;
    public bool isIntro;
    private AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
        panelNum = 0;
        _audio = GetComponent<AudioSource>();
        timer = panelTime + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (panelNum < panel.Length-1)
        {
            if (timer < Time.time || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                _audio.Play(0);
                panel[panelNum].SetActive(false);
                panelNum++;
                panel[panelNum].SetActive(true);
                timer = panelTime + Time.time;
            }
        }
        else if((timer<Time.time || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Mouse0)) && !isIntro)
        {
            _audio.Play(0);
            SceneManager.LoadScene(0);

        } else if((timer<Time.time || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Mouse0)) && isIntro)
        {
            _audio.Play(0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
