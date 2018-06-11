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
        // Initialize the UFO Rigidbody, and start it moving to the right at the specified speed
        ufoRigidbody = GetComponent<Rigidbody2D>();
        ufoRigidbody.velocity = new Vector2(1f, 0f) * speed;
	}

    // Called when the UFO becomes visible on screen
    void OnBecameVisible()
    {
        // Play the UFO sound
        AudioManager.audioManager.Play("UFO");    
    }

    // Called when the UFO is no longer visible on screen
    void OnBecameInvisible()
    {
        // Stop playing the UFO sound, and destroy the UFO
        AudioManager.audioManager.Stop("UFO");
        Destroy(gameObject);
    }
}
