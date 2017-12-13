using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game13_PlayerBehavior : MonoBehaviour {

    public float jumpForce;

    private Rigidbody2D _rb;

    void Start ()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rb.velocity = new Vector2(0, 300);
        }

    }
}
