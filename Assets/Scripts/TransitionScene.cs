using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour {

    public string sceneToLoad;

	// Use this for initialization
	void Awake ()
    {
        // Load the title screen from the initialization scene
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
	}
}
