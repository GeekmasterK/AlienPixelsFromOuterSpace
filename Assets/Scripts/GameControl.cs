using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public float lives;
    public float score;
    public float level;
    public float enemySpeed;
    public bool playerDead = false;
    public bool playerHit = false;
    public bool enemyCanShoot = true;
    public bool gameOver = false;
    public GameObject[] enemies;
    public GameObject player;
    public GameObject playerStartPoint;
    public GameObject formationStartPoint;
    public GameObject formation;
    public Rigidbody2D formationRigidBody;

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
        }
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        playerStartPoint = GameObject.FindGameObjectWithTag("PlayerStartPoint");
        formationStartPoint = GameObject.FindGameObjectWithTag("FormationStartPoint");
        formation = GameObject.FindGameObjectWithTag("EnemyFormation");
        formationRigidBody = formation.gameObject.GetComponent<Rigidbody2D>();

        if(playerHit)
        {
            StartCoroutine(LoseLife());
        }
        playerHit = false;

        if(lives <= 0f)
        {
            gameOver = true;
        }
    }

    // Player loses a life, and the level resets
    public IEnumerator LoseLife()
    {
        enemyCanShoot = false;
        playerDead = true;
        formationRigidBody.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(2f);
        lives--;
        formation.transform.position = formationStartPoint.transform.position;
        enemyCanShoot = true;
        formationRigidBody.velocity = new Vector2(1f, 0f) * enemySpeed;
        Instantiate(player, playerStartPoint.transform.position, player.transform.rotation);
        playerDead = false;
    }
}
