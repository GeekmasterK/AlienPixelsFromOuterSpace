using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public int sceneToLoad;

	// Use this for initialization
	void Awake ()
    {
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
	}
}
