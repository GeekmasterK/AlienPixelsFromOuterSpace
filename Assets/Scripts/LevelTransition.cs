using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour {

    public string levelToLoad;
	
	// Update is called once per frame
	void Update ()
    {
        LoadLevel();
	}

    // Load the next level on completeion of the current level
    void LoadLevel()
    {
        if (GameControl.control.enemies.Length <= 0)
        {
            GameControl.control.level++;
            if (GameControl.control.enemySpeed <= 5f)
            {
                GameControl.control.enemySpeed += 0.25f;
            }
            GameControl.control.canSpawn = true;
            SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
        }
    }
}
