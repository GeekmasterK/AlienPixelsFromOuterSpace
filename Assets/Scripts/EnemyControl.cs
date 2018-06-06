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
        if (GameControl.control.levelStarted)
        {
            baseFireWaitTime += Random.Range(minFireRateTime, maxFireRateTime);
        }
    }

	void FixedUpdate ()
    {
        if (GameControl.control.levelStarted)
        {
            Shoot();
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        Animator anim = other.gameObject.GetComponent<Animator>();
        Animator thisAnim = gameObject.GetComponent<Animator>();

        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
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
        float timeSinceStart = Time.timeSinceLevelLoad;
        enemyFirePoints = GameObject.FindGameObjectsWithTag("EnemyFirePoint");
        priorityFirePoints = new List<GameObject>();
        
        
        if (timeSinceStart > baseFireWaitTime && enemyFirePoints.Length > 0 && GameControl.control.enemyCanShoot)
        {
            baseFireWaitTime += Random.Range(minFireRateTime, maxFireRateTime);
            if(System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyGreenFirePoint"))
            {
                for(int i = 0; i < enemyFirePoints.Length; i++)
                {
                    if (enemyFirePoints[i].name == "EnemyGreenFirePoint")
                    {
                        priorityFirePoints.Add(enemyFirePoints[i]);
                    }
                }
                AudioManager.audioManager.Play("EnemyFire");
                Instantiate(enemyBullet, priorityFirePoints[Random.Range(0, priorityFirePoints.Count)].transform.position, Quaternion.identity);
            }
            else if (!System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyGreenFirePoint") && System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyYellowFirePoint"))
            {
                for (int i = 0; i < enemyFirePoints.Length; i++)
                {
                    if (enemyFirePoints[i].name == "EnemyYellowFirePoint")
                    {
                        priorityFirePoints.Add(enemyFirePoints[i]);
                    }
                }
                AudioManager.audioManager.Play("EnemyFire");
                Instantiate(enemyBullet, priorityFirePoints[Random.Range(0, priorityFirePoints.Count)].transform.position, Quaternion.identity);
            }
            else if(!System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyGreenFirePoint") && !System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyYellowFirePoint") && System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyOrangeFirePoint"))
            {
                for (int i = 0; i < enemyFirePoints.Length; i++)
                {
                    if (enemyFirePoints[i].name == "EnemyOrangeFirePoint")
                    {
                        priorityFirePoints.Add(enemyFirePoints[i]);
                    }
                }
                AudioManager.audioManager.Play("EnemyFire");
                Instantiate(enemyBullet, priorityFirePoints[Random.Range(0, priorityFirePoints.Count)].transform.position, Quaternion.identity);
            }
            else if(!System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyGreenFirePoint") && !System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyYellowFirePoint") && !System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyOrangeFirePoint") && System.Array.Exists(enemyFirePoints, firePoint => firePoint.gameObject.name == "EnemyBlueFirePoint"))
            {
                for (int i = 0; i < enemyFirePoints.Length; i++)
                {
                    if (enemyFirePoints[i].name == "EnemyBlueFirePoint")
                    {
                        priorityFirePoints.Add(enemyFirePoints[i]);
                    }
                }
                AudioManager.audioManager.Play("EnemyFire");
                Instantiate(enemyBullet, priorityFirePoints[Random.Range(0, priorityFirePoints.Count)].transform.position, Quaternion.identity);
            }
        }

        priorityFirePoints.Clear();
    }
}
