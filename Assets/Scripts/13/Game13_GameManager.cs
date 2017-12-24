using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game13_GameManager : MonoBehaviour {

    public GameObject losePanel;
    public Text endScore;

    public Text score;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void Lose()
    {
        losePanel.SetActive(true);
        endScore.text = GameObject.FindGameObjectWithTag("Player").GetComponent<Game13_PlayerBehavior>().GetScore().ToString();
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        print("Retry");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        SceneManager.LoadScene("main_menu");
    }
}
