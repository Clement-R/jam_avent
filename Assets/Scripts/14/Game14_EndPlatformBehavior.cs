﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game14_EndPlatformBehavior : MonoBehaviour {

       void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<Game14_GameManager>().Win();
            }
        }
    }
}
