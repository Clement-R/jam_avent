using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SockController : MonoBehaviour {

    public Text scoreText;

    private Vector3 mousePosition;
    private int score;
    private Rigidbody2D _rb;
    
    void Start()
    {
        score = 0;
        SetScoreText();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _rb.MovePosition(new Vector2(mousePosition.x,transform.position.y));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Destroy(other.gameObject);           
            score++;
            SetScoreText();
        }
    }

    void SetScoreText()
    {
        scoreText.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }
}