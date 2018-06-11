using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public float lives;
    public float score;
    public float scoreForExtraLife;
    public float extraLifeIncrement;
    public float level;
    public float enemySpeed;
    public bool playerDead = false;
    public bool playerHit = false;
    public bool enemyCanShoot = true;
    public bool gameOver = false;
    public bool canSpawn = false;
    public bool enemiesOnScreen = false;
    public bool levelStarted = false;
    public GameObject[] enemies;
    public GameObject player;
    public GameObject playerStartPoint;
    public GameObject formationStartPoint;
    public GameObject formation;
    public GameObject ufo;
    public GameObject[] barriers;
    public LevelStart levelStart;
    public Rigidbody2D formationRigidBody;
    public Rigidbody2D ufoRigidbody;

    // Called before Start
    void Awake()
    {
        // Check to see if the game control is null
        if (control == null)
        {
            // If the game control is null, make sure it persists, and initialize it
            DontDestroyOnLoad(gameObject);
            control = this;
        }

        // Otherwise, if there is a duplicate game control...
        else if (control != this)
        {
            // Destroy the duplicate game control and exit the function
            Destroy(gameObject);
            return;
        }
    }

    // Use this for initialization
    void Start()
    {
        // Play the UFO sound for the title screen
        AudioManager.audioManager.Play("UFOTitle");   
    }

    // Update is called once per frame
    void Update()
    {   
        // Initialize the global variables to their most recent state
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        playerStartPoint = GameObject.FindGameObjectWithTag("PlayerStartPoint");
        formationStartPoint = GameObject.FindGameObjectWithTag("FormationStartPoint");
        formation = GameObject.FindGameObjectWithTag("EnemyFormation");
        ufo = GameObject.FindGameObjectWithTag("UFO");
        barriers = GameObject.FindGameObjectsWithTag("BarrierGroup");
        levelStart = FindObjectOfType<LevelStart>();

        // Check to see if the enemy formation exists
        if (formation != null)
        {
            // If the enemy formation exists, initialize the formation Rigidbody
            formationRigidBody = formation.gameObject.GetComponent<Rigidbody2D>();
        }

        // Check to see if the UFO exists
        if(ufo != null)
        {
            // If the UFO exists, initialize the UFO Rigidbody
            ufoRigidbody = ufo.gameObject.GetComponent<Rigidbody2D>();
        }

        // Check to see if the player has been hit
        if(playerHit)
        {
            // If the player has been hit, lose a life and reset the player and enemy formation positions
            StartCoroutine(LoseLife());
        }
        // Set the player hit flag to false
        playerHit = false;

        // Gain an extra life via score interval
        GainLife();
    }

    // Player gains an extra life via score interval
    void GainLife()
    {
        // Check to see if the player has at least one life, and if the current score interval for an extra life has been reached
        if (lives > 0f && score >= scoreForExtraLife)
        {
            // If the above conditions are met, increment the score interval, increment the lives counter, and play the gain life sound
            scoreForExtraLife += extraLifeIncrement;
            lives++;
            AudioManager.audioManager.Play("GainLife");
        }
    }

    // Player loses a life, and the player and enemy formation positions reset
    public IEnumerator LoseLife()
    {
        // Disable enemy shooting and movement, and set the player dead flag to true
        enemyCanShoot = false;
        playerDead = true;
        formationRigidBody.velocity = new Vector2(0f, 0f);

        // Stop the enemy sound
        AudioManager.audioManager.Stop("EnemySound");

        // Check to see if the UFO exists
        if (ufo != null)
        {
            // If the UFO exists, stop its movement, and stop playing the UFO sound
            ufoRigidbody.velocity = new Vector2(0f, 0f);
            AudioManager.audioManager.Stop("UFO");
        }

        // Wait for 2 seconds, then decrement the lives counter
        yield return new WaitForSeconds(2f);
        lives--;

        // Check to see if the player is out of lives
        if (lives <= 0f)
        {
            // If the player is out of lives, Game Over
            gameOver = true;
        }

        // Otherwise...
        else
        {
            // Check to see if the level has started and if a Game Over state has not been reached
            if (levelStarted && !gameOver)
            {
                // Instantiate the player at their starting position
                Instantiate(player, playerStartPoint.transform.position, player.transform.rotation);
            }

            // Check to see if the level has started
            if (levelStarted)
            {
                // If the level has started, turn on the Ready text and set the formation back to its starting position
                formation.transform.position = formationStartPoint.transform.position;
                levelStart.readyText.SetActive(true);
            }

            // Wait for 2 seconds, then enable enemy shooting and movement, and set the player dead flag to false
            yield return new WaitForSeconds(2f);
            levelStart.readyText.SetActive(false);
            enemyCanShoot = true;
            formationRigidBody.velocity = new Vector2(1f, 0f) * enemySpeed;
            playerDead = false;

            // Check to see if the UFO exists
            if (ufo != null)
            {
                // If the UFO exists, start its movement, and play the UFO sound
                ufoRigidbody.velocity = new Vector2(1f, 0f) * ufo.gameObject.GetComponent<UFOControl>().speed;
                AudioManager.audioManager.Play("UFO");
            }
            // Play the enemy sound
            AudioManager.audioManager.Play("EnemySound");
        }
    }
}
