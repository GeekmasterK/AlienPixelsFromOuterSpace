using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

    public float speed;

    private Rigidbody2D bulletRigidbody;

	// Use this for initialization
	void Start ()
    {
        // Initialize the RigidBody2D, and set its velocity to move up
        bulletRigidbody = GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = Vector2.up * speed;
	}

    // Called on a 2D trigger collision with another Collider2D
    void OnTriggerEnter2D(Collider2D other)
    {
        // Local animator variable to switch animations
        Animator anim = other.GetComponent<Animator>();

        // Check to see if the bullet hits the top wall
        if(other.tag == "TopWall")
        {
            // If it hits the top wall, destroy the bullet
            Destroy(gameObject);
        }

        // Check to see if the bullet hits an enemy
        if(other.tag == "Enemy")
        {
            // If the bullet hits an enemy, 
                // destroy the bullet,
                // play the enemy death sound,
                // play the enemy death animation,
                // disable the enemy's collider,
                // detach the enemy from the formation,
                // add the enemy's points value to the player's score,
                // and destroy the enemy object after half a second
            Destroy(gameObject);
            AudioManager.audioManager.Play("EnemyShot");
            anim.SetBool("IsDead", true);
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            other.transform.parent = null;
            addPoints();
            Destroy(other.gameObject, 0.5f);

            // Check to see if all the enemies in the level have been destroyed
            if(GameControl.control.enemies.Length <= 0)
            {
                // If all enemies in the level have been destroyed, stop the enemy sound
                AudioManager.audioManager.Stop("EnemySound");
            }
        }

        // Check to see if the bullet hits the bonus UFO
        if (other.tag == "UFO")
        {
            // If the bullet hits the UFO,
                // Destroy the bullet,
                // play the enemy death sound,
                // stop the UFO sound,
                // play the UFO death animation,
                // disable the UFO's collider and RigidBody,
                // add the bonus UFO points to the player's score,
                // and destroy the UFO object after half a second
            Destroy(gameObject);
            AudioManager.audioManager.Play("EnemyShot");
            AudioManager.audioManager.Stop("UFO");
            anim.SetBool("IsDead", true);
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            other.gameObject.GetComponent<Rigidbody2D>().Sleep();
            addBonusPoints();
            Destroy(other.gameObject, 0.5f);
        }

        // Check to see if the bullet hits a barrier
        if (other.tag == "Barrier")
        {
            // If the bullet hits a barrer,
                // Destroy the bullet,
                // play the barrier destroyed sound,
                // play the barrier destroyed animation,
                // disable the barrier's collider,
                // and destory the barrier object after half a second
            Destroy(gameObject);
            AudioManager.audioManager.Play("BarrierShot");
            anim.SetBool("IsDead", true);
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            DestroyObject(other.gameObject, 0.5f);
        }
    }

    // Called when the bullet object is no longer visible on screen
    void OnBecameInvisible()
    {
        // If the bullet is no longer visible on screen, destroy the bullet
        Destroy(gameObject);
    }

    // Increment player score
    void addPoints()
    {
        // Find the enemy that was killed, and add the points value to the player score
        EnemyControl enemy = FindObjectOfType<EnemyControl>();
        GameControl.control.score += enemy.points;
    }

    // Give player bonus points for destroying the UFO
    void addBonusPoints()
    {
        // Find the UFO, and add the bonus points value to the player score
        UFOControl ufo = FindObjectOfType<UFOControl>();
        GameControl.control.score += ufo.points;
    }
}
