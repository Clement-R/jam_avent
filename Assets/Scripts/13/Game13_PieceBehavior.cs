using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game13_PieceBehavior : MonoBehaviour
{
    public Game13_GameManager gameManager;

    public Vector2 speed;
    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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
            collision.gameObject.GetComponent<Game13_PlayerBehavior>().AddScore();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            //AkSoundEngine.PostEvent("Play_Game1_lose", gameObject);

            Destroy(gameObject);
            gameManager.Lose();
        }
    }
}
