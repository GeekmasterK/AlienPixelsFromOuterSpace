using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    private Spawner ufoSpawner;
    public float minTime;
    public float maxTime;
    public GameObject ufo;

    // Use this for initialization
    void Awake()
    {
        if (ufoSpawner == null)
        {
            DontDestroyOnLoad(gameObject);
            ufoSpawner = this;
        }
        else if (ufoSpawner != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update ()
    {
		if(!GameControl.control.ufoSpawned)
        {
            GameControl.control.ufoSpawned = true;
            StartCoroutine(SpawnUFO(Random.Range(minTime, maxTime)));
        }
	}

    IEnumerator SpawnUFO(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Instantiate(ufo, transform.position, transform.rotation);
    }
}
