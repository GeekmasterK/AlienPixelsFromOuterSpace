using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

    public float speed;

    private Rigidbody2D bulletRigidbody;

	// Use this for initialization
	void Start ()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = Vector2.up * speed;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Animator anim = other.GetComponent<Animator>();

        if(other.tag == "TopWall")
        {
            Destroy(gameObject);
        }

        if(other.tag == "Enemy")
        {
            Destroy(gameObject);
            anim.SetBool("IsDead", true);
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            other.transform.parent = null;
            addPoints();
            Destroy(other.gameObject, 0.5f);
            if(GameControl.control.enemies.Length <= 0)
            {
                AudioManager.audioManager.Stop("EnemySound");
            }
        }

        if (other.tag == "UFO")
        {
            Destroy(gameObject);
            anim.SetBool("IsDead", true);
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            other.gameObject.GetComponent<Rigidbody2D>().Sleep();
            addBonusPoints();
            Destroy(other.gameObject, 0.5f);
        }

        if (other.tag == "Barrier")
        {
            Destroy(gameObject);
            anim.SetBool("IsDead", true);
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            DestroyObject(other.gameObject, 0.5f);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Increment player score
    void addPoints()
    {
        EnemyControl enemy = FindObjectOfType<EnemyControl>();
        GameControl.control.score += enemy.points;
    }

    // Give player bonus points for destroying the UFO
    void addBonusPoints()
    {
        UFOControl ufo = FindObjectOfType<UFOControl>();
        GameControl.control.score += ufo.points;
    }
}
