using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOControl : MonoBehaviour {

    public Rigidbody2D ufoRigidbody;
    public float speed;
    public float points;

	// Use this for initialization
	void Start ()
    {
        ufoRigidbody = GetComponent<Rigidbody2D>();
        ufoRigidbody.velocity = new Vector2(1f, 0f) * speed;
	}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
