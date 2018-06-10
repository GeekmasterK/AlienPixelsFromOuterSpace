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
        // Check to see if the level has started, the game is not already paused, and the pause button is pressed
        if(Input.GetButtonDown("Pause") && !gamePaused && GameControl.control.levelStarted)
        {
            // If the above conditions are met, pause the game
            PauseGame();
        }

        // Otherwise, if the game is paused, and the pause button is pressed...
        else if(Input.GetButtonDown("Pause") && gamePaused)
        {
            // Resume the game
            ResumeGame();
        }

        // Check to see if the Game Over condition is met
        if(GameControl.control.gameOver)
        {
            // If the Game Over condition is met, show the Game Over screen
            ShowGameOver();
        }
    }

    // Show the Game Over screen
    void ShowGameOver()
    {
        // Make it so the UFO can't spawn,
        // stop the game's time scale,
        // stop the enemy and UFO sounds,
        // display the Game Over screen,
        // and disable the HUD
        GameControl.control.canSpawn = false;
        Time.timeScale = 0f;
        AudioManager.audioManager.Stop("EnemySound");
        AudioManager.audioManager.Stop("UFO");
        gameOverUI.SetActive(true);
        hudUI.SetActive(false);

        // Check to see if there are any enemies left in the level
        if(GameControl.control.enemies.Length > 0)
        {
            // Loop through all the remaining enemies
            foreach(GameObject e in GameControl.control.enemies)
            {
                // Make each remaining enemy invisible
                e.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        // Check to see if there are any barriers left
        if (GameControl.control.barriers.Length > 0)
        {
            // Loop through all the remaining barriers
            foreach (GameObject b in GameControl.control.barriers)
            {
                // Clear out the barriers
                Destroy(b.gameObject);
            }
        }
    }

    // Pause the game
    void PauseGame()
    {
        // Set the paused flag to true,
        // stop the game's time scale,
        // pause the enemy and UFO sounds,
        // and show the pause menu UI
        gamePaused = true;
        Time.timeScale = 0f;
        AudioManager.audioManager.Pause("EnemySound");
        AudioManager.audioManager.Pause("UFO");
        pauseMenuUI.SetActive(true);
    }

    // Resume the game
    public void ResumeGame()
    {
        // Set the paused flag to false,
        // resume the game's time scale,
        // unpause the enemy and UFO sounds,
        // and disable the pause menu UI
        gamePaused = false;
        Time.timeScale = 1f;
        AudioManager.audioManager.UnPause("EnemySound");
        AudioManager.audioManager.UnPause("UFO");
        pauseMenuUI.SetActive(false);
    }

    // Restart the game
    public void RestartGame()
    {
        // Reset all the global game variables
        GameControl.control.lives = 3f;
        GameControl.control.score = 0f;
        GameControl.control.level = 1f;
        GameControl.control.gameOver = false;
        GameControl.control.enemyCanShoot = true;
        GameControl.control.canSpawn = true;
        GameControl.control.playerDead = false;
        GameControl.control.scoreForExtraLife = 2000f;

        // Resume the game's time scale and disable the Game Over screen
        Time.timeScale = 1f;
        gameOverUI.SetActive(false);

        // Load the first level of the game
        SceneManager.LoadScene(firstLevel, LoadSceneMode.Single);
    }

    // Return to the title screen
    public void ReturnToTitle()
    {
        // Check to see if there are any barriers left
        if (GameControl.control.barriers.Length > 0)
        {
            // Loop through all the remaining barriers
            foreach (GameObject b in GameControl.control.barriers)
            {
                // Clear out the barriers
                Destroy(b.gameObject);
            }
        }

        // Check to see if there are any enemies left in the level
        if (GameControl.control.enemies.Length > 0)
        {
            // Loop through the remaining enemies
            foreach (GameObject e in GameControl.control.enemies)
            {
                // Make each remaining enemy invisible
                e.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        // Disable the HUD
        hudUI.SetActive(false);

        // Reset all global variables
        GameControl.control.lives = 3f;
        GameControl.control.score = 0f;
        GameControl.control.gameOver = false;
        GameControl.control.canSpawn = true;
        GameControl.control.enemyCanShoot = true;
        GameControl.control.playerDead = false;
        GameControl.control.scoreForExtraLife = 2000f;

        // Disable the Game Over screen and resume the game's time scale
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;

        // Load the initialization scene
        SceneManager.LoadScene(initScene, LoadSceneMode.Single);
    }
}
