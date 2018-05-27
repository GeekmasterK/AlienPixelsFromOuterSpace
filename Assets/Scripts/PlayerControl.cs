using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed;

    private Rigidbody2D playerRigidbody;

    public GameObject bullet;

    public GameObject firePoint;

    public GameObject playerStartPoint;

	// Use this for initialization
	void Start ()
    {
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

        playerRigidbody.velocity = new Vector2(horzMove, 0f) * speed;
    }

    // Shoot a bullet
    void Shoot()
    {
        if(Input.GetButtonDown("Shoot"))
        {
            Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        }
    }
}
