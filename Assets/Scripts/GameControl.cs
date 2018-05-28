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
    public GameObject[] enemies;

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
    }

    // Player loses a life, and the level resets
    public void LoseLife()
    {
        lives--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
