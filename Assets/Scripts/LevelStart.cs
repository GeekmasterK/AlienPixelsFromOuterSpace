using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour {

    public GameObject levelText;
    public GameObject readyText;

	// Use this for initialization
	void Start ()
    {
        // Start the level
        StartCoroutine(StartLevel());
	}

    IEnumerator StartLevel()
    {
        // Set the level started flag to false, and stop the enemy and UFO sounds
        GameControl.control.levelStarted = false;
        AudioManager.audioManager.Stop("EnemySound");
        AudioManager.audioManager.Stop("UFO");

        // Wait for 2 seconds, then switch from the level number text to the Ready message
        yield return new WaitForSeconds(2f);
        levelText.SetActive(false);
        readyText.SetActive(true);

        // Wait for 2 more seconds, then turn off the Ready message, 
        // set the level started flag to true, 
        // set the UFO can spawn flag to true, 
        // play the enemy sound, 
        // and start the enemy formation moving
        yield return new WaitForSeconds(2f);
        readyText.SetActive(false);
        GameControl.control.levelStarted = true;
        GameControl.control.canSpawn = true;
        AudioManager.audioManager.Play("EnemySound");
        GameControl.control.formationRigidBody.velocity = new Vector2(1f, 0f) * GameControl.control.enemySpeed;
    }
}
