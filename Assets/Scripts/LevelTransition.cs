using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour {

    public string levelToLoad;
	
	// Update is called once per frame
	void Update ()
    {
		if(GameControl.control.enemies.Length <= 0)
        {
            GameControl.control.level++;
            GameControl.control.canSpawn = true;
            SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
        }
	}
}
