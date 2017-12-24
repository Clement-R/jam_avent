using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game14_GameManager : MonoBehaviour {

    public float gravityForce;

    public GameObject losePanel;
    public Text endTimer;
    public Text timer;
    public GameObject winPanel;

    void Start ()
    {
        Physics2D.gravity = new Vector2(0, gravityForce);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        timer.text = Time.timeSinceLevelLoad.ToString("0.00");
    }

    public void Win ()
    {
        winPanel.SetActive(true);
        endTimer.text = "Time : " + Time.timeSinceLevelLoad.ToString("0.00");
        Time.timeScale = 0f;
    }

    public void Lose()
    {
        losePanel.SetActive(true);
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
