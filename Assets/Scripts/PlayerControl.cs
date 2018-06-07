using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {

    public float speed;

    private Rigidbody2D playerRigidbody;

    public GameObject bullet;

    public GameObject firePoint;

    private GameObject playerStartPoint;

    // Use this for initialization
    void Start ()
    {
        playerStartPoint = GameObject.FindGameObjectWithTag("PlayerStartPoint");
        playerRigidbody = GetComponent<Rigidbody2D>();
        transform.position = playerStartPoint.transform.position;
	}

    void FixedUpdate()
    {
        MovePlayer();
    }

    // Update is called once per frame
    void Update ()
    {
        Shoot();
	}

    // Move the player
    void MovePlayer()
    {
        float horzMove = Input.GetAxisRaw("Horizontal");
        if (!GameControl.control.playerDead && GameControl.control.levelStarted)
        {
            playerRigidbody.velocity = new Vector2(horzMove, 0f) * speed;
        }
    }

    // Shoot a bullet
    void Shoot()
    {
        if (!GameControl.control.playerDead && GameControl.control.levelStarted)
        {
            if (Input.GetButtonDown("Shoot"))
            {
                AudioManager.audioManager.Play("PlayerShoot");
                Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
            }
        }
    }
}
