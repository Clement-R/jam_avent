﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
    public int speed;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Vector2 bulletForce = transform.right * speed;
        rb.velocity = bulletForce;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Wall") {
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            AkSoundEngine.PostEvent("Play_Game1_Hit", gameObject);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
