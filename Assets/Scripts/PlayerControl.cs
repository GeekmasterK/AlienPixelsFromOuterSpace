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
        // Find the player start point, initialize the player Rigidbody, and set the player starting position
        playerStartPoint = GameObject.FindGameObjectWithTag("PlayerStartPoint");
        playerRigidbody = GetComponent<Rigidbody2D>();
        transform.position = playerStartPoint.transform.position;
	}
    
    // Called once per frame
    void FixedUpdate()
    {
        // Move the player
        MovePlayer();
    }

    // Update is called once per frame
    void Update ()
    {
        // Shoot a bullet
        Shoot();
	}

    // Move the player
    void MovePlayer()
    {
        // Assign the horizontal movement axis to a variable
        float horzMove = Input.GetAxisRaw("Horizontal");

        // Check to see if the player is alive, and the level has started
        if (!GameControl.control.playerDead && GameControl.control.levelStarted)
        {
            // If the above conditions are met, move the player on the horizontal axis at the specified speed
            playerRigidbody.velocity = new Vector2(horzMove, 0f) * speed;
        }
    }

    // Shoot a bullet
    void Shoot()
    {
        // Assign the shoot button input state to a variable
        bool shootPressed = Input.GetButtonDown("Shoot");

        // Check to see if the player is alive and the level has started
        if (!GameControl.control.playerDead && GameControl.control.levelStarted)
        {
            // Check to see if the player has pressed the shoot button
            if (shootPressed)
            {
                // If the above conditions are met, play the player shoot sound, and shoot a bullet
                AudioManager.audioManager.Play("PlayerShoot");
                Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
            }
        }
    }
}
