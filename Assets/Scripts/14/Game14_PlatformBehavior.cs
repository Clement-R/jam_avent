﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game14_PlatformBehavior : MonoBehaviour {
    
    public float jumpForce;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                AkSoundEngine.PostEvent("Game14_Jump",gameObject);

                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }        
    }


}
