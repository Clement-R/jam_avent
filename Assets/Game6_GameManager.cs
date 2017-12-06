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
            
        scoreText.text = orderManager.GetScore().ToString();
        loseScoreText.text = "Score : " + scoreText.text;
    }
}
