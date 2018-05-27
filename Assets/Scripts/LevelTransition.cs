using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour {

    public int levelToLoad;
	
	// Update is called once per frame
	void Update ()
    {
		if(GameControl.control.enemies.Length <= 0)
        {
            GameControl.control.level = levelToLoad;
            SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
        }
	}
}
