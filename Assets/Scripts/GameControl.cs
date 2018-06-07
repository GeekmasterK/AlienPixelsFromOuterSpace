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
    public Rigidbody2D formationRigidBody;
    public Rigidbody2D ufoRigidbody;

    // Use this for initialization
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        AudioManager.audioManager.Play("UFOTitle");   
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        playerStartPoint = GameObject.FindGameObjectWithTag("PlayerStartPoint");
        formationStartPoint = GameObject.FindGameObjectWithTag("FormationStartPoint");
        formation = GameObject.FindGameObjectWithTag("EnemyFormation");
        ufo = GameObject.FindGameObjectWithTag("UFO");
        barriers = GameObject.FindGameObjectsWithTag("BarrierGroup");

        if (formation != null)
        {
            formationRigidBody = formation.gameObject.GetComponent<Rigidbody2D>();
        }

        if(ufo != null)
        {
            ufoRigidbody = ufo.gameObject.GetComponent<Rigidbody2D>();
        }

        if(playerHit)
        {
            StartCoroutine(LoseLife());
        }
        playerHit = false;

        if(lives > 0f && score >= scoreForExtraLife)
        {
            scoreForExtraLife += extraLifeIncrement;
            lives++;
        }
    }

    // Player loses a life, and the level resets
    public IEnumerator LoseLife()
    {
        enemyCanShoot = false;
        playerDead = true;
        formationRigidBody.velocity = new Vector2(0f, 0f);
        AudioManager.audioManager.Stop("EnemySound");
        if (ufo != null)
        {
            ufoRigidbody.velocity = new Vector2(0f, 0f);
            AudioManager.audioManager.Stop("UFO");
        }
        yield return new WaitForSeconds(2f);
        lives--;
        if (lives <= 0f)
        {
            gameOver = true;
        }
        else
        {
            formation.transform.position = formationStartPoint.transform.position;
            enemyCanShoot = true;
            formationRigidBody.velocity = new Vector2(1f, 0f) * enemySpeed;
            if (ufo != null)
            {
                ufoRigidbody.velocity = new Vector2(1f, 0f) * ufo.gameObject.GetComponent<UFOControl>().speed;
                AudioManager.audioManager.Play("UFO");
            }
            if (levelStarted && !gameOver)
            {
                Instantiate(player, playerStartPoint.transform.position, player.transform.rotation);
            }
            playerDead = false;
            AudioManager.audioManager.Play("EnemySound");
        }
    }
}
