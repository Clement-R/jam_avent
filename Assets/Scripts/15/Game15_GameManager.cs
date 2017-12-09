using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game15_GameManager : MonoBehaviour {

    public SpriteRenderer snowSprite;
    public Sprite[] snows;

    public GameObject losePanel;
    public Text endTimer;

    public Text timer;

    private int snowIndex = 0;

    private int score = 0;
    


	void Start ()
    {
        Time.timeScale = 1f;
        snowSprite.sprite = snows[snowIndex];
    }
	

	void Update ()
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                score++;
                AddScore();
                CheckForEnd();
            }

            timer.text = Time.time.ToString("0.00");
        }
	}

    private void AddScore ()
    {
        if (score % 10 == 0 && score != 0)
        {
            snowIndex++;
            snowSprite.sprite = snows[snowIndex];
        }
    }

    private void CheckForEnd ()
    {
        if (snowIndex == snows.Length -1)
        {
            losePanel.SetActive(true);
            endTimer.text = "Time : " + Time.time.ToString("0.00");
            Time.timeScale = 0f;
        }
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
