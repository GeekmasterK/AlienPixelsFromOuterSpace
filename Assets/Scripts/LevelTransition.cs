using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour {

    public string levelToLoad;
	
	// Update is called once per frame
	void Update ()
    {
        // Load the next level on completion of the current level
        LoadLevel();
	}

    // Load the next level on completeion of the current level
    void LoadLevel()
    {
        // Check to see if all enemies have been destroyed in the level
        if (GameControl.control.enemies.Length <= 0)
        {
            // If all enemies have been destroyed, increment the level counter
            GameControl.control.level++;

            // Check to see if the enemy speed is 5, at most
            if (GameControl.control.enemySpeed <= 5f)
            {
                // If the enemy speed is 5 or lower, add 0.25 to the enemy speed
                GameControl.control.enemySpeed += 0.25f;
            }

            // Set the UFO can spawn flag to true
            GameControl.control.canSpawn = true;

            // Load the next level
            SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
        }
    }
}
