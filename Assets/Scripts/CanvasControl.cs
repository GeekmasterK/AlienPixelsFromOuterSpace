using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasControl : MonoBehaviour {

    public string levelToLoad;
    public GameObject gameOverUI;

    void Update()
    {
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

    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameControl.control.lives = 3f;
        GameControl.control.score = 0f;
        GameControl.control.level = 1f;
        GameControl.control.gameOver = false;
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
    }
}
