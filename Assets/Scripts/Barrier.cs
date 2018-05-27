using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {

    private Barrier barrier;

	// Use this for initialization
	void Awake ()
    {
        if (barrier == null)
        {
            DontDestroyOnLoad(gameObject);
            barrier = this;
        }
        else if (barrier != this)
        {
            Destroy(gameObject);
        }
    }
}
