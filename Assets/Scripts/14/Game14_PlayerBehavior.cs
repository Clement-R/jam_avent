﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game14_PlayerBehavior : MonoBehaviour {

    public float movementSpeed;

    private float movement = 0f;

    Rigidbody2D rb;
	
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;

        if (transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Game14_GameManager>().Lose();
        }
	}

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }
}
