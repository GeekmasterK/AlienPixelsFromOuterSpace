using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
	
	// Update is called once per frame
	void Update ()
    {
        // Set the current score text
        scoreText.text = GameControl.control.score.ToString("0");
	}
}
