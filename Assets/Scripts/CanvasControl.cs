using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasControl : MonoBehaviour {

    public string firstLevel;
    public string initScene;
    public GameObject hudUI;
    public GameObject gameOverUI;
    public GameObject pauseMenuUI;
    public bool gamePaused;

    void Update()
    {
        if(Input.GetButtonDown("Pause") && !gamePaused && GameControl.control.levelStarted)
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
        GameControl.control.canSpawn = false;
        Time.timeScale = 0f;
        AudioManager.audioManager.Stop("EnemySound");
        AudioManager.audioManager.Stop("UFO");
        gameOverUI.SetActive(true);
        hudUI.SetActive(false);
        if(GameControl.control.enemies.Length > 0)
        {
            foreach(GameObject e in GameControl.control.enemies)
            {
                e.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if (GameControl.control.barriers.Length > 0)
        {
            foreach (GameObject b in GameControl.control.barriers)
            {
                Destroy(b.gameObject);
            }
        }
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
        GameControl.control.lives = 3f;
        GameControl.control.score = 0f;
        GameControl.control.level = 1f;
        GameControl.control.gameOver = false;
        GameControl.control.enemyCanShoot = true;
        GameControl.control.canSpawn = true;
        GameControl.control.playerDead = false;
        GameControl.control.scoreForExtraLife = 2000f;
        Time.timeScale = 1f;
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(firstLevel, LoadSceneMode.Single);
    }

    public void ReturnToTitle()
    {
        if (GameControl.control.barriers.Length > 0)
        {
            foreach (GameObject b in GameControl.control.barriers)
            {
                Destroy(b.gameObject);
            }
        }
        if (GameControl.control.enemies.Length > 0)
        {
            foreach (GameObject e in GameControl.control.enemies)
            {
                e.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        hudUI.SetActive(false);
        GameControl.control.lives = 3f;
        GameControl.control.score = 0f;
        GameControl.control.gameOver = false;
        GameControl.control.canSpawn = true;
        GameControl.control.enemyCanShoot = true;
        GameControl.control.playerDead = false;
        gameOverUI.SetActive(false);
        GameControl.control.scoreForExtraLife = 2000f;
        Time.timeScale = 1f;
        SceneManager.LoadScene(initScene, LoadSceneMode.Single);
    }
}
