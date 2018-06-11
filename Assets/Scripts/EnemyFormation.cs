using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFormation : MonoBehaviour {

    public Rigidbody2D formationRigidBody;
    public GameObject formationStartPoint;

	// Use this for initialization
	void Awake ()
    {
        // Initialize the formation Rigidbody
        formationRigidBody = GetComponent<Rigidbody2D>();
    }

    // Called when the formation collides with another object
    void OnCollisionEnter2D(Collision2D other)
    {
        // Check to see if the formation hits the left wall
        if (other.gameObject.tag == "LeftWall")
        {
            // If the formation hits the left wall, move down and change direction
            StartCoroutine(MoveDownAndTurn(1));
        }

        // Check to see if the formation hits the right wall
        if (other.gameObject.tag == "RightWall")
        {
            // If the formation hits the right wall, move down and change direction
            StartCoroutine(MoveDownAndTurn(-1));
        }
    }

    // Turn in the opposite direction
    void Turn(int direction)
    {
        // Set the formation Rigidbody movement to the opposite direction
        Vector2 newVelocity = formationRigidBody.velocity;
        newVelocity.x = GameControl.control.enemySpeed * direction;
        formationRigidBody.velocity = newVelocity;
    }

    // Move down after hitting a wall
    IEnumerator MoveDownAndTurn(int direction)
    {
        // Set the formation rigidbody to move down
        Vector2 newVelocity = formationRigidBody.velocity;
        newVelocity.y = GameControl.control.enemySpeed * -1;
        formationRigidBody.velocity = newVelocity;

        // Move down for 0.2 seconds, then turn in the opposite direction
        yield return new WaitForSeconds(0.2f);
        newVelocity.y = 0f;
        formationRigidBody.velocity = newVelocity;
        Turn(direction);
    }
}
