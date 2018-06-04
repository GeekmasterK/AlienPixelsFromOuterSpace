using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasControl : MonoBehaviour {

    public string firstLevel;
    public string initScene;
    public GameObject gameOverUI;
    public GameObject pauseMenuUI;
    public bool gamePaused;

    void Update()
    {
        if(Input.GetButtonDown("Pause") && !gamePaused)
        {
            PauseGame();
        }

        else if(Input.GetButtonDown("Pause") && gamePaused)
        {
            ResumeGame();
        }

        if(GameControl.control.gameOver)
        {
            ShowGameOver();
        }
    }

    void ShowGameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }

    void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameControl.control.lives = 3f;
        GameControl.control.score = 0f;
        GameControl.control.level = 1f;
        GameControl.control.gameOver = false;
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(firstLevel, LoadSceneMode.Single);
    }

    public void ReturnToTitle()
    {
        Time.timeScale = 1f;
        GameControl.control.lives = 3f;
        GameControl.control.score = 0f;
        GameControl.control.level = 1f;
        GameControl.control.gameOver = false;
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(initScene, LoadSceneMode.Single);
    }
}
