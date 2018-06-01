using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControl : MonoBehaviour {

    private Rigidbody2D enemyBulletRigidbody;

    public float speed;

	// Use this for initialization
	void Start ()
    {
        enemyBulletRigidbody = GetComponent<Rigidbody2D>();
        enemyBulletRigidbody.velocity = Vector2.down * speed;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Animator anim = other.GetComponent<Animator>();

        if(other.tag == "BottomWall")
        {
            Destroy(gameObject);
        }

        if(other.tag == "Player")
        {
            Destroy(gameObject);
            GameControl.control.playerHit = true;
            anim.SetBool("IsDead", true);
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(other.gameObject, 0.5f);
        }

        if(other.tag == "Barrier")
        {
            Destroy(gameObject);
            anim.SetBool("IsDead", true);
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(other.gameObject, 0.5f);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
