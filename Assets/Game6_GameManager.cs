using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game6_GameManager : MonoBehaviour {

    public SpriteRenderer contentSprite;
    public SpriteRenderer toppingSprite;
    public Game6_OrderManager orderManager;
    public Text scoreText;
    public float timeToMakeOrders = 50f;

    private float _gameEndTimer;

    void Start ()
    {
        contentSprite = null;
        toppingSprite = null;

        _gameEndTimer = Time.time + timeToMakeOrders;
    }
	
    private void Update()
    {
        if (Time.time >= _gameEndTimer)
        {
            // TODO : End of the game
        }

        this.contentSprite.sprite = orderManager.GetChosenContent().sprite;
        this.toppingSprite.sprite = orderManager.GetChosenTopping().sprite;

        scoreText.text = orderManager.GetScore().ToString();
    }
}
