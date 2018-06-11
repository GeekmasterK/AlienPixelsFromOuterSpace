using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    public float points;

    public GameObject enemyBullet;

    private GameObject[] enemyFirePoints;

    private List<GameObject> priorityFirePoints;

    public float minFireRateTime;

    public float maxFireRateTime;

    public float baseFireWaitTime;

    // Use this for initialization
    void Start()
    {
        // Check to see if the level has started
        if (GameControl.control.levelStarted)
        {
            // If the level has started, add a random number in the range to the base wait time for the bullet firing
            baseFireWaitTime += Random.Range(minFireRateTime, maxFireRateTime);
        }
    }

    // Called once per frame
	void FixedUpdate ()
    {
        // Check to see if the level has started
        if (GameControl.control.levelStarted)
        {
            // If the level has started, call the shoot function
            Shoot();
        }
	}

    // Called when an enemy collides with another object
    void OnCollisionEnter2D(Collision2D other)
    {
        // Animators for the enemy and other object to switch animations
        Animator anim = other.gameObject.GetComponent<Animator>();
        Animator thisAnim = gameObject.GetComponent<Animator>();

        // Check to see if an enemy collides with the player
        if (other.gameObject.tag == "Player")
        {
            // If an enemy collides with the player,
                // destroy the enemy after half a second,
                // set the player hit flag to true,
                // play the player death and enemy death sounds,
                // play the player and enemy death animations,
                // detach the enemy from the formation,
                // stop player movement,
                // disable the player object,
                // and destroy the player after half a second
            Destroy(gameObject, 0.5f);
            GameControl.control.playerHit = true;
            AudioManager.audioManager.Play("PlayerDead");
            AudioManager.audioManager.Play("EnemyShot");
            anim.SetBool("IsDead", true);
            thisAnim.SetBool("IsDead", true);
            transform.parent = null;
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(other.gameObject, 0.5f);
        }
    }

    // Shoot based on priority at interval
    void Shoot()
    {
        // Variable to store the time since the start of the level
        float timeSinceStart = Time.timeSinceLevelLoad;

        // Initialize the array to store all the enemy fire points
        enemyFirePoints = GameObject.FindGameObjectsWithTag("EnemyFirePoint");

        // Initialize the array to store the fire points on the bottom row of enemies
        priorityFirePoints = new List<GameObject>();
        
        // Check to see if the base wait time has passed, if any enemy fire points exist, and if the enemy can shoot
        if (timeSinceStart > baseFireWaitTime && enemyFirePoints.Length > 0 && GameControl.control.enemyCanShoot)
        {
            // If the above conditions are met, add a random number in the range to the base wait time
            baseFireWaitTime += Random.Range(minFireRateTime, maxFireRateTime);

            // Check to see if the bottom row of enemies is green
            if(System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyGreenFirePoint"))
            {
                // Loop through the enemy fire points
                for(int i = 0; i < enemyFirePoints.Length; i++)
                {
                    // Check to see if the current fire point is from a green enemy
                    if (enemyFirePoints[i].name == "EnemyGreenFirePoint")
                    {
                        // If the current fire point is from a green enemy, add it to the priority fire points
                        priorityFirePoints.Add(enemyFirePoints[i]);
                    }
                }
                // Play the enemy shooting sound, and have a random green enemy fire
                AudioManager.audioManager.Play("EnemyFire");
                Instantiate(enemyBullet, priorityFirePoints[Random.Range(0, priorityFirePoints.Count)].transform.position, Quaternion.identity);
            }

            // Otherwise, if the bottom row of enemies is yellow...
            else if (!System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyGreenFirePoint") && System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyYellowFirePoint"))
            {
                // Loop through the enemy fire points
                for (int i = 0; i < enemyFirePoints.Length; i++)
                {
                    // Check to see if the current fire point is from a yellow enemy
                    if (enemyFirePoints[i].name == "EnemyYellowFirePoint")
                    {
                        // If the current fire point is from a yellow enemy, add it to the priority fire points
                        priorityFirePoints.Add(enemyFirePoints[i]);
                    }
                }
                // Play the enemy shooting sound, and have a random yellow enemy fire
                AudioManager.audioManager.Play("EnemyFire");
                Instantiate(enemyBullet, priorityFirePoints[Random.Range(0, priorityFirePoints.Count)].transform.position, Quaternion.identity);
            }

            // Otherwise, if the bottom row of enemies is orange...
            else if(!System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyGreenFirePoint") && !System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyYellowFirePoint") && System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyOrangeFirePoint"))
            {
                // Loop through the enemy fire points
                for (int i = 0; i < enemyFirePoints.Length; i++)
                {
                    // Check to see if the current fire point is from an orange enemy
                    if (enemyFirePoints[i].name == "EnemyOrangeFirePoint")
                    {
                        // If the current fire point is from an orange enemy, add it to the priority fire points
                        priorityFirePoints.Add(enemyFirePoints[i]);
                    }
                }
                // Play the enemy shooting sound, and have a random orange enemy fire
                AudioManager.audioManager.Play("EnemyFire");
                Instantiate(enemyBullet, priorityFirePoints[Random.Range(0, priorityFirePoints.Count)].transform.position, Quaternion.identity);
            }

            // Otherwise, if the bottom row of enemies is blue...
            else if(!System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyGreenFirePoint") && !System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyYellowFirePoint") && !System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyOrangeFirePoint") && System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyBlueFirePoint"))
            {
                // Loop through the enemy fire points
                for (int i = 0; i < enemyFirePoints.Length; i++)
                {
                    // Check to see if the current fire point is from a blue enemy
                    if (enemyFirePoints[i].name == "EnemyBlueFirePoint")
                    {
                        // If the current fire point is from a blue enemy, add it to the priority fire points
                        priorityFirePoints.Add(enemyFirePoints[i]);
                    }
                }
                // Play the enemy shooting sound, and have a random blue enemy fire
                AudioManager.audioManager.Play("EnemyFire");
                Instantiate(enemyBullet, priorityFirePoints[Random.Range(0, priorityFirePoints.Count)].transform.position, Quaternion.identity);
            }
        }

        // Clear the priority fire points list
        priorityFirePoints.Clear();
    }
}
