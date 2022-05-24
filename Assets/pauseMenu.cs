using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool isGameOver = false;
    public GameObject pauseMenuUI;
    public GameObject gameoverMenuUI;
    public static bool levelComplete = false;
    public GameObject levelCompleteMenu;
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (levelComplete)
        {
            Complete();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        levelCompleteMenu.SetActive(false);
        Time.timeScale = 1f;
        playerController.isPlaying = true;
        GameIsPaused = false;
        isGameOver = false;
        levelComplete = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        gameoverMenuUI.SetActive(true);
    }


    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        Resume();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading Menu");
        SceneManager.LoadScene(0);
        isGameOver = false;
        levelComplete = false;
      
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    void Complete()
    {
        levelCompleteMenu.SetActive(true);
        playerController.isPlaying = false;
    }

}
