using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControl : MonoBehaviour {

    private CanvasControl canvas;

	// Use this for initialization
	void Awake ()
    {
	    if(canvas == null)
        {
            DontDestroyOnLoad(gameObject);
            canvas = this;
        }
        else if(canvas != this)
        {
            Destroy(gameObject);
        }
	}
}
