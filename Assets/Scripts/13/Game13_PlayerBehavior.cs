using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game13_PlayerBehavior : MonoBehaviour {

    public float jumpForce;
    public Text scoreText;

    private Rigidbody2D _rb;
    private bool _isGrounded = true;
    private int _score = 0;

    void Start ()
    {
        scoreText = GameObject.FindGameObjectWithTag("PickUp").GetComponent<Text>();
        _score = 0;
        _rb = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(new Vector2(0, jumpForce));
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

    public void AddScore()
    {
        _score++;
        scoreText.text = _score.ToString();
    }

    public int GetScore()
    {
        return _score;
    }
}
