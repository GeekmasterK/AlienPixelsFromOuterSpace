using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenControl : MonoBehaviour {

    public GameObject titleScreenUI;
    public GameObject howToPlayUIPage1;
    public string firstLevel;

    public void StartGame()
    {
        GameControl.control.level = 1f;
        SceneManager.LoadScene(firstLevel, LoadSceneMode.Single);
    }

    public void ShowHowToPlay()
    {
        titleScreenUI.SetActive(false);
        howToPlayUIPage1.SetActive(true);
    }

    public void ShowTitle()
    {
        howToPlayUIPage1.SetActive(false);
        titleScreenUI.SetActive(true);
    }
}
