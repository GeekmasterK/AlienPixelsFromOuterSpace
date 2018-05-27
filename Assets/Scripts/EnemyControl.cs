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
	void Start ()
    { 
        baseFireWaitTime += Random.Range(minFireRateTime, maxFireRateTime);
    }

	void FixedUpdate ()
    {
        Shoot();
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        Animator anim = other.gameObject.GetComponent<Animator>();

        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("IsDead", true);
            other.gameObject.GetComponent<Rigidbody2D>().Sleep();
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(other.gameObject, 0.5f);
        }
    }

    // Shoot based on priority at interval
    void Shoot()
    {
        enemyFirePoints = GameObject.FindGameObjectsWithTag("EnemyFirePoint");
        priorityFirePoints = new List<GameObject>();
        

        if (Time.timeSinceLevelLoad > baseFireWaitTime && enemyFirePoints.Length > 0)
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

                Instantiate(enemyBullet, priorityFirePoints[Random.Range(0, priorityFirePoints.Count)].transform.position, Quaternion.identity);
            }
        }

        priorityFirePoints.Clear();
    }
}
