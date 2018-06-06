using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour {

    public GameObject levelText;
    public GameObject readyText;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(StartLevel());
	}

    IEnumerator StartLevel()
    {
        GameControl.control.levelStarted = false;
        AudioManager.audioManager.Stop("EnemySound");
        AudioManager.audioManager.Stop("UFO");
        yield return new WaitForSeconds(2f);
        levelText.SetActive(false);
        readyText.SetActive(true);
        yield return new WaitForSeconds(2f);
        readyText.SetActive(false);
        GameControl.control.levelStarted = true;
        GameControl.control.canSpawn = true;
        AudioManager.audioManager.Play("EnemySound");
        GameControl.control.formationRigidBody.velocity = new Vector2(1f, 0f) * GameControl.control.enemySpeed;
    }
}
