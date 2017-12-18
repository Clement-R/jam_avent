using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game13_PlayerBehavior : MonoBehaviour {

    public float jumpForce;

    private Rigidbody2D _rb;
    private bool _isGrounded = true;

    void Start ()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(new Vector2(0, 400000));
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Floor")
        {
            _isGrounded = true;
        }
    }
}
