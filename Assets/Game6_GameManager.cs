using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game6_GameManager : MonoBehaviour {

    public SpriteRenderer contentSprite;
    public SpriteRenderer toppingSprite;

    public Text contentText;
    public Text toppingText;

    public Game6_OrderManager orderManager;
    public Text scoreText;
    public Text timeText;
    public float timeToMakeOrders = 50f;

    public GameObject losePanel;
    public Text loseScoreText;

    private float _gameEndTimer;

    void Start ()
    {
        Time.timeScale = 1f;

        _gameEndTimer = Time.time + timeToMakeOrders;
    }
	
    private void Update()
    {
        if (Time.time >= _gameEndTimer)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        
        this.contentSprite.sprite = orderManager.GetChosenContentSprite();
        this.toppingSprite.sprite = orderManager.GetChosenToppingSprite();

        Game6_OrderManager.Order order = orderManager.GetActualOrder();
        contentText.text = order.content.name;
        toppingText.text = order.topping.name;

        scoreText.text = orderManager.GetScore().ToString();
        loseScoreText.text = "Score : " + scoreText.text;
        timeText.text = (_gameEndTimer - Time.time).ToString();
    }
}
