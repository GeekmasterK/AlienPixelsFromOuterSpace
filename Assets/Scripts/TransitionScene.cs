using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour {

    public string sceneToLoad;

	// Use this for initialization
	void Awake ()
    {
        if (GameControl.control.barriers.Length > 0)
        {
            foreach (GameObject b in GameControl.control.barriers)
            {
                Destroy(b.gameObject);
            }
        }
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
	}
}
