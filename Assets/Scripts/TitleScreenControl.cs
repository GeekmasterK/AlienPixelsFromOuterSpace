using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenControl : MonoBehaviour {

    public GameObject titleScreenUI;
    public GameObject howToPlayUIPage1;
    public GameObject howToplayUIPage2;
    public string firstLevel;

    // Start the game
    public void StartGame()
    {
        // Set the level count to 1 and load the first level
        GameControl.control.level = 1f;
        SceneManager.LoadScene(firstLevel, LoadSceneMode.Single);
    }

    // Show the How to Play screen
    public void ShowHowToPlay()
    {
        // Turn off the title screen and second page UI, and turn on the first page UI
        titleScreenUI.SetActive(false);
        howToplayUIPage2.SetActive(false);
        howToPlayUIPage1.SetActive(true);
    }

    // Show the second page of How to Play
    public void ShowHowToPlayPage2()
    {
        // Turn off the title screen and first page UI, and turn on the second page UI
        titleScreenUI.SetActive(false);
        howToPlayUIPage1.SetActive(false);
        howToplayUIPage2.SetActive(true);
    }

    // Show the title menu
    public void ShowTitle()
    {
        // Turn off both pages of the How to Play UI, and turn on the title screen UI
        howToPlayUIPage1.SetActive(false);
        howToplayUIPage2.SetActive(false);
        titleScreenUI.SetActive(true);
    }
}
