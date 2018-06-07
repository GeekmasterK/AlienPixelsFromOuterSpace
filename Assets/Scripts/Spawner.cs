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
        spawnTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update ()
    {
        Spawn();
	}

    // Spawn UFO
    void Spawn()
    {
        if (GameControl.control.canSpawn && GameControl.control.levelStarted && !GameControl.control.playerDead && Time.timeSinceLevelLoad >= spawnTime)
        {
            Instantiate(ufo, transform.position, transform.rotation);
            GameControl.control.canSpawn = false;
        }
    }
}
