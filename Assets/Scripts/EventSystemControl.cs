using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemControl : MonoBehaviour {

    private bool exists;

	// Use this for initialization
	void Awake ()
    {
        // Check to see if there is no event system in the scene
		if(!exists)
        {
            // If there is no event system in the scene, make sure it persists when there is one, and set the exists flag to true
            DontDestroyOnLoad(gameObject);
            exists = true;
        }
	}
}
