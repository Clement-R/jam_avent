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
    }

    void Update()
    {
        _rb.velocity = new Vector2(-350, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //AkSoundEngine.PostEvent("Play_Game1_win", gameObject);

            Destroy(other.gameObject);
            score++;
            SetScoreText();
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            //AkSoundEngine.PostEvent("Play_Game1_lose", gameObject);

            Destroy(other.gameObject);
            gameManager.Lose();
        }               

    }

    void SetScoreText()
    {
        //scoreText.text = score.ToString();
    }
}
