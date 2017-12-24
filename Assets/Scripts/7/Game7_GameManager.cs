using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game7_GameManager : MonoBehaviour {
    public GameObject losePanel;
    public Text score;
    public Text endScore;
    public Text timer;
    public float gameTime = 50f;

    private float _score = 0f;
    private float _gameEndTimer = 0f;

	void Start ()
    {
        Time.timeScale = 1f;
        _gameEndTimer = Time.time + gameTime;
    }
	
	void Update ()
    {
        timer.text = (_gameEndTimer - Time.time).ToString("0.00");

        if (Time.time >= _gameEndTimer)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void AddScore()
    {
        _score++;
        score.text = _score.ToString();
        endScore.text = "Score : " + _score.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        SceneManager.LoadScene("main_menu");
    }

    // TODO : Music, shot sound, touch sound, explosion sound
}
