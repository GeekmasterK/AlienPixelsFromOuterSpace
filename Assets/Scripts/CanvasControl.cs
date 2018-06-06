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
        AudioManager.audioManager.Stop("EnemySound");
        AudioManager.audioManager.Stop("UFO");
        gameOverUI.SetActive(true);
    }

    void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0f;
        AudioManager.audioManager.Pause("EnemySound");
        AudioManager.audioManager.Pause("UFO");
        pauseMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        AudioManager.audioManager.UnPause("EnemySound");
        AudioManager.audioManager.UnPause("UFO");
        pauseMenuUI.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameControl.control.lives = 3f;
        GameControl.control.score = 0f;
        GameControl.control.level = 1f;
        GameControl.control.gameOver = false;
        GameControl.control.canSpawn = true;
        AudioManager.audioManager.Stop("EnemySound");
        AudioManager.audioManager.Stop("UFO");
        gameOverUI.SetActive(false);
        if(GameControl.control.barriers.Length > 0)
        {
            foreach(GameObject b in GameControl.control.barriers)
            {
                Destroy(b.gameObject);
            }
        }
        SceneManager.LoadScene(firstLevel, LoadSceneMode.Single);
    }

    public void ReturnToTitle()
    {
        Time.timeScale = 1f;
        GameControl.control.lives = 3f;
        GameControl.control.score = 0f;
        GameControl.control.level = 1f;
        GameControl.control.gameOver = false;
        GameControl.control.canSpawn = true;
        gameOverUI.SetActive(false);
        AudioManager.audioManager.Stop("EnemySound");
        AudioManager.audioManager.Stop("UFO");
        SceneManager.LoadScene(initScene, LoadSceneMode.Single);
    }
}
