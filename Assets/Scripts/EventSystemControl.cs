using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemControl : MonoBehaviour {

    private bool exists;

	// Use this for initialization
	void Awake ()
    {
		if(!exists)
        {
            DontDestroyOnLoad(gameObject);
            exists = true;
        }
	}
}
