using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControl : MonoBehaviour {

    private Rigidbody2D enemyBulletRigidbody;

    public float speed;

	// Use this for initialization
	void Start ()
    {
        // Initialize the enemy bullet Rigidbody and set the velocity to make it move down
        enemyBulletRigidbody = GetComponent<Rigidbody2D>();
        enemyBulletRigidbody.velocity = Vector2.down * speed;
	}

    // Called on a trigger collision with another object
    void OnTriggerEnter2D(Collider2D other)
    {
        // Animator to switch the animation of the hit object
        Animator anim = other.GetComponent<Animator>();

        // Check to see if the enemy bullet hits the bottom wall
        if(other.tag == "BottomWall")
        {
            // If it hits the bottom wall, destroy the enemy bullet
            Destroy(gameObject);
        }

        // Check to see if the enemy bullet hits the player
        if(other.tag == "Player")
        {
            // If the enemy bullet hits the player,
                // destroy the enemy bullet,
                // play the player death sound,
                // play the player death animation,
                // stop player movement,
                // disable the player's collider,
                // and destroy the player object after half a second
            Destroy(gameObject);
            AudioManager.audioManager.Play("PlayerDead");
            GameControl.control.playerHit = true;
            anim.SetBool("IsDead", true);
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            other.gameObject.GetComponent<Rigidbody2D>().Sleep();
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(other.gameObject, 0.5f);
        }

        // Check to see if the enemy bullet hits a barrier
        if(other.tag == "Barrier")
        {
            // If the enemy bullet hits a barrier,
                // destroy the enemy bullet,
                // play the barrier destroyed sound,
                // play the barrier destroyed animation,
                // disable the barrier collider,
                // and destroy the barrier after half a second
            Destroy(gameObject);
            AudioManager.audioManager.Play("BarrierShot");
            anim.SetBool("IsDead", true);
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(other.gameObject, 0.5f);
        }
    }

    // Called when the enemy bullet is no longer visible on screen
    void OnBecameInvisible()
    {
        // If the enemy bullet is no longer visible on screen, destroy it
        Destroy(gameObject);
    }
}
