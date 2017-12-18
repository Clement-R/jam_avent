using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game13_PieceBehavior : MonoBehaviour
{
    public Game13_GameManager gameManager;

    public Vector2 speed;
    private Rigidbody2D _rb;

    public Text scoreText;

    private int score;

    void Start()
    {
        score = 0;
        _rb = GetComponent<Rigidbody2D>();
        SetScoreText();

        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game13_GameManager>();
    }

    void Update()
    {
        _rb.velocity = new Vector2(-350, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //AkSoundEngine.PostEvent("Play_Game1_win", gameObject);

            Destroy(gameObject);
            score++;
            SetScoreText();
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            //AkSoundEngine.PostEvent("Play_Game1_lose", gameObject);

            Destroy(collision.gameObject);
            gameManager.Lose();
        }
    }

    void SetScoreText()
    {
        scoreText.text = score.ToString();
    }
}
