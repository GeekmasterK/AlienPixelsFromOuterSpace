using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {

    public Text levelText;
	
	// Update is called once per frame
	void Update ()
    {
        // Set the current level number text
        levelText.text = GameControl.control.level.ToString("0");
	}
}
