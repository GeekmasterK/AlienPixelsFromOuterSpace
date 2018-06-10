using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {

    private Barrier barrier;

	// Use this for initialization
	void Awake ()
    {
        // Check to see if the barrier is null
        if (barrier == null)
        {
            // If it is null, make sure it persists and initialize it
            DontDestroyOnLoad(gameObject);
            barrier = this;
        }

        // Otherwise, if this barrier is a duplicate...
        else if (barrier != this)
        {
            // Destroy the duplicate barrier
            Destroy(gameObject);
        }
    }
}
