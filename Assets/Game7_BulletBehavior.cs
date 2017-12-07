using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game7_BulletBehavior : MonoBehaviour {

    private Game7_GameManager gameManager;

	void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game7_GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "PickUp")
        {
            gameManager.AddScore();
            AkSoundEngine.PostEvent("Play_Game1_win", gameManager.gameObject);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
