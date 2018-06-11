using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float minTime;
    public float maxTime;
    public GameObject ufo;
    public float spawnTime;

    // Use this for initialization
    void Awake()
    {
        // Set the spawn time to a random number of seconds in the interval
        spawnTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update ()
    {
        // Spawn UFO
        Spawn();
	}

    // Spawn UFO
    void Spawn()
    {
        // Assign the time since the start of the level to a variable
        float timeSinceStart = Time.timeSinceLevelLoad;

        // Check to see if the UFO can spawn, the level has started, the player is alive, and the spawn time has been reached
        if (GameControl.control.canSpawn && GameControl.control.levelStarted && !GameControl.control.playerDead && timeSinceStart >= spawnTime)
        {
            // If the above conditions are met, spawn the UFO, and set the UFO can spawn flag to false
            Instantiate(ufo, transform.position, transform.rotation);
            GameControl.control.canSpawn = false;
        }
    }
}
