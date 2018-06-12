using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenControl : MonoBehaviour {

    public GameObject titleScreenUI;
    public GameObject howToPlayUIPage1;
    public GameObject howToplayUIPage2;
    public GameObject quitGameUI;
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
        // Turn off all other UI, and turn on the title screen UI
        howToPlayUIPage1.SetActive(false);
        howToplayUIPage2.SetActive(false);
        quitGameUI.SetActive(false);
        titleScreenUI.SetActive(true);
    }

    // Show Quit Game prompt
    public void ShowQuitGame()
    {
        // Turn off all other UI, and turn on the Quit Game prompt
        titleScreenUI.SetActive(false);
        quitGameUI.SetActive(true);
    }

    // Quit the game
    public void QuitGame()
    {
        // Quit the game based on the current build
        #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
            Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        #endif
        #if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;
        #elif (UNITY_STANDALONE)
            Application.Quit();
        #elif (UNITY_WEBGL)
            Application.OpenURL("https://kevintheissgamedev.blogspot.com/");
        #endif
    }
}
