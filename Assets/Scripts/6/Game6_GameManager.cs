using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        AkSoundEngine.PostEvent("Play_Game6_Music", gameObject);
        Time.timeScale = 1f;
        _gameEndTimer = Time.time + timeToMakeOrders;
    }
	
    private void Update()
    {
        if (Time.time >= _gameEndTimer)
        {
            if(Time.timeScale > 0)
            {
                AkSoundEngine.PostEvent("Play_Game1_Hit", gameObject);
                losePanel.SetActive(true);
                Time.timeScale = 0f;
            }
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

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
