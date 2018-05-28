using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControl : MonoBehaviour {

    private Rigidbody2D enemyBulletRigidbody;

    public float speed;

    private EnemyFormation formation;

    private PlayerControl player;

	// Use this for initialization
	void Start ()
    {
        enemyBulletRigidbody = GetComponent<Rigidbody2D>();
        enemyBulletRigidbody.velocity = Vector2.down * speed;
        formation = FindObjectOfType<EnemyFormation>();
        player = FindObjectOfType<PlayerControl>();
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
            anim.SetBool("IsDead", true);
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            formation.canShoot = false;
            formation.formationRigidBody.velocity = new Vector2(0f, 0f);
            player.playerDead = true;
            GameControl.control.LoseLife();
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
