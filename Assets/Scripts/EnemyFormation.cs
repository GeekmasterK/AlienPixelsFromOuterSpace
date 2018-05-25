﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour {

    public static EnemyFormation formation;
    private Rigidbody2D formationRigidBody;

	// Use this for initialization
	void Start ()
    {
        formationRigidBody = GetComponent<Rigidbody2D>();
        formationRigidBody.velocity = new Vector2(1f, 0f) * GameControl.control.enemySpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "LeftWall")
        {
            StartCoroutine(MoveDownAndTurn(1));
        }
        if (other.gameObject.tag == "RightWall")
        {
            StartCoroutine(MoveDownAndTurn(-1));
        }
    }

    // Turn in opposite direction
    void Turn(int direction)
    {
        Vector2 newVelocity = formationRigidBody.velocity;
        newVelocity.x = GameControl.control.enemySpeed * direction;
        formationRigidBody.velocity = newVelocity;
    }

    // Move down after hitting a wall
    IEnumerator MoveDownAndTurn(int direction)
    {
        Vector2 newVelocity = formationRigidBody.velocity;
        newVelocity.y = GameControl.control.enemySpeed * -1;
        formationRigidBody.velocity = newVelocity;
        yield return new WaitForSeconds(0.2f);
        newVelocity.y = 0f;
        formationRigidBody.velocity = newVelocity;
        Turn(direction);
    }
}
