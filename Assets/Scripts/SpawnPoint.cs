using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject spawnObject;

	// Use this for initialization
	void Start ()
    {
        Instantiate(spawnObject, gameObject.transform.position, spawnObject.transform.rotation);
	}
}
