using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game12_GameManager : MonoBehaviour {

    public Text loseText;

    public GameObject losePanel;

    public float timeToLive;
    public Text timer;

    public Game12_PlayerController P1;
    public Game12_PlayerController P2;

    public Text score1Text;
    public Text score2Text;

    private int score1;
    private int score2;

    void Start ()
    {
        score1 = 0;
        score2 = 0;
        Time.timeScale = 1f;
    }
    

    public void AddScore(string player)
    {
        if(player == "P1")
        {
            score1++;
        }
        else
        {
            score2++;
        }
    }
	
	void Update ()
    {
        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();

        if (timeToLive <= 0f)
        {
            if(score1 > score2)
            {
                loseText.text = "P1 wins !";
            }
            else if(score2 > score1)
            {
                loseText.text = "P2 wins !";
            }
            else
            {
                loseText.text = "You both win !";
            }

            losePanel.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Time.timeScale > 0f)
        {
            timeToLive -= Time.deltaTime;
            timer.text = "Timer : " + timeToLive.ToString("0.0");
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        SceneManager.LoadScene("main_menu");
    }
}
